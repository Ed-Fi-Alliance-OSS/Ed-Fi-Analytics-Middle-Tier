-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE TABLE analytics.engage_GradeBands (
    BandName VARCHAR(15) NOT NULL,
    LowerBound TINYINT NOT NULL,
    UpperBound TINYINT NOT NULL,
    CONSTRAINT PK_engage_GradeBands PRIMARY KEY CLUSTERED (BandName ASC)
         WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
ON [PRIMARY];


INSERT INTO analytics.engage_GradeBands (BandName, LowerBound, UpperBound)
VALUES 
    ('Less than 50%', 0, 50),
    ('50% to 65%', 50, 65),
    ('65% to 70%', 65, 70),
    ('70% to 80%', 70, 80),
    ('80% to 90%', 80, 90),
    ('90% to 100%', 90, 100);
