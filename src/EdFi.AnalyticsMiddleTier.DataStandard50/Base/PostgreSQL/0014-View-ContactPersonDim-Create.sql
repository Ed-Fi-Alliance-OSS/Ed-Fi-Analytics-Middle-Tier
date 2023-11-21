-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

CREATE VIEW analytics.ContactPersonDim AS
    WITH ContactAddress AS (
            SELECT ContactAddress.ContactUSI
                ,CONCAT (
                    COALESCE(ContactAddress.StreetNumberName, '')
                    ,COALESCE(', ' || ContactAddress.ApartmentRoomSuiteNumber, '')
                    ,COALESCE(', ' || ContactAddress.City, '')
                    ,COALESCE(' ' || StateAbbreviationType.CodeValue, '')
                    ,COALESCE(' ' || ContactAddress.PostalCode, '')
                    ) AS Address
                ,AddressType.CodeValue AS AddressType
                ,DescriptorConstant.ConstantName
                ,ContactAddress.CreateDate AS LastModifiedDate
                ,COALESCE(ContactAddress.PostalCode, '') AS PostalCode
            FROM edfi.ContactAddress
            INNER JOIN edfi.Descriptor AS AddressType
                ON ContactAddress.AddressTypeDescriptorId = AddressType.DescriptorId
            INNER JOIN analytics_config.DescriptorMap
                ON AddressType.DescriptorId = DescriptorMap.DescriptorId
            INNER JOIN analytics_config.DescriptorConstant
                ON DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
            -- Contact Address does not require a record in Contact Address Period. But if there is one, make sure
            -- that an end date has not been set or is in the future
            LEFT OUTER JOIN edfi.ContactAddressPeriod
                ON ContactAddress.AddressTypeDescriptorId = ContactAddressPeriod.AddressTypeDescriptorId
                    AND ContactAddress.ContactUSI = ContactAddressPeriod.ContactUSI
            INNER JOIN edfi.Descriptor AS StateAbbreviationType
                ON ContactAddress.StateAbbreviationDescriptorId = StateAbbreviationType.DescriptorId
            WHERE ContactAddressPeriod.EndDate IS NULL
                OR ContactAddressPeriod.EndDate > now()
            )
        ,ContactTelephone AS (
            SELECT ContactTelephone.ContactUSI
                ,ContactTelephone.TelephoneNumber
                ,TelephoneNumberType.CodeValue AS TelephoneNumberType
                ,DescriptorConstant.ConstantName
                ,ContactTelephone.CreateDate
            FROM edfi.ContactTelephone
            INNER JOIN edfi.Descriptor AS TelephoneNumberType
                ON ContactTelephone.TelephoneNumberTypeDescriptorId = TelephoneNumberType.DescriptorId
            INNER JOIN analytics_config.DescriptorMap
                ON TelephoneNumberType.DescriptorId = DescriptorMap.DescriptorId
            INNER JOIN analytics_config.DescriptorConstant
                ON DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
            )
        ,ContactEmail AS (
            SELECT ContactElectronicMail.ContactUSI
                ,ContactElectronicMail.ElectronicMailAddress
                ,ContactElectronicMail.PrimaryEmailAddressIndicator
                ,HomeEmailType.CodeValue AS EmailType
                ,DescriptorConstant.ConstantName
                ,ContactElectronicMail.CreateDate
            FROM edfi.ContactElectronicMail
            LEFT OUTER JOIN edfi.Descriptor AS HomeEmailType
                ON ContactElectronicMail.ElectronicMailTypeDescriptorId = HomeEmailType.DescriptorId
            LEFT JOIN analytics_config.DescriptorMap
                ON HomeEmailType.DescriptorId = DescriptorMap.DescriptorId
            LEFT JOIN analytics_config.DescriptorConstant
                ON DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
            )

SELECT CONCAT (
        Contact.ContactUniqueId
        ,'-'
        ,Student.StudentUniqueId
        ) AS UniqueKey
    ,Contact.ContactUniqueId AS ContactPersonKey
    ,Student.StudentUniqueId AS StudentKey
    ,Contact.FirstName AS ContactFirstName
    ,Contact.LastSurname AS ContactLastName
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
    ,COALESCE(StudentContactAssociation.PrimaryContactStatus, false) AS IsPrimaryContact
    ,COALESCE(StudentContactAssociation.LivesWith, false) AS StudentLivesWith
    ,COALESCE(StudentContactAssociation.EmergencyContactStatus, false) AS IsEmergencyContact
    ,COALESCE(StudentContactAssociation.ContactPriority, 0) AS ContactPriority
    ,COALESCE(StudentContactAssociation.ContactRestrictions, '') AS ContactRestrictions
    ,(
        SELECT MAX(MaxLastModifiedDate)
        FROM (
            VALUES (StudentContactAssociation.LastModifiedDate)
                ,(Contact.LastModifiedDate)
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
FROM edfi.StudentContactAssociation
INNER JOIN edfi.Student
    ON StudentContactAssociation.StudentUSI = edfi.Student.StudentUSI
INNER JOIN edfi.Contact
    ON StudentContactAssociation.ContactUSI = Contact.ContactUSI
INNER JOIN edfi.Descriptor AS RelationType
    ON StudentContactAssociation.RelationDescriptorId = RelationType.DescriptorId
LEFT OUTER JOIN ContactAddress AS HomeAddress
    ON Contact.ContactUSI = HomeAddress.ContactUSI
        AND HomeAddress.ConstantName = 'Address.Home'
LEFT OUTER JOIN ContactAddress AS PhysicalAddress
    ON Contact.ContactUSI = PhysicalAddress.ContactUSI
        AND PhysicalAddress.ConstantName = 'Address.Physical'
LEFT OUTER JOIN ContactAddress AS MailingAddress
    ON Contact.ContactUSI = MailingAddress.ContactUSI
        AND MailingAddress.ConstantName = 'Address.Mailing'
LEFT OUTER JOIN ContactAddress AS WorkAddress
    ON Contact.ContactUSI = WorkAddress.ContactUSI
        AND WorkAddress.ConstantName = 'Address.Work'
LEFT OUTER JOIN ContactAddress AS TemporaryAddress
    ON Contact.ContactUSI = TemporaryAddress.ContactUSI
        AND TemporaryAddress.ConstantName = 'Address.Temporary'
LEFT OUTER JOIN ContactTelephone AS HomeTelephone
    ON Contact.ContactUSI = HomeTelephone.ContactUSI
        AND HomeTelephone.ConstantName = 'Telephone.Home'
LEFT OUTER JOIN ContactTelephone AS MobileTelephone
    ON Contact.ContactUSI = MobileTelephone.ContactUSI
        AND MobileTelephone.ConstantName = 'Telephone.Mobile'
LEFT OUTER JOIN ContactTelephone AS WorkTelephone
    ON Contact.ContactUSI = WorkTelephone.ContactUSI
        AND WorkTelephone.ConstantName = 'Telephone.Work'
LEFT OUTER JOIN ContactEmail AS HomeEmail
    ON Contact.ContactUSI = HomeEmail.ContactUSI
        AND HomeEmail.ConstantName = 'Email.Personal'
LEFT OUTER JOIN ContactEmail AS WorkEmail
    ON Contact.ContactUSI = WorkEmail.ContactUSI
        AND WorkEmail.ConstantName = 'Email.Work';
