-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

WITH addressHome as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.AddressTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			AddressTypeDescriptor.AddressTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Home'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Home'
), addressPhysical as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.AddressTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			AddressTypeDescriptor.AddressTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Physical'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Physical'
), addressMailing as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.AddressTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			AddressTypeDescriptor.AddressTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Mailing'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Mailing'
), addressWork as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.AddressTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			AddressTypeDescriptor.AddressTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Work'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Work'
), addressTemporary as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.AddressTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			AddressTypeDescriptor.AddressTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Temporary'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Address.Temporary'
), telephoneHome as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.TelephoneNumberTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			TelephoneNumberTypeDescriptor.TelephoneNumberTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Home'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Telephone.Home'
), telephoneMobile as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.TelephoneNumberTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			TelephoneNumberTypeDescriptor.TelephoneNumberTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Mobile'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Telephone.Mobile'
), telephoneWork as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM
			edfi.TelephoneNumberTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			TelephoneNumberTypeDescriptor.TelephoneNumberTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Work'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Telephone.Work'
), emailPersonal as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM		
			edfi.ElectronicMailTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			ElectronicMailTypeDescriptor.ElectronicMailTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Home/Personal'
		OR
			CodeValue = 'Home'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Email.Personal'
), emailWork as (
	SELECT 
		DescriptorConstant.DescriptorConstantId,
		d.DescriptorId
	FROM 
		analytics_config.DescriptorConstant
	CROSS JOIN (
		SELECT 
			DescriptorId
		FROM		
			edfi.ElectronicMailTypeDescriptor
		INNER JOIN
			edfi.Descriptor
		ON
			ElectronicMailTypeDescriptor.ElectronicMailTypeDescriptorId = Descriptor.DescriptorId
		WHERE
			CodeValue = 'Work'
	) as d
	WHERE DescriptorConstant.ConstantName = 'Email.Work'
)
MERGE INTO analytics_config.DescriptorMap AS Target
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
) AS Source(DescriptorConstantId, DescriptorId)
ON TARGET.DescriptorConstantId = Source.DescriptorConstantId
    WHEN NOT MATCHED BY TARGET
    THEN
      INSERT
	  (
		DescriptorConstantId, 
		DescriptorId, 
		CreateDate
	  )
      VALUES
      (
        Source.DescriptorConstantId,
        Source.DescriptorId,
        getdate()
      )
OUTPUT $action,
       inserted.*;
