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

CREATE TABLE IF NOT EXISTS analytics_config.DescriptorMap
(DescriptorConstantId INT NOT NULL,
 DescriptorId         INT NOT NULL,
 CreateDate           TIMESTAMP(3) NULL,
 CONSTRAINT PK_DescriptorMap PRIMARY KEY(DescriptorConstantId, DescriptorId),
 CONSTRAINT FK_DescriptorMap_Descriptor FOREIGN KEY(DescriptorId) REFERENCES edfi.Descriptor(
                                                                             DescriptorId),
 CONSTRAINT FK_DescriptorMap_DescriptorConstant FOREIGN KEY(DescriptorConstantId) REFERENCES analytics_config.DescriptorConstant(
                                                                                             DescriptorConstantId)
);