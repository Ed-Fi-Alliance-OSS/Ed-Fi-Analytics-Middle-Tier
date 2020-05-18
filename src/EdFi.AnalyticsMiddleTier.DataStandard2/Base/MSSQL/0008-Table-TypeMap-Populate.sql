-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH addressHome as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.AddressTypeId,
		'AddressType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			AddressTypeId
		FROM
			edfi.AddressType
		WHERE
			CodeValue = 'Home'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Home'
), addressPhysical as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.AddressTypeId,
		'AddressType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			AddressTypeId
		FROM
			edfi.AddressType
		WHERE
			CodeValue = 'Physical'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Physical'
), addressMailing as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.AddressTypeId,
		'AddressType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			AddressTypeId
		FROM
			edfi.AddressType
		WHERE
			CodeValue = 'Mailing'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Mailing'
), addressWork as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.AddressTypeId,
		'AddressType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			AddressTypeId
		FROM
			edfi.AddressType
		WHERE
			CodeValue = 'Work'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Work'
), addressTemporary as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.AddressTypeId, 
		'AddressType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			AddressTypeId
		FROM
			edfi.AddressType
		WHERE
			CodeValue = 'Temporary'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Temporary'
), telephoneHome as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.TelephoneNumberTypeId, 
		'TelephoneNumberType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			TelephoneNumberTypeId
		FROM
			edfi.TelephoneNumberType
		WHERE
			CodeValue = 'Home'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Telephone.Home'
), telephoneMobile as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.TelephoneNumberTypeId, 
		'TelephoneNumberType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			TelephoneNumberTypeId
		FROM
			edfi.TelephoneNumberType
		WHERE
			CodeValue = 'Mobile'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Telephone.Mobile'
), telephoneWork as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.TelephoneNumberTypeId, 
		'TelephoneNumberType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			TelephoneNumberTypeId
		FROM
			edfi.TelephoneNumberType
		WHERE
			CodeValue = 'Work'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Telephone.Work'
), emailPersonal as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.ElectronicMailTypeId, 
		'ElectronicMailType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			ElectronicMailTypeId
		FROM
			edfi.ElectronicMailType
		WHERE
			CodeValue = 'Home/Personal'
		OR
			CodeValue = 'Home'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Email.Personal'
), emailWork as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.ElectronicMailTypeId, 
		'ElectronicMailType' as TypeTable
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			ElectronicMailTypeId
		FROM
			edfi.ElectronicMailType
		WHERE
			CodeValue = 'Work'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Email.Work'
)
MERGE INTO analytics_config.TypeMap AS Target
USING (
	SELECT * FROM addressHome
	UNION ALL
	SELECT * FROM addressPhysical
	UNION ALL
	SELECT * FROM addressMailing
	UNION ALL
	SELECT * FROM addressWork
	UNION ALL
	SELECT * FROM addressTemporary
	UNION ALL
	SELECT * FROM telephoneHome
	UNION ALL
	SELECT * FROM telephoneMobile
	UNION ALL
	SELECT * FROM telephoneWork
	UNION ALL
	SELECT * FROM emailPersonal
	UNION ALL
	SELECT * FROM emailWork
) AS Source(DescriptorConstantId, TypeId,TypeTable)
ON TARGET.DescriptorConstantId = Source.DescriptorConstantId
    WHEN NOT MATCHED BY TARGET
    THEN
      INSERT
	  (
		DescriptorConstantId, 
		TypeId, 
		TypeTable,
		CreateDate
	  )
      VALUES
      (
        Source.DescriptorConstantId,
        Source.TypeId,
		Source.TypeTable,
        getdate()
      )
OUTPUT $action,
       inserted.*;
