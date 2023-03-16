-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF EXISTS
(
    SELECT 
           1
    FROM INFORMATION_SCHEMA.VIEWS
    WHERE TABLE_SCHEMA = 'analytics'
          AND TABLE_NAME = 'StudentSectionDim'
)
    BEGIN
        DROP VIEW 
             analytics.StudentSectionDim;
END;
GO
CREATE VIEW analytics.StudentSectionDim
AS
     SELECT 
            CAST(Student.StudentUniqueId AS NVARCHAR) + '-' + CAST(StudentSectionAssociation.SchoolId AS NVARCHAR) + '-' + StudentSectionAssociation.LocalCourseCode + '-' + CAST(StudentSectionAssociation.SchoolYear AS NVARCHAR) + '-' + StudentSectionAssociation.SectionIdentifier + '-' + StudentSectionAssociation.SessionName + '-' + CONVERT(NVARCHAR, StudentSectionAssociation.BeginDate, 112) AS StudentSectionKey, 
            CAST(Student.StudentUniqueId AS NVARCHAR) + '-' + CAST(StudentSectionAssociation.SchoolId AS NVARCHAR) AS StudentSchoolKey,
            Student.StudentUniqueId AS StudentKey, 
            CAST(StudentSectionAssociation.SchoolId AS NVARCHAR) + '-' + StudentSectionAssociation.LocalCourseCode + '-' + CAST(StudentSectionAssociation.SchoolYear AS NVARCHAR) + '-' + StudentSectionAssociation.SectionIdentifier + '-' + StudentSectionAssociation.SessionName AS SectionKey, 
            StudentSectionAssociation.LocalCourseCode, 
            ISNULL(AcademicSubjectType.Description, '') AS Subject, 
            ISNULL(Course.CourseTitle, '') AS CourseTitle,

            -- There could be multiple teachers for a section - reduce those to a single string.
            -- Unfortunately this means that the Staff and StaffSectionAssociation
            -- LastModifiedDate values can't be used to calculate this record's LastModifiedDate
            ISNULL(STUFF(
     (
         SELECT 
                N', ' + ISNULL(Staff.FirstName, '') + ' ' + ISNULL(Staff.LastSurname, '')
         FROM edfi.StaffSectionAssociation
              LEFT OUTER JOIN edfi.Staff
              ON StaffSectionAssociation.StaffUSI = Staff.StaffUSI
         WHERE StudentSectionAssociation.SchoolId = StaffSectionAssociation.SchoolId
               AND StudentSectionAssociation.LocalCourseCode = StaffSectionAssociation.LocalCourseCode
               AND StudentSectionAssociation.SchoolYear = StaffSectionAssociation.SchoolYear
               AND StudentSectionAssociation.SectionIdentifier = StaffSectionAssociation.SectionIdentifier
               AND StudentSectionAssociation.SessionName = StaffSectionAssociation.SessionName FOR
         XML PATH('')
     ), 1, 1, N''), '') AS TeacherName, 
            CONVERT(NVARCHAR, StudentSectionAssociation.BeginDate, 112) AS StudentSectionStartDateKey, 
            CONVERT(NVARCHAR, StudentSectionAssociation.EndDate, 112) AS StudentSectionEndDateKey, 
            CAST(StudentSectionAssociation.SchoolId AS VARCHAR) AS SchoolKey, 
            CAST(StudentSectionAssociation.SchoolYear AS NVARCHAR) AS SchoolYear,
     (
         SELECT 
                MAX(MaxLastModifiedDate)
         FROM(VALUES(StudentSectionAssociation.LastModifiedDate), (Course.LastModifiedDate), (CourseOffering.LastModifiedDate), (AcademicSubjectType.LastModifiedDate)) AS VALUE(MaxLastModifiedDate)
     ) AS LastModifiedDate
     FROM edfi.StudentSectionAssociation
          INNER JOIN edfi.Student
          ON StudentSectionAssociation.StudentUSI = Student.StudentUSI
          INNER JOIN edfi.CourseOffering
          ON CourseOffering.SchoolId = StudentSectionAssociation.SchoolId
             AND CourseOffering.LocalCourseCode = StudentSectionAssociation.LocalCourseCode
             AND CourseOffering.SchoolYear = StudentSectionAssociation.SchoolYear
             AND CourseOffering.SessionName = StudentSectionAssociation.SessionName
          INNER JOIN edfi.Course
          ON Course.CourseCode = CourseOffering.CourseCode
             AND Course.EducationOrganizationId = CourseOffering.EducationOrganizationId
          LEFT OUTER JOIN edfi.AcademicSubjectDescriptor
          ON AcademicSubjectDescriptor.AcademicSubjectDescriptorId = Course.AcademicSubjectDescriptorId
          LEFT OUTER JOIN edfi.Descriptor AS AcademicSubjectType
          ON AcademicSubjectType.DescriptorId = AcademicSubjectDescriptor.AcademicSubjectDescriptorId;
GO
