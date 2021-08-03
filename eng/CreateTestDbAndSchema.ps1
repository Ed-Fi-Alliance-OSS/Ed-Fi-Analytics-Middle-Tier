# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

$dburl="postgresql://postgres@localhost:5432/postgres"
$data="SELECT datname FROM pg_catalog.pg_database WHERE lower(datname) = lower('EdFi_Ods_Tests');" | psql --csv $dburl | ConvertFrom-Csv
if ($data.datname -eq $null) {
    Write-Host "No db found, creating db first"
    psql -h localhost -p 5432 -U postgres -c "CREATE DATABASE edfi_ods_tests;"
    Write-Host "Running migration on db"
    psql -d edfi_ods_tests -h localhost -p 5432 -U postgres -f .\src\EdFi.AnalyticsMiddleTier.Tests\EdFi.Ods.Minimal.Template.sql
}
else {
    Write-Host "db found, not running script"
}