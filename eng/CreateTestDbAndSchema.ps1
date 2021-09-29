# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.
param ( [Alias('h')]$pghost="localhost",
		[Alias('u')]$user="postgres",
		[Alias('pwd')]$password,
		[Alias('p')]$port="5432",
		[Alias('d')]$database="edfi_ods_tests",
		[Alias('s')]$script=".\src\EdFi.AnalyticsMiddleTier.Tests\EdFi.Ods.Minimal.Template.sql")
$dropDatabase = "DROP DATABASE IF EXISTS" +" " + $database +";"
$createDatabase = "CREATE DATABASE" +" " + $database +";"

Write-Host "dropping db if it exists"
psql -h $pghost -p $port -U $user -c $dropDatabase
Write-Host "creating db"
psql -h $pghost -p $port -U $user -c $createDatabase
Write-Host "Running migration on db"
psql -d $database -h $pghost -p $port  -U $user -f $script