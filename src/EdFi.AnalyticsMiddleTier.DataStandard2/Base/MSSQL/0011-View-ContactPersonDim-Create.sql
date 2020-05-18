-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.


IF EXISTS
(
    SELECT 1
    FROM INFORMATION_SCHEMA.VIEWS
    WHERE TABLE_SCHEMA = 'analytics'
          AND TABLE_NAME = 'ContactPersonDim'
)
    BEGIN
        DROP VIEW analytics.ContactPersonDim;
END;
GO
CREATE VIEW analytics.ContactPersonDim
AS
    WITH ParentAddress AS (
        SELECT
            ParentAddress.ParentUSI,
            CONCAT(COALESCE(ParentAddress.StreetNumberName, ''), COALESCE(', ' + ParentAddress.ApartmentRoomSuiteNumber, ''), 
                COALESCE(', ' + ParentAddress.City, ''), COALESCE(' ' + StateAbbreviationType.CodeValue, ''), 
                COALESCE(' ' + ParentAddress.PostalCode, '')) AS Address,
            AddressType.CodeValue AS AddressType,
            DescriptorConstant.ConstantName,
            ParentAddress.CreateDate AS LastModifiedDate
        FROM
            edfi.ParentAddress
        INNER JOIN
            edfi.AddressType
        ON
            ParentAddress.AddressTypeId = AddressType.AddressTypeId
        INNER JOIN
            edfi.StateAbbreviationType
        ON
            ParentAddress.StateAbbreviationTypeId = StateAbbreviationType.StateAbbreviationTypeId
        INNER JOIN
            analytics_config.TypeMap
        ON
            AddressType.AddressTypeId = TypeMap.TypeId
        INNER JOIN
            analytics_config.DescriptorConstant
        ON
            DescriptorConstant.DescriptorConstantId = TypeMap.DescriptorConstantId
        WHERE
            ParentAddress.EndDate IS NULL
    ), ParentTelephone AS (
            SELECT
                ParentTelephone.ParentUSI,
                ParentTelephone.TelephoneNumber,
                TelephoneNumberType.CodeValue AS TelephoneNumberType,
                DescriptorConstant.ConstantName,
                ParentTelephone.CreateDate
            FROM
                edfi.ParentTelephone
            INNER JOIN
                edfi.TelephoneNumberType
            ON
                ParentTelephone.TelephoneNumberTypeId = TelephoneNumberType.TelephoneNumberTypeId
            INNER JOIN
                analytics_config.TypeMap
            ON
                TelephoneNumberType.TelephoneNumberTypeId = TypeMap.TypeId
            INNER JOIN
                analytics_config.DescriptorConstant
            ON
                DescriptorConstant.DescriptorConstantId = TypeMap.DescriptorConstantId
    ), ParentEmail AS (
        SELECT
            ParentElectronicMail.ParentUSI,
            ParentElectronicMail.ElectronicMailAddress,
            ParentElectronicMail.PrimaryEmailAddressIndicator,
            HomeEmailType.CodeValue AS EmailType,
            DescriptorConstant.ConstantName,
            ParentElectronicMail.CreateDate
        FROM
            edfi.ParentElectronicMail
        LEFT OUTER JOIN
            edfi.ElectronicMailType AS HomeEmailType
        ON
            ParentElectronicMail.ElectronicMailTypeId = HomeEmailType.ElectronicMailTypeId
        LEFT JOIN
            analytics_config.TypeMap
        ON
            HomeEmailType.ElectronicMailTypeId = TypeMap.TypeId
        LEFT JOIN
            analytics_config.DescriptorConstant
        ON
            DescriptorConstant.DescriptorConstantId = TypeMap.DescriptorConstantId
    )
    SELECT 
        CONCAT(Parent.ParentUniqueId,'-',Student.StudentUniqueId) AS UniqueKey,
        Parent.ParentUniqueId AS ContactPersonKey,
        Student.StudentUniqueId AS StudentKey,
        Parent.FirstName AS ContactFirstName,
        Parent.LastSurname AS ContactLastName,
        RelationType.CodeValue AS RelationshipToStudent,
        COALESCE(HomeAddress.Address, '') AS ContactHomeAddress,
        COALESCE(PhysicalAddress.Address, '') AS ContactPhysicalAddress,
        COALESCE(MailingAddress.Address, '') AS ContactMailingAddress,
        COALESCE(WorkAddress.Address, '') AS ContactWorkAddress,
        COALESCE(TemporaryAddress.Address, '') AS ContactTemporaryAddress,
        COALESCE(HomeTelephone.TelephoneNumber, '') AS HomePhoneNumber,
        COALESCE(MobileTelephone.TelephoneNumber, '') AS MobilePhoneNumber,
        COALESCE(WorkTelephone.TelephoneNumber, '') AS WorkPhoneNumber,
        CASE
            WHEN HomeEmail.PrimaryEmailAddressIndicator = 1
            THEN 'Personal'
            WHEN WorkEmail.PrimaryEmailAddressIndicator = 1
            THEN 'Work'
            ELSE 'Not specified'
        END AS PrimaryEmailAddress,
        COALESCE(HomeEmail.ElectronicMailAddress, '') AS PersonalEmailAddress,
        COALESCE(WorkEmail.ElectronicMailAddress, '') AS WorkEmailAddress,
        COALESCE(StudentParentAssociation.PrimaryContactStatus, CAST(0 as BIT)) AS IsPrimaryContact,
        COALESCE(StudentParentAssociation.LivesWith, CAST(0 as BIT)) AS StudentLivesWith,
        COALESCE(StudentParentAssociation.EmergencyContactStatus, CAST(0 as BIT)) AS IsEmergencyContact,
        COALESCE(StudentParentAssociation.ContactPriority, 0) AS ContactPriority,
        COALESCE(StudentParentAssociation.ContactRestrictions, '') AS ContactRestrictions,
        (
            SELECT MAX(MaxLastModifiedDate)
            FROM(VALUES(StudentParentAssociation.LastModifiedDate), (Parent.LastModifiedDate), (HomeAddress.LastModifiedDate),
                (PhysicalAddress.LastModifiedDate), (MailingAddress.LastModifiedDate), (WorkAddress.LastModifiedDate), 
                (TemporaryAddress.LastModifiedDate), (HomeTelephone.CreateDate), (MobileTelephone.CreateDate), 
                (WorkTelephone.CreateDate), (HomeEmail.CreateDate), (WorkEmail.CreateDate)) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
    FROM 
        edfi.StudentParentAssociation
    INNER JOIN
        edfi.Student
    ON
        StudentParentAssociation.StudentUSI = Student.StudentUSI
    INNER JOIN
        edfi.Parent
    ON
        StudentParentAssociation.ParentUSI = Parent.ParentUSI
    INNER JOIN
        edfi.RelationType
    ON
        StudentParentAssociation.RelationTypeId = RelationType.RelationTypeId
    LEFT OUTER JOIN
        ParentAddress AS HomeAddress
    ON 
        Parent.ParentUSI = HomeAddress.ParentUSI
    AND
        HomeAddress.ConstantName = 'Address.Home'
    LEFT OUTER JOIN
        ParentAddress AS PhysicalAddress
    ON
        Parent.ParentUSI = PhysicalAddress.ParentUSI
    AND
        PhysicalAddress.ConstantName = 'Address.Physical'
    LEFT OUTER JOIN
        ParentAddress AS MailingAddress
    ON 
        Parent.ParentUSI = MailingAddress.ParentUSI
    AND
        MailingAddress.ConstantName = 'Address.Mailing'
    LEFT OUTER JOIN
        ParentAddress AS WorkAddress
    ON
        Parent.ParentUSI = WorkAddress.ParentUSI
    AND
        WorkAddress.ConstantName = 'Address.Work'
    LEFT OUTER JOIN
        ParentAddress AS TemporaryAddress
    ON
        Parent.ParentUSI = TemporaryAddress.ParentUSI
    AND
        TemporaryAddress.ConstantName = 'Address.Temporary'
    LEFT OUTER JOIN
        ParentTelephone AS HomeTelephone
    ON
        Parent.ParentUSI = HomeTelephone.ParentUSI
    AND
        HomeTelephone.ConstantName = 'Telephone.Home'
    LEFT OUTER JOIN
        ParentTelephone AS MobileTelephone
    ON
        Parent.ParentUSI = MobileTelephone.ParentUSI
    AND
        MobileTelephone.ConstantName = 'Telephone.Mobile'
    LEFT OUTER JOIN
        ParentTelephone AS WorkTelephone
    ON
        Parent.ParentUSI = WorkTelephone.ParentUSI
    AND
        WorkTelephone.ConstantName = 'Telephone.Work'
    LEFT OUTER JOIN
        ParentEmail AS HomeEmail
    ON
        Parent.ParentUSI = HomeEmail.ParentUSI
    AND
        HomeEmail.ConstantName = 'Email.Personal'
    LEFT OUTER JOIN
        ParentEmail AS WorkEmail
    ON
        Parent.ParentUSI = WorkEmail.ParentUSI
    AND
        WorkEmail.ConstantName = 'Email.Work';
GO