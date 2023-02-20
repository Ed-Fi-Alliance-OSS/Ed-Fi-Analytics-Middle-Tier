-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH source AS (VALUES
	('Address.Home'),
	('Address.Physical'),
	('Address.Mailing'),
	('Address.Work'),
	('Address.Temporary'),
	('Telephone.Home'),
	('Telephone.Mobile'),
    ('Telephone.Work'),
    ('Email.Personal'),
    ('Email.Work'),
    ('Foodservice.FullPrice')
)
INSERT INTO 
    analytics_config.DescriptorConstant 
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