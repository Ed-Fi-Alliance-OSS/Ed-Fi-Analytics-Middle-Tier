-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.ContactPersonDim AS
    WITH ParentAddress AS (
            SELECT ParentAddress.ParentUSI
                ,CONCAT (
                    COALESCE(ParentAddress.StreetNumberName, '')
                    ,COALESCE(', ' || ParentAddress.ApartmentRoomSuiteNumber, '')
                    ,COALESCE(', ' || ParentAddress.City, '')
                    ,COALESCE(' ' || StateAbbreviationType.CodeValue, '')
                    ,COALESCE(' ' || ParentAddress.PostalCode, '')
                    ) AS Address
                ,AddressType.CodeValue AS AddressType
                ,DescriptorConstant.ConstantName
                ,ParentAddress.CreateDate AS LastModifiedDate
                ,COALESCE(ParentAddress.PostalCode, '') AS PostalCode
            FROM edfi.ParentAddress
            INNER JOIN edfi.Descriptor AS AddressType
                ON ParentAddress.AddressTypeDescriptorId = AddressType.DescriptorId
            INNER JOIN analytics_config.DescriptorMap
                ON AddressType.DescriptorId = DescriptorMap.DescriptorId
            INNER JOIN analytics_config.DescriptorConstant
                ON DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
            -- Parent Address does not require a record in Parent Address Period. But if there is one, make sure
            -- that an end date has not been set or is in the future
            LEFT OUTER JOIN edfi.ParentAddressPeriod
                ON ParentAddress.AddressTypeDescriptorId = ParentAddressPeriod.AddressTypeDescriptorId
                    AND ParentAddress.ParentUSI = ParentAddressPeriod.ParentUSI
            INNER JOIN edfi.Descriptor AS StateAbbreviationType
                ON ParentAddress.StateAbbreviationDescriptorId = StateAbbreviationType.DescriptorId
            WHERE ParentAddressPeriod.EndDate IS NULL
                OR ParentAddressPeriod.EndDate > now()
            )
        ,ParentTelephone AS (
            SELECT ParentTelephone.ParentUSI
                ,ParentTelephone.TelephoneNumber
                ,TelephoneNumberType.CodeValue AS TelephoneNumberType
                ,DescriptorConstant.ConstantName
                ,ParentTelephone.CreateDate
            FROM edfi.ParentTelephone
            INNER JOIN edfi.Descriptor AS TelephoneNumberType
                ON ParentTelephone.TelephoneNumberTypeDescriptorId = TelephoneNumberType.DescriptorId
            INNER JOIN analytics_config.DescriptorMap
                ON TelephoneNumberType.DescriptorId = DescriptorMap.DescriptorId
            INNER JOIN analytics_config.DescriptorConstant
                ON DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
            )
        ,ParentEmail AS (
            SELECT ParentElectronicMail.ParentUSI
                ,ParentElectronicMail.ElectronicMailAddress
                ,ParentElectronicMail.PrimaryEmailAddressIndicator
                ,HomeEmailType.CodeValue AS EmailType
                ,DescriptorConstant.ConstantName
                ,ParentElectronicMail.CreateDate
            FROM edfi.ParentElectronicMail
            LEFT OUTER JOIN edfi.Descriptor AS HomeEmailType
                ON ParentElectronicMail.ElectronicMailTypeDescriptorId = HomeEmailType.DescriptorId
            LEFT JOIN analytics_config.DescriptorMap
                ON HomeEmailType.DescriptorId = DescriptorMap.DescriptorId
            LEFT JOIN analytics_config.DescriptorConstant
                ON DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
            )

SELECT CONCAT (
        Parent.ParentUniqueId
        ,'-'
        ,Student.StudentUniqueId
        ) AS UniqueKey
    ,Parent.ParentUniqueId AS ContactPersonKey
    ,Student.StudentUniqueId AS StudentKey
    ,Parent.FirstName AS ContactFirstName
    ,Parent.LastSurname AS ContactLastName
    ,RelationType.CodeValue AS RelationshipToStudent
    ,COALESCE(HomeAddress.Address, '') AS ContactHomeAddress
    ,COALESCE(PhysicalAddress.Address, '') AS ContactPhysicalAddress
    ,COALESCE(MailingAddress.Address, '') AS ContactMailingAddress
    ,COALESCE(WorkAddress.Address, '') AS ContactWorkAddress
    ,COALESCE(TemporaryAddress.Address, '') AS ContactTemporaryAddress
    ,COALESCE(HomeTelephone.TelephoneNumber, '') AS HomePhoneNumber
    ,COALESCE(MobileTelephone.TelephoneNumber, '') AS MobilePhoneNumber
    ,COALESCE(WorkTelephone.TelephoneNumber, '') AS WorkPhoneNumber
    ,CASE 
        WHEN HomeEmail.PrimaryEmailAddressIndicator = TRUE
            THEN 'Personal'
        WHEN WorkEmail.PrimaryEmailAddressIndicator = TRUE
            THEN 'Work'
        ELSE 'Not specified'
        END AS PrimaryEmailAddress
    ,COALESCE(HomeEmail.ElectronicMailAddress, '') AS PersonalEmailAddress
    ,COALESCE(WorkEmail.ElectronicMailAddress, '') AS WorkEmailAddress
    ,COALESCE(StudentParentAssociation.PrimaryContactStatus, false) AS IsPrimaryContact
    ,COALESCE(StudentParentAssociation.LivesWith, false) AS StudentLivesWith
    ,COALESCE(StudentParentAssociation.EmergencyContactStatus, false) AS IsEmergencyContact
    ,COALESCE(StudentParentAssociation.ContactPriority, 0) AS ContactPriority
    ,COALESCE(StudentParentAssociation.ContactRestrictions, '') AS ContactRestrictions
    ,(
        SELECT MAX(MaxLastModifiedDate)
        FROM (
            VALUES (StudentParentAssociation.LastModifiedDate)
                ,(Parent.LastModifiedDate)
                ,(HomeAddress.LastModifiedDate)
                ,(PhysicalAddress.LastModifiedDate)
                ,(MailingAddress.LastModifiedDate)
                ,(WorkAddress.LastModifiedDate)
                ,(TemporaryAddress.LastModifiedDate)
                ,(HomeTelephone.CreateDate)
                ,(MobileTelephone.CreateDate)
                ,(WorkTelephone.CreateDate)
                ,(HomeEmail.CreateDate)
                ,(WorkEmail.CreateDate)
            ) AS VALUE(MaxLastModifiedDate)
        ) AS LastModifiedDate
    ,COALESCE(HomeAddress.PostalCode, '') AS PostalCode
FROM edfi.StudentParentAssociation
INNER JOIN edfi.Student
    ON StudentParentAssociation.StudentUSI = edfi.Student.StudentUSI
INNER JOIN edfi.Parent
    ON StudentParentAssociation.ParentUSI = Parent.ParentUSI
INNER JOIN edfi.Descriptor AS RelationType
    ON StudentParentAssociation.RelationDescriptorId = RelationType.DescriptorId
LEFT OUTER JOIN ParentAddress AS HomeAddress
    ON Parent.ParentUSI = HomeAddress.ParentUSI
        AND HomeAddress.ConstantName = 'Address.Home'
LEFT OUTER JOIN ParentAddress AS PhysicalAddress
    ON Parent.ParentUSI = PhysicalAddress.ParentUSI
        AND PhysicalAddress.ConstantName = 'Address.Physical'
LEFT OUTER JOIN ParentAddress AS MailingAddress
    ON Parent.ParentUSI = MailingAddress.ParentUSI
        AND MailingAddress.ConstantName = 'Address.Mailing'
LEFT OUTER JOIN ParentAddress AS WorkAddress
    ON Parent.ParentUSI = WorkAddress.ParentUSI
        AND WorkAddress.ConstantName = 'Address.Work'
LEFT OUTER JOIN ParentAddress AS TemporaryAddress
    ON Parent.ParentUSI = TemporaryAddress.ParentUSI
        AND TemporaryAddress.ConstantName = 'Address.Temporary'
LEFT OUTER JOIN ParentTelephone AS HomeTelephone
    ON Parent.ParentUSI = HomeTelephone.ParentUSI
        AND HomeTelephone.ConstantName = 'Telephone.Home'
LEFT OUTER JOIN ParentTelephone AS MobileTelephone
    ON Parent.ParentUSI = MobileTelephone.ParentUSI
        AND MobileTelephone.ConstantName = 'Telephone.Mobile'
LEFT OUTER JOIN ParentTelephone AS WorkTelephone
    ON Parent.ParentUSI = WorkTelephone.ParentUSI
        AND WorkTelephone.ConstantName = 'Telephone.Work'
LEFT OUTER JOIN ParentEmail AS HomeEmail
    ON Parent.ParentUSI = HomeEmail.ParentUSI
        AND HomeEmail.ConstantName = 'Email.Personal'
LEFT OUTER JOIN ParentEmail AS WorkEmail
    ON Parent.ParentUSI = WorkEmail.ParentUSI
        AND WorkEmail.ConstantName = 'Email.Work';
