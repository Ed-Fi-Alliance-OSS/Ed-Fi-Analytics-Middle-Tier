-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH source AS (VALUES
	('AuthorizationScope.District'),
	('AuthorizationScope.School'),
	('AuthorizationScope.Section')
) 
INSERT INTO 
    analytics_config.descriptorconstant 
(
    ConstantName, 
    CreateDate
)
SELECT 
    source.column1,
    now()
FROM
  source
ON CONFLICT DO NOTHING;
