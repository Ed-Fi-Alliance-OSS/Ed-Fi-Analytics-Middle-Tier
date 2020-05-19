-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

/*
 * Address
 */

-- Descriptor Constant values
SELECT
    ConstantName
FROM
    analytics_config.DescriptorConstant
WHERE
    ConstantName LIKE 'Address.%'

-- Currently mapped types
SELECT
    CONCAT(
        'Address Type `',
        AddressType.CodeValue,
        '` is mapped to constant `',
        DescriptorConstant.ConstantName,
        '`.'
    )
FROM
    analytics_config.DescriptorConstant
INNER JOIN
    analytics_config.TypeMap
ON
    DescriptorConstant.DescriptorConstantId = TypeMap.DescriptorConstantId
INNER JOIN
    edfi.AddressType
ON
    TypeMap.TypeId = AddressType.AddressTypeId
WHERE
    DescriptorConstant.ConstantName LIKE 'Address.%'
    
-- all types that could be mapped
SELECT 
    AddressTypeId,
    CodeValue,
    ShortDescription,
    Description
FROM
    edfi.AddressType



/*
 * Telelephone Number
 */

-- Descriptor Constant values
SELECT
    ConstantName
FROM
    analytics_config.DescriptorConstant
WHERE
    ConstantName LIKE 'Telephone.%'

-- Currently mapped types
SELECT
    CONCAT(
        'Telephone Type `',
        TelephoneNumberType.CodeValue,
            '` is mapped to Descriptor Constant `',
        DescriptorConstant.ConstantName,
        '`.'
    )
FROM
    analytics_config.DescriptorConstant
INNER JOIN
    analytics_config.TypeMap
ON
    DescriptorConstant.DescriptorConstantId = TypeMap.DescriptorConstantId
INNER JOIN
    edfi.TelephoneNumberType
ON
    TypeMap.TypeId = TelephoneNumberType.TelephoneNumberTypeId
WHERE
    DescriptorConstant.ConstantName LIKE 'Telephone.%'
    
-- all types that could be mapped
SELECT 
    TelephoneNumberTypeId,
    CodeValue,
    ShortDescription,
    Description
FROM
    edfi.TelephoneNumberType;



/*
 * Electronic Mail
 */

-- Descriptor Constant values
SELECT
    ConstantName
FROM
    analytics_config.DescriptorConstant
WHERE
    ConstantName LIKE 'Email.%'

-- Currently mapped types
SELECT
    CONCAT(
        'Electronic Mail Type `',
        ElectronicMailType.CodeValue,
            '` is mapped to Descriptor Constant `',
        DescriptorConstant.ConstantName,
        '`.'
    )
FROM
    analytics_config.DescriptorConstant
INNER JOIN
    analytics_config.TypeMap
ON
    DescriptorConstant.DescriptorConstantId = TypeMap.DescriptorConstantId
INNER JOIN
    edfi.ElectronicMailType
ON
    TypeMap.TypeId = ElectronicMailType.ElectronicMailTypeId
WHERE
    DescriptorConstant.ConstantName LIKE 'Email.%'
    
-- all types that could be mapped
SELECT 
    ElectronicMailTypeId,
    CodeValue,
    ShortDescription,
    Description
FROM
    edfi.ElectronicMailType;



/*
 * EWS Collection
 */
IF EXISTS (
    SELECT
        1
    FROM
        dbo.AnalyticsMiddleTierSchemaVersion
    WHERE
        ScriptName LIKE '%.EWS.%'
)
BEGIN

    /*
     * Grade Type
     */

    -- Descriptor Constant values
    SELECT
        ConstantName
    FROM
        analytics_config.DescriptorConstant
    WHERE
        ConstantName LIKE 'GradeType.%'

    -- Currently mapped types
    SELECT
        CONCAT(
            'Grade Type `',
            GradeType.CodeValue,
            '` is mapped to Descriptor Constant `',
            DescriptorConstant.ConstantName,
            '`.'
        )
    FROM
        analytics_config.DescriptorConstant
    INNER JOIN
        analytics_config.TypeMap
    ON
        DescriptorConstant.DescriptorConstantId = TypeMap.DescriptorConstantId
    INNER JOIN
        edfi.GradeType
    ON
        TypeMap.TypeId = GradeType.GradeTypeId
    WHERE
        DescriptorConstant.ConstantName LIKE 'GradeType.%'
    
    -- all types that could be mapped
    SELECT 
        GradeTypeId,
        CodeValue,
        ShortDescription,
        Description
    FROM
        edfi.GradeType;

END;