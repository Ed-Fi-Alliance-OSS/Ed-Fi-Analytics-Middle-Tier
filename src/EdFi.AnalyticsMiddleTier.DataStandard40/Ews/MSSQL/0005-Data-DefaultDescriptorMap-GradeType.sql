-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH gradingTypeSemester
     AS (SELECT 
                DescriptorConstant.DescriptorConstantId, 
                d.DescriptorId
         FROM 
              analytics_config.DescriptorConstant
         CROSS JOIN
             ( SELECT 
                      DescriptorId
               FROM 
                    edfi.GradeTypeDescriptor
               INNER JOIN
                   edfi.Descriptor ON
                       GradeTypeDescriptor.GradeTypeDescriptorId = Descriptor.DescriptorId
               WHERE
                       Descriptor.CodeValue = 'Semester'
                       AND Namespace LIKE '%/GradeTypeDescriptor'
             ) AS d
         WHERE
                 DescriptorConstant.ConstantName = 'GradeType.Semester'),
     gradingTypeFinal
     AS (SELECT 
                DescriptorConstant.DescriptorConstantId, 
                d.DescriptorId
         FROM 
              analytics_config.DescriptorConstant
         CROSS JOIN
             ( SELECT 
                      DescriptorId
               FROM 
                    edfi.GradeTypeDescriptor
               INNER JOIN
                   edfi.Descriptor ON
                       GradeTypeDescriptor.GradeTypeDescriptorId = Descriptor.DescriptorId
               WHERE
                       Descriptor.CodeValue = 'Final'
                       AND Namespace LIKE '%/GradeTypeDescriptor'
             ) AS d
         WHERE
                 DescriptorConstant.ConstantName = 'GradeType.Final')
     MERGE INTO analytics_config.DescriptorMap AS Target
     USING
           ( SELECT 
                    *
             FROM 
                  gradingTypeSemester
             UNION ALL
             SELECT 
                    *
             FROM 
                  gradingTypeFinal
           ) AS Source(DescriptorConstantId, DescriptorId)
     ON
             TARGET.DescriptorConstantId = Source.DescriptorConstantId
     WHEN NOT MATCHED BY TARGET
         THEN
           INSERT(
                  DescriptorConstantId, 
                  DescriptorId, 
                  CreateDate)
           VALUES(Source.DescriptorConstantId
,                 Source.DescriptorId
,                 GETDATE()
                 )
     OUTPUT 
            $action, 
            inserted.*;