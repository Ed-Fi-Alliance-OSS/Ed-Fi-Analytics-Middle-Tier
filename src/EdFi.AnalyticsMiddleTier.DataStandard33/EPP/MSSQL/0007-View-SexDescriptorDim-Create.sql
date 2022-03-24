-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('analytics.EPP_SexDescriptorDim') IS NOT NULL
	DROP VIEW analytics.EPP_SexDescriptorDim

GO

CREATE VIEW analytics.EPP_SexDescriptorDim AS

SELECT  CAST(SexDescriptor.SexDescriptorId AS VARCHAR) SexDescriptorKey
    ,Descriptor.CodeValue
    ,Descriptor.LastModifiedDate
FROM edfi.SexDescriptor
INNER JOIN edfi.Descriptor
    ON Descriptor.DescriptorId = SexDescriptor.SexDescriptorId;