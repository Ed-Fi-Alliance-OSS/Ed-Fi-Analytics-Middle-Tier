-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


/*
 * This script is optimized for running multiple times, in order to support
 * the uninstall / reinstall process. Uninstall leaves the new tables in 
 * place so that the DBA will not lose any existing scope mappings. However,
 * the journal table is deleted. Thus if you then re-run the migration utility,
 * this script will run it again. The script name will be add to the 
 * re-created journal table, but no error will occur due to the existing
 * table and the existing table's data will be preserved.
 */

IF(SELECT OBJECT_ID('analytics_config.DescriptorConstant')
) IS NULL
    BEGIN
        CREATE TABLE analytics_config.DescriptorConstant
        (DescriptorConstantId INT IDENTITY(1, 1) NOT NULL, 
         ConstantName         VARCHAR(100) NOT NULL, 
         CreateDate           DATETIME NULL
         CONSTRAINT PK_DescriptorConstant PRIMARY KEY CLUSTERED(DescriptorConstantId ASC)
         WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        )
        ON [PRIMARY];
        CREATE UNIQUE NONCLUSTERED INDEX UX_DescriptorConstant_ConstantName
  ON analytics_config.DescriptorConstant
        (ConstantName ASC
        ) WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
  ON [PRIMARY];

END;
GO
