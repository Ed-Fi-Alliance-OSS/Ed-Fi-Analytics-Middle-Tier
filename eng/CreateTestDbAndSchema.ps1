# SPDX-License-Identifier: Apache-2.0
# Licensed to the Ed-Fi Alliance under one or more agreements.
# The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
# See the LICENSE and NOTICES files in the project root for more information.

Write-Host "dropping db if it exists"
psql -h localhost -p 5432 -U postgres -c "DROP DATABASE IF EXISTS edfi_ods_tests;"
Write-Host "creating db"
psql -h localhost -p 5432 -U postgres -c "CREATE DATABASE edfi_ods_tests;"
Write-Host "Running migration on db"
psql -d edfi_ods_tests -h localhost -p 5432 -U postgres -f .\src\EdFi.AnalyticsMiddleTier.Tests\EdFi.Ods.Minimal.Template.sql