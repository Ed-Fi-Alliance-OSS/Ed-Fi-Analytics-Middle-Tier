-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

DROP VIEW IF EXISTS analytics.epp_TermDescriptorDim;

CREATE VIEW analytics.epp_TermDescriptorDim AS

SELECT
	CAST(TermDescriptor.TermDescriptorId AS VARCHAR) AS TermDescriptorKey
	,Descriptor.CodeValue
	,Descriptor.LastModifiedDate
FROM
	edfi.TermDescriptor
	INNER JOIN edfi.Descriptor
		ON TermDescriptor.TermDescriptorId = Descriptor.DescriptorId;