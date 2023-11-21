-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM pg_roles WHERE rolname = 'analytics_middle_tier') THEN
        CREATE ROLE analytics_middle_tier;
    END IF;
   GRANT SELECT ON all tables in SCHEMA analytics TO analytics_middle_tier;
END
$$;