-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

-- For DS 2.2, the base collection Descriptor Constants all map to Type tables,
-- not Descriptor tables. Therefore only the EWS and RLS collection constants
-- are shown below. See file type-maps.sql for the base collection.

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
            'School Food Services Eligibility Descriptor `',
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
        edfi.SchoolFoodServicesEligibilityDescriptor
    INNER JOIN
        edfi.Descriptor
    ON
        SchoolFoodServicesEligibilityDescriptor.SchoolFoodServicesEligibilityDescriptorId = Descriptor.DescriptorId;



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
     * * Calendar Event
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