-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.StudentSectionDim
AS
    SELECT
      CAST(Student.StudentUniqueId AS VARCHAR) || '-' || CAST(StudentSectionAssociation.SchoolId AS VARCHAR) || '-' || StudentSectionAssociation.LocalCourseCode || '-' || CAST(StudentSectionAssociation.SchoolYear AS VARCHAR) || '-' || StudentSectionAssociation.SectionIdentifier || '-' || StudentSectionAssociation.SessionName || '-' || TO_CHAR(StudentSectionAssociation.BeginDate, 'yyyymmdd') AS StudentSectionKey,
      CAST(Student.StudentUniqueId AS VARCHAR) || '-' || CAST(StudentSectionAssociation.SchoolId AS VARCHAR) AS StudentSchoolKey,
      Student.StudentUniqueId AS StudentKey,
      CAST(StudentSectionAssociation.SchoolId AS VARCHAR) || '-' || StudentSectionAssociation.LocalCourseCode || '-' || CAST(StudentSectionAssociation.SchoolYear AS VARCHAR) || '-' || StudentSectionAssociation.SectionIdentifier || '-' || StudentSectionAssociation.SessionName AS SectionKey,
      StudentSectionAssociation.LocalCourseCode,
      COALESCE(AcademicSubjectType.Description, '') AS Subject,
      COALESCE(Course.CourseTitle, '') AS CourseTitle,

      -- There could be multiple teachers for a section - reduce those to a single string.
      -- Unfortunately this means that the Staff and StaffSectionAssociation
      -- LastModifiedDate values can't be used to calculate this record's LastModifiedDate
      COALESCE((SELECT
          STRING_AGG(COALESCE(Staff.FirstName, '') || ' ' || COALESCE(Staff.LastSurname, ''), ', ')
        FROM edfi.StaffSectionAssociation
          LEFT OUTER JOIN edfi.Staff
            ON StaffSectionAssociation.StaffUSI = Staff.StaffUSI
        WHERE StudentSectionAssociation.SchoolId = StaffSectionAssociation.SchoolId
        AND StudentSectionAssociation.LocalCourseCode = StaffSectionAssociation.LocalCourseCode
        AND StudentSectionAssociation.SchoolYear = StaffSectionAssociation.SchoolYear
        AND StudentSectionAssociation.SectionIdentifier = StaffSectionAssociation.SectionIdentifier
        AND StudentSectionAssociation.SessionName = StaffSectionAssociation.SessionName), '') AS TeacherName,
      TO_CHAR(StudentSectionAssociation.BeginDate, 'yyyymmdd') AS StudentSectionStartDateKey,
      TO_CHAR(StudentSectionAssociation.EndDate, 'yyyymmdd') AS StudentSectionEndDateKey,
      CAST(StudentSectionAssociation.SchoolId AS VARCHAR) AS SchoolKey,
      CAST(StudentSectionAssociation.SchoolYear AS VARCHAR) AS SchoolYear,
      (SELECT
          MAX(MaxLastModifiedDate)
        FROM (VALUES (StudentSectionAssociation.LastModifiedDate), (Course.LastModifiedDate), (CourseOffering.LastModifiedDate), (AcademicSubjectType.LastModifiedDate))
        AS VALUE (MaxLastModifiedDate))
      AS LastModifiedDate
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