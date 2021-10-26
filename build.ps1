# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

[CmdLetBinding()]
<#
    .SYNOPSIS
        Automation script for running build operations from the command line.

    .DESCRIPTION
        Provides automation of the following tasks:
        
        * Build: runs `dotnet build` with several implicit steps
          (clean, restore, inject version information).

    .EXAMPLE
        .\build.ps1 build -Configuration Release -Version "2.0.0" -BuildCounter 45

        Overrides the default build configuration (Debug) to build in release
        mode with assembly version 2.0.0.45.
#>
param(
    # Command to execute, defaults to "Build".
    [string]
    [ValidateSet("Build")]
    $Command = "Build",

    # Assembly and package version number, defaults 3.2.0-c
    # This depends on what version of ODS/API is installed.
    # See AMT delpoyment guide to match versions.
    [string]
    $Version = "2.6.1",

    # Build counter from the automation tool.
    [string]
    $BuildCounter = "1",

    # .NET project build configuration, defaults to "Debug". Options are: Debug, Release.
    [string]
    [ValidateSet("Debug", "Release")]
    $Configuration = "Debug"

)

$Env:MSBUILDDISABLENODEREUSE = "1"

#$solution = "Application\Ed-Fi-ODS-Tools.sln"
$solutionRoot = "$PSScriptRoot/src"
$maintainers = "Ed-Fi Alliance, LLC and contributors"
	Import-Module -Name "$PSScriptRoot/eng/build-helpers.psm1" -Force


function Clean {
    Invoke-Execute { dotnet clean $solutionRoot -c $Configuration --nologo -v minimal }
}

function AssemblyInfo {
    Invoke-Execute {
        $assembly_version = "$Version.$BuildCounter"

        Invoke-RegenerateFile "$solutionRoot/Directory.Build.props" @"
<Project>
    <!-- This file is generated by the build script. -->
    <PropertyGroup>
        <Product>Ed-Fi AMT</Product>
        <Authors>$maintainers</Authors>
        <Company>$maintainers</Company>
        <Copyright>Copyright © 2016 Ed-Fi Alliance</Copyright>
        <VersionPrefix>$assembly_version</VersionPrefix>
        <VersionSuffix></VersionSuffix>
    </PropertyGroup>
</Project>

"@
    }
}

function Compile {
    Invoke-Execute {
        dotnet --info
        dotnet build $solutionRoot -c $Configuration --nologo

        $outputPath = "$solutionRoot/Ed-Fi-Analytics-Middle-Tier/publish"
        $project = "$solutionRoot/EdFi.AnalyticsMiddleTier.Console"
		
        dotnet publish $project -c $Configuration /p:EnvironmentName=Production -o $outputPath --no-build --nologo
    }
}


function Invoke-Build {
    Write-Host "Building Version $Version" -ForegroundColor Cyan
    Invoke-Step { Clean }
    Invoke-Step { AssemblyInfo }
    Invoke-Step { Compile }
}

function Invoke-Clean {
    Invoke-Step { Clean }
}


Invoke-Main {
    switch ($Command) {
        Clean { Invoke-Clean }
        Build { Invoke-Build }
        default { throw "Command '$Command' is not recognized" }
    }
}