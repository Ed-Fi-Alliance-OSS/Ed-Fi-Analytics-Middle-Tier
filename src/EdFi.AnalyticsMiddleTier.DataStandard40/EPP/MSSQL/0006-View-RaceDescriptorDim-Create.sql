-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('analytics.epp_RaceDescriptorDim') IS NOT NULL
	DROP VIEW analytics.epp_RaceDescriptorDim
GO

CREATE VIEW analytics.epp_RaceDescriptorDim AS

SELECT
	CAST(RaceDescriptor.RaceDescriptorId AS VARCHAR) RaceDescriptorKey
	,Descriptor.CodeValue
	,Descriptor.LastModifiedDate
FROM
	edfi.RaceDescriptor
INNER JOIN
	edfi.Descriptor 
		ON Descriptor.DescriptorId = RaceDescriptor.RaceDescriptorId