# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

<#
        .SYNOPSIS
        Creates an ODS database with the empty tables to run the AMT tests.

        .DESCRIPTION
        Create an ODS database with the empty tables to run the AMT tests.

        If the database exists, it will be replaced. The database will be recreated and the object creation script will be executed.

        .PARAMETER pghost
        Specifies the host server for the Postgresql instance.

        .PARAMETER user
        Specifies the user for the postgres database.

        .PARAMETER port
        Specifies the port for the postgres database.

        .PARAMETER database
        Specifies the name of the postgres database to create.

        .PARAMETER script
        Specifies the script path for creating the database objects.

        .PARAMETER datastandard
        Specifies the datastandard version for the database.

        .INPUTS
        None. You cannot pipe objects to CreateTestDbAndSchema.ps1.

        .OUTPUTS
        None. CreateTestDbAndSchema.ps1 does not generate any output.
        
        .EXAMPLE
        PS> .\CreateTestDbAndSchema.ps1 -d edfi_ods_tests -s "EdFi.Ods.Minimal.Template.sql"
        dropping db if it exists
        creating db
        Running migration on db
        ...
        .EXAMPLE
        PS> PS> .\CreateTestDbAndSchema.ps1 -pghost localhost -d edfi_ods_tests -s "EdFi.Ods.Minimal.Template.sql"
        dropping db if it exists
        creating db
        Running migration on db
        ...
        .EXAMPLE
        PS> PS> .\CreateTestDbAndSchema.ps1 -pghost localhost -port 5432 -d edfi_ods_tests -s "EdFi.Ods.Minimal.Template.sql"
        dropping db if it exists
        creating db
        Running migration on db
        ...
        .EXAMPLE
        PS> PS> .\CreateTestDbAndSchema.ps1 -pghost localhost -user dbUser -d edfi_ods_tests -s "EdFi.Ods.Minimal.Template.sql"
        dropping db if it exists
        creating db
        Running migration on db
        ...
        .EXAMPLE
        PS> PS> .\CreateTestDbAndSchema.ps1 -pghost localhost -port 5432 -d edfi_ods_tests -s "EdFi.Ods.Minimal.Template.sql"
        dropping db if it exists
        creating db
        Running migration on db
        ...
    #>
param ( [string][Alias('h')]$pghost="localhost",
		[string][Alias('u')]$user="postgres",
		[string][Alias('p')]$port="5432",
        [string][Alias('ds')]
        [ValidateSet("3.2", "3.3")]
        $datastandard="3.2",
		[string][Alias('d')]$database="edfi_ods_tests_ds32",
        [string][Alias('s')]$script="$PSScriptRoot/../src/EdFi.AnalyticsMiddleTier.Tests/EdFi.Ods32.Minimal.Template.sql")
$dropDatabase = "DROP DATABASE IF EXISTS" +" " + $database +";"
$createDatabase = "CREATE DATABASE" +" " + $database +";"

if($datastandard -eq "3.2"){
    $script="$PSScriptRoot/../src/EdFi.AnalyticsMiddleTier.Tests/EdFi.Ods32.Minimal.Template.sql"
    $database="edfi_ods_tests_ds32"
}
elseif($datastandard -eq "3.3"){
    $script="$PSScriptRoot/../src/EdFi.AnalyticsMiddleTier.Tests/EdFi.Ods33.Minimal.Template.sql"
    $database="edfi_ods_tests_ds33"
}

Write-Host "dropping db if it exists"
psql -h $pghost -p $port -U $user -c $dropDatabase
Write-Host "creating db"
psql -h $pghost -p $port -U $user -c $createDatabase
Write-Host "Running migration on db"
psql -d $database -h $pghost -p $port  -U $user -f $script