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
        'Address Type Descriptor `',
        Descriptor.CodeValue,
        '` is mapped to Descriptor Constant `',
        DescriptorConstant.ConstantName,
        '`.'
    )
FROM
    analytics_config.DescriptorConstant
INNER JOIN
    analytics_config.DescriptorMap
ON
    DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
INNER JOIN
    edfi.Descriptor
ON
    DescriptorMap.DescriptorId = Descriptor.DescriptorId
WHERE
    DescriptorConstant.ConstantName LIKE 'Address.%'
    
-- all types that could be mapped
SELECT 
    DescriptorId,
    CodeValue,
    ShortDescription,
    Description
FROM
    edfi.AddressTypeDescriptor
INNER JOIN
    edfi.Descriptor
ON
    AddressTypeDescriptor.AddressTypeDescriptorId = Descriptor.DescriptorId;



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
        Descriptor.CodeValue,
            '` is mapped to Descriptor Constant `',
        DescriptorConstant.ConstantName,
        '`.'
    )
FROM
    analytics_config.DescriptorConstant
INNER JOIN
    analytics_config.DescriptorMap
ON
    DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
INNER JOIN
    edfi.Descriptor
ON
    DescriptorMap.DescriptorId = Descriptor.DescriptorId
WHERE
    DescriptorConstant.ConstantName LIKE 'Telephone.%'
    
-- all types that could be mapped
SELECT 
    DescriptorId,
    CodeValue,
    ShortDescription,
    Description
FROM
    edfi.TelephoneNumberTypeDescriptor
INNER JOIN
    edfi.Descriptor
ON
    TelephoneNumberTypeDescriptor.TelephoneNumberTypeDescriptorId = Descriptor.DescriptorId;



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
        Descriptor.CodeValue,
            '` is mapped to Descriptor Constant `',
        DescriptorConstant.ConstantName,
        '`.'
    )
FROM
    analytics_config.DescriptorConstant
INNER JOIN
    analytics_config.DescriptorMap
ON
    DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
INNER JOIN
    edfi.Descriptor
ON
    DescriptorMap.DescriptorId = Descriptor.DescriptorId
WHERE
    DescriptorConstant.ConstantName LIKE 'Email.%'
    
-- all types that could be mapped
SELECT 
    DescriptorId,
    CodeValue,
    ShortDescription,
    Description
FROM
    edfi.ElectronicMailTypeDescriptor
INNER JOIN
    edfi.Descriptor
ON
    ElectronicMailTypeDescriptor.ElectronicMailTypeDescriptorId = Descriptor.DescriptorId;




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
     * Foodservice
     */

    -- Descriptor Constant values
    SELECT
        ConstantName
    FROM
        analytics_config.DescriptorConstant
    WHERE
        ConstantName LIKE 'Foodservice.%'

    -- Currently mapped types
    SELECT
        CONCAT(
            'School Food Services Program Service Descriptor `',
            Descriptor.CodeValue,
            '` is mapped to Descriptor Constant `',
            DescriptorConstant.ConstantName,
            '`.'
        )
    FROM
        analytics_config.DescriptorConstant
    INNER JOIN
        analytics_config.DescriptorMap
    ON
        DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
    INNER JOIN
        edfi.Descriptor
    ON
        DescriptorMap.DescriptorId = Descriptor.DescriptorId
    WHERE
        DescriptorConstant.ConstantName LIKE 'Foodservice.%'
    
    -- all types that could be mapped
    SELECT 
        DescriptorId,
        CodeValue,
        ShortDescription,
        Description
    FROM
        edfi.SchoolFoodServiceProgramServiceDescriptor
    INNER JOIN
        edfi.Descriptor
    ON
        SchoolFoodServiceProgramServiceDescriptor.SchoolFoodServiceProgramServiceDescriptorId = Descriptor.DescriptorId;



    /*
     * Attendance Event
     */

    -- Descriptor Constant values
    SELECT
        ConstantName
    FROM
        analytics_config.DescriptorConstant
    WHERE
        ConstantName LIKE 'AttendanceEvent.%'

    -- Currently mapped types
    SELECT
        CONCAT(
            'Attendance Event Category Descriptor `',
            Descriptor.CodeValue,
            '` is mapped to Descriptor Constant `',
            DescriptorConstant.ConstantName,
            '`.'
        )
    FROM
        analytics_config.DescriptorConstant
    INNER JOIN
        analytics_config.DescriptorMap
    ON
        DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
    INNER JOIN
        edfi.Descriptor
    ON
        DescriptorMap.DescriptorId = Descriptor.DescriptorId
    WHERE
        DescriptorConstant.ConstantName LIKE 'AttendanceEvent.%'
    
    -- all types that could be mapped
    SELECT 
        DescriptorId,
        CodeValue,
        ShortDescription,
        Description
    FROM
        edfi.AttendanceEventCategoryDescriptor
    INNER JOIN
        edfi.Descriptor
    ON
        AttendanceEventCategoryDescriptor.AttendanceEventCategoryDescriptorId = Descriptor.DescriptorId;



    /*
     * Calendar Event
     */

    -- Descriptor Constant values
    SELECT
        ConstantName
    FROM
        analytics_config.DescriptorConstant
    WHERE
        ConstantName LIKE 'CalendarEvent.%'

    -- Currently mapped types
    SELECT
        CONCAT(
            'Calendar Event Descriptor `',
            Descriptor.CodeValue,
            '` is mapped to Descriptor Constant `',
            DescriptorConstant.ConstantName,
            '`.'
        )
    FROM
        analytics_config.DescriptorConstant
    INNER JOIN
        analytics_config.DescriptorMap
    ON
        DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
    INNER JOIN
        edfi.Descriptor
    ON
        DescriptorMap.DescriptorId = Descriptor.DescriptorId
    WHERE
        DescriptorConstant.ConstantName LIKE 'CalendarEvent.%'
    
    -- all types that could be mapped
    SELECT 
        DescriptorId,
        CodeValue,
        ShortDescription,
        Description
    FROM
        edfi.CalendarEventDescriptor
    INNER JOIN
        edfi.Descriptor
    ON
        CalendarEventDescriptor.CalendarEventDescriptorId = Descriptor.DescriptorId;



    /*
     * Behavior
     */

    -- Descriptor Constant values
    SELECT
        ConstantName
    FROM
        analytics_config.DescriptorConstant
    WHERE
        ConstantName LIKE 'Behavior.%'

    -- Currently mapped types
    SELECT
        CONCAT(
            'Behavior Descriptor `',
            Descriptor.CodeValue,
            '` is mapped to Descriptor Constant `',
            DescriptorConstant.ConstantName,
            '`.'
        )
    FROM
        analytics_config.DescriptorConstant
    INNER JOIN
        analytics_config.DescriptorMap
    ON
        DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
    INNER JOIN
        edfi.Descriptor
    ON
        DescriptorMap.DescriptorId = Descriptor.DescriptorId
    WHERE
        DescriptorConstant.ConstantName LIKE 'Behavior.%'
    
    -- all types that could be mapped
    SELECT 
        DescriptorId,
        CodeValue,
        ShortDescription,
        Description
    FROM
        edfi.BehaviorDescriptor
    INNER JOIN
        edfi.Descriptor
    ON
        BehaviorDescriptor.BehaviorDescriptorId = Descriptor.DescriptorId;
        

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
            'Grade Type Descriptor `',
            Descriptor.CodeValue,
            '` is mapped to Descriptor Constant `',
            DescriptorConstant.ConstantName,
            '`.'
        )
    FROM
        analytics_config.DescriptorConstant
    INNER JOIN
        analytics_config.DescriptorMap
    ON
        DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
    INNER JOIN
        edfi.Descriptor
    ON
        DescriptorMap.DescriptorId = Descriptor.DescriptorId
    WHERE
        DescriptorConstant.ConstantName LIKE 'GradeType.%'
    
    -- all types that could be mapped
    SELECT 
        DescriptorId,
        CodeValue,
        ShortDescription,
        Description
    FROM
        edfi.GradeTypeDescriptor
    INNER JOIN
        edfi.Descriptor
    ON
        GradeTypeDescriptor.GradeTypeDescriptorId = Descriptor.DescriptorId;

END;




/*
 * RLS Collection
 */
IF EXISTS (
    SELECT
        1
    FROM
        dbo.AnalyticsMiddleTierSchemaVersion
    WHERE
        ScriptName LIKE '%.RLS.%'
)
BEGIN
    /*
     * Staff classification access scope
     */

    -- Descriptor Constant values
    SELECT
        ConstantName
    FROM
        analytics_config.DescriptorConstant
    WHERE
        ConstantName LIKE 'AuthorizationScope.%'

    -- Currently mapped types
    SELECT
        CONCAT(
            'Staff Classification Descriptor `',
            Descriptor.CodeValue,
            '` is mapped to Descriptor Constant `',
            DescriptorConstant.ConstantName,
            '`.'
        )
    FROM
        analytics_config.DescriptorConstant
    INNER JOIN
        analytics_config.DescriptorMap
    ON
        DescriptorConstant.DescriptorConstantId = DescriptorMap.DescriptorConstantId
    INNER JOIN
        edfi.Descriptor
    ON
        DescriptorMap.DescriptorId = Descriptor.DescriptorId
    WHERE
        DescriptorConstant.ConstantName LIKE 'AuthorizationScope.%'
    
    -- all types that could be mapped
    SELECT 
        DescriptorId,
        CodeValue,
        ShortDescription,
        Description
    FROM
        edfi.StaffClassificationDescriptor
    INNER JOIN
        edfi.Descriptor
    ON
        StaffClassificationDescriptor.StaffClassificationDescriptorId = Descriptor.DescriptorId

END;