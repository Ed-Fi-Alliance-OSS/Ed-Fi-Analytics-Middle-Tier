-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

IF(SELECT OBJECT_ID('edfi.DataLoadScript')
) IS NULL
BEGIN
	CREATE TABLE [edfi].[DataLoadScript](
	[line] [int] IDENTITY(1,1) NOT NULL,
	[statement] [varchar](max) NOT NULL,
 CONSTRAINT [PK_DataLoadScript] PRIMARY KEY CLUSTERED 
(
	[line] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END;
