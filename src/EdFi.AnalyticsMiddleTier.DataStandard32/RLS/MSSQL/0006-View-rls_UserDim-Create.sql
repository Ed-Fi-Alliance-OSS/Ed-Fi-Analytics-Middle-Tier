-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF EXISTS
          ( SELECT
                   1
            FROM
                 INFORMATION_SCHEMA.VIEWS
            WHERE
                TABLE_SCHEMA = 'analytics'
                AND
                TABLE_NAME = 'rls_UserDim'
          )
    BEGIN
        DROP VIEW
             analytics.rls_UserDim;
END;
GO
CREATE VIEW analytics.rls_UserDim
AS
    SELECT
           Staff.StaffUniqueId AS UserKey,
           StaffElectronicMail.ElectronicMailAddress AS UserEmail,
           ( SELECT
                    MAX(MaxLastModifiedDate)
             FROM
                  (VALUES(Staff.LastModifiedDate)
					  -- StaffElectronicMail does not have a LastModifiedDate
					  , (StaffElectronicMail.CreateDate)
					  , (ElectronicMailType.LastModifiedDate)
				  ) AS VALUE(MaxLastModifiedDate)
           ) AS LastModifiedDate
    FROM
         edfi.Staff
    INNER JOIN
        edfi.StaffElectronicMail ON
        Staff.StaffUSI = StaffElectronicMail.StaffUSI
    INNER JOIN
        edfi.Descriptor AS ElectronicMailType ON
        StaffElectronicMail.ElectronicMailTypeDescriptorId = ElectronicMailType.DescriptorId
    INNER JOIN
        analytics_config.DescriptorMap ON
        ElectronicMailType.DescriptorId = DescriptorMap.DescriptorId
    INNER JOIN
        analytics_config.DescriptorConstant ON
        DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
     WHERE
        DescriptorConstant.ConstantName = 'Email.Work';
GO