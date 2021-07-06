-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE analytics.engage_GradeBands (
    BandName VARCHAR(15) NOT NULL,
    LowerBound TINYINT NOT NULL,
    UpperBOund TINYINT NOT NULL,
    CONSTRAINT PK_engage_GradeBands PRIMARY KEY CLUSTERED (BandName ASC)
         WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY];
