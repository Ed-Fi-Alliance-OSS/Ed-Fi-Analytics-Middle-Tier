# Adapted from http://www.mikefal.net/2015/03/24/auditing-sql-execution-times-with-powershell/
# And https://sqlblog.org/2011/01/31/how-i-use-powershell-to-collect-performance-counter-data
# And https://github.com/Ed-Fi-Alliance/Ed-Fi-X-Performance/blob/ace369401b9ae537ca9f1ffd08fec11fe5618a06/TestRunner.ps1

# Before this can be run against Postgres, an ODBC connection must be created to connect to any Postgres db
# In Windows, Open Start Menu, type "ODBC" and pick ODBC Data Sources (64 bit)
# On the System DSN tab click Add, and for the driver pick PostgreSQL Unicode(x64), which matches what we specify in the ODBC connection code before
# Give the datasource a name that is meaningful, such as "LocalGlendale" for connecting to the local Glendale database
# Specify the db name, matching the casing of how it was created
# For server input localhost, fill in a username and password that can connect to the db, and fill in port 5432
# You can then click Test to confirm it works before saving

# these three server names can be left alone
$sqlServerName = 'localhost'
$postgresServerName = 'localhost'
$serverName = "localhost"

# update this to be the SQL Server db names, if needed
$sqlDbsToTest = @(
    'EdFi_Ods_Glendale',
    'Edfi_Ods_Grandbend'
)

# update this to be the Postgres db names, if needed
$postgresDbsToTest = @(
    'edfi_ods_glendale',
    'edfi_ods_grandbend'
)

# update this to where you want it to output the query results, if somewhere different
$currentDateTime = Get-Date -format "yyyyMMddHHmm"
$pathToStoreQueryResults = ".\query-metrics_$currentDateTime.csv"

$global:pathToStorePerfResults = ".\server-metrics_$currentDateTime.csv"

# how many times will we run the query and then average the results afterwards?
$numberOfTimesToRepeatQuery = 5

# populate this with the list of views,
# it is not case sensitive since we ToLower before querying it for Postgres
$viewList = @(
    'analytics.ClassPeriodDim',
    'analytics.ContactPersonDim',
    'analytics.DemographicDim',
    'analytics.GradingPeriodDim',
    'analytics.LocalEducationAgencyDim',
    'analytics.MostRecentGradingPeriod',
    'analytics.SchoolDim',
    'analytics.SectionDim',
    'analytics.StaffSectionDim',
    'analytics.StudentLocalEducationAgencyDemographicsBridge',
    'analytics.StudentLocalEducationAgencyDim',
    'analytics.StudentProgramDim',
    'analytics.StudentSchoolDemographicsBridge',
    'analytics.StudentSchoolDim',
    'analytics.StudentSectionDim'
)

# These are all specific to SQL Server and not relevant for Postgres, so being left out for now
$expectedPerformanceCounters = @(
    # "\SQLServer:Access Methods\Full Scans/sec", 
    # "\SQLServer:SQL Statistics\Batch Requests/sec", 
    # "\SQLServer:General Statistics\User Connections", 
    # "\SQLServer:Wait Statistics(*)\Network IO Waits", 
    # "\SQLServer:Wait Statistics(*)\Page IO Latch Waits"
)

function Measure-SqlCmd{
   param($instancename
       ,$databasename = 'tempdb'
       ,$view
       ,$engine)
 
   Write-Host "Running on $instancename against $databasename in $engine for $view"
   $output = New-Object System.Object
 
   $output | Add-Member -Type NoteProperty -Name InstanceName -Value $instancename
   $output | Add-Member -Type NoteProperty -Name DatabaseName -Value $databasename
   $output | Add-Member -Type NoteProperty -Name Engine -Value $engine 

   $output | Add-Member -Type NoteProperty -Name View -Value $view
   $query = 'select * from ' + $view.ToLower() + ';'

   if($engine -eq "SqlServer"){
        $summedSQLExecutionTime = 0;
        $summedSQLBuffersReceived = 0;

        for (($i = 1); $i -le $numberOfTimesToRepeatQuery; $i++){
            $sqlout = Invoke-Sqlcmd -ServerInstance $instancename -Database $databasename -StatisticsVariable stats -Query $query -ErrorVariable errval
            $summedSQLExecutionTime += $stats.ExecutionTime
            $summedSQLBuffersReceived += $stats.BuffersReceived
        }
        
        if(!$sqlOut) {
            $output | Add-Member -Type NoteProperty -Name RowCount -Value "0"
            $output | Add-Member -Type NoteProperty -Name ColumnCount -Value "0"

        } else {
            #Invoke-SqlCmd returns as DataRow when one row, then as DataTable when multipe rows
            if($sqlOut.GetType().ToString() -eq "System.Data.DataRow"){
                $output | Add-Member -Type NoteProperty -Name RowCount -Value "1"
            } else {
                $output | Add-Member -Type NoteProperty -Name RowCount -Value $sqlout.Length
            }
            
            $output | Add-Member -Type NoteProperty -Name ColumnCount -Value $sqlout[0].ItemArray.Count
        }
        
        $output | Add-Member -Type NoteProperty -Name BuffersReceived -Value ($summedSQLBuffersReceived / $numberOfTimesToRepeatQuery)
        $output | Add-Member -Type NoteProperty -Name ExecutionTime -Value ($summedSQLExecutionTime / $numberOfTimesToRepeatQuery)
   }
   if ($engine -eq "Postgres"){
        $summedPostgresExectionTime = 0

        $conn = New-Object System.Data.Odbc.OdbcConnection
        $conn.ConnectionString = "Driver={PostgreSQL Unicode(x64)};Server=localhost;Port=5432;Database=" + $databasename + ";UID=postgres;PWD=postgres"
        $conn.open()
        for (($i = 1); $i -le $numberOfTimesToRepeatQuery; $i++){
            $startTime = Get-Date
            $cmd = New-object System.Data.Odbc.OdbcCommand($query,$conn)
            $ds = New-Object system.Data.DataSet
            (New-Object system.Data.odbc.odbcDataAdapter($cmd)).fill($ds) | out-null
            $endTime = Get-Date
            $summedPostgresExectionTime += (New-TimeSpan -Start $startTime -End $endTime).TotalMilliseconds
        }
        $conn.close()        
        $result = $ds.Tables[0]
    
        $output | Add-Member -Type NoteProperty -Name RowCount -Value $result.Rows.Count
        $output | Add-Member -Type NoteProperty -Name ColumnCount -Value $result.Columns.Count
        $output | Add-Member -Type NoteProperty -Name ExecutionTime -Value ($summedPostgresExectionTime / $numberOfTimesToRepeatQuery)
        $output | Add-Member -Type NoteProperty -Name BuffersReceived -Value ''
   }
   return $output
}

function Get-ServerMetrics {
    $result = [pscustomobject] @{
        Time = Get-Date -format "yyyy-MM-dd HH:mm:ss" ;
    }

    $result | Add-Member -Name "CPU Load (%)" -Value (Get-CimInstance win32_processor | Measure-Object -property LoadPercentage -Average).Average -MemberType NoteProperty
    $result | Add-Member -Name "Memory Used (%)" -Value (Get-CimInstance win32_operatingsystem | Select-Object @{Name = "MemoryUsage"; Expression = {"{0:N2}" -f ((($_.TotalVisibleMemorySize - $_.FreePhysicalMemory)*100)/ $_.TotalVisibleMemorySize) }}).MemoryUsage -MemberType NoteProperty

    foreach ($item in (Get-CimInstance Win32_LogicalDisk)) {

        $result | Add-Member -Name "Drive $($item.Name) Free Space (GB)" -Value ([Math]::Round($item.FreeSpace /1GB,2)) -MemberType NoteProperty

    }

    if ($actualPerformanceCounters -contains "\ASP.NET\Requests Queued") {
        $result | Add-Member -MemberType NoteProperty -Name "Requests Queued" -Value (get-counter -Counter "\ASP.NET\Requests Queued").CounterSamples.CookedValue }
    if ($actualPerformanceCounters -contains "\SQLServer:Access Methods\Full Scans/sec") {
        $result | Add-Member -MemberType NoteProperty -Name "Full Scans per second" -Value ([Math]::Round((get-counter -Counter "\SQLServer:Access Methods\Full Scans/sec").CounterSamples.CookedValue,2)) }
    if ($actualPerformanceCounters -contains "\SQLServer:SQL Statistics\Batch Requests/sec") {
        $result | Add-Member -MemberType NoteProperty -Name "Batch Requests per second" -Value ([Math]::Round((get-counter -Counter "\SQLServer:SQL Statistics\Batch Requests/sec").CounterSamples.CookedValue,2)) }
    if ($actualPerformanceCounters -contains "\SQLServer:General Statistics\User Connections") {
        $result | Add-Member -MemberType NoteProperty -Name "User Connections" -Value (get-counter -Counter "\SQLServer:General Statistics\User Connections").CounterSamples.CookedValue }
    if ($actualPerformanceCounters -contains "\SQLServer:Wait Statistics(*)\Network IO Waits") {
        $result | Add-Member -MemberType NoteProperty -Name "Network IO Waits started per second" -Value (get-counter -Counter "\SQLServer:Wait Statistics(waits started per second)\Network IO Waits").CounterSamples.CookedValue }
    if ($actualPerformanceCounters -contains "\SQLServer:Wait Statistics(*)\Page IO Latch Waits") {
        $result | Add-Member -MemberType NoteProperty -Name "Page IO Latch Waits started per second" -Value (get-counter -Counter "\SQLServer:Wait Statistics(waits started per second)\Page IO Latch Waits").CounterSamples.CookedValue }

    $result
}

$serverMetricsBackgroundScript = {
    param($server, $getMetricsBlock, $expectedPerformanceCounters)

    try {
        $csvPath = $Using:pathToStorePerfResults
        $actualPerformanceCounters = Compare-Object (typeperf -q) $expectedPerformanceCounters -PassThru -IncludeEqual -ExcludeDifferent
        $getMetricsBlock = [scriptblock]::Create($getMetricsBlock)

        $sleepTime = 5

        while ($true) {
            $record = Invoke-Command -ScriptBlock $getMetricsBlock
            $record | Select-Object * -ExcludeProperty PSComputerName,RunspaceId,PSShowComputerName | Export-Csv -Path $csvPath -Append -NoTypeInformation
            Start-Sleep -Seconds $sleepTime
        }
    }
    finally {
        if ($psSession -ne $null) {
            $psSession | Remove-PSSession
        }
    }
}

function Log($message) {
    $timestamp = Get-Date -Format "yyyy-MM-dd HH:mm:ss,fff"
    $output = "[$timestamp] $message"
    Write-Host $output
    $output | Out-File -Encoding UTF8 ".\PerformanceTesterLog$currentDateTime.txt" -Append
}

$backgroundJobs = @{}

Log "Starting background job to fetch metrics from $serverName"
$collectStatsFromDb = Start-Job -ArgumentList @($serverName, ${function:Get-ServerMetrics}, $expectedPerformanceCounters) -ScriptBlock $serverMetricsBackgroundScript
$backgroundJobs.Add($serverName, $collectStatsFromDb)

$total = @()

foreach ($view in $viewList){
    foreach($sqlDbName in $sqlDbsToTest){
        $total += Measure-SqlCmd -instancename $sqlServerName -databasename $sqlDbName -View $view -Engine "SqlServer"
    }
    foreach($postgresDbName in $postgresDbsToTest){
        $total += Measure-SqlCmd -instancename $postgresServerName -databasename $postgresDbName -View $view -Engine "Postgres"
    }
}

Log "Test runner process complete"

foreach ($serverName in $backgroundJobs.Keys) {
    Log "Stopping background job to fetch metrics from $serverName. Output collected from background job"
    $backgroundJob = $backgroundJobs.Item($serverName)
    try{
        Stop-Job -Job $backgroundJob
        Receive-Job -Job $backgroundJob
        Remove-Job -Job $backgroundJob
    }
    catch{
        Log "Failed to stop job for $($serverName):"
        Log $_.Exception.Message
        $formatstring = "{0} : {1}`n{2}`n" +
            "    + CategoryInfo          : {3}`n" +
            "    + FullyQualifiedErrorId : {4}`n"
        $fields = $_.InvocationInfo.MyCommand.Name,
                $_.ErrorDetails.Message,
                $_.InvocationInfo.PositionMessage,
                $_.CategoryInfo.ToString(),
                $_.FullyQualifiedErrorId
        Log ($formatstring -f $fields)
    }
}

$total | Select-Object Engine,DatabaseName,View,RowCount,ColumnCount,ExecutionTime,BuffersReceived | Export-Csv -Path $pathToStoreQueryResults -NoTypeInformation
