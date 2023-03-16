-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

UPDATE analytics_config.DescriptorMap
SET descriptorconstantid=(SELECT descriptorconstantid FROM analytics_config.DescriptorConstant WHERE constantname='GradeType.Final')
WHERE descriptorid=(SELECT descriptorid FROM edfi.Descriptor WHERE namespace='uri://ed-fi.org/GradeTypeDescriptor' AND codevalue='Final')

