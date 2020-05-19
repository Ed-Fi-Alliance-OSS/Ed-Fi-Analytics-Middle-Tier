-- SPDX-License-Identifier: Apache-2.0
-- Licensed to the Ed-Fi Alliance under one or more agreements.
-- The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
-- See the LICENSE and NOTICES files in the project root for more information.

/****** Object:  StoredProcedure edfi.GenerateDataLoadScript    Script Date: 3/24/2020 9:24:36 AM ******/
/*
Object: Stored procedure 
Script Date: November 15, 2019
Description: This procedure extracts a row and all the rows that it requires according 
to the foreign keys it has defined, so that it is possible to insert the record 
respecting the referential integrity of the database.
*/

SET ANSI_NULLS ON;
GO 
SET QUOTED_IDENTIFIER ON;
GO
CREATE OR ALTER PROCEDURE edfi.GenerateDataLoadScript
(@OWNER            VARCHAR(MAX) = 'edfi', -- table owner
 @TABLE            VARCHAR(MAX),  -- name of the source table
 @FILTER_CONDITION VARCHAR(MAX) = ''   -- where TableId = 5 or some value
)
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @TABLE_NAME VARCHAR(MAX), @CSV_COLUMN VARCHAR(MAX), @QUOTED_DATA VARCHAR(MAX), @QUOTED_KEY_NAME VARCHAR(MAX), @QUOTED_KEY VARCHAR(MAX), @HAS_IDENTITY BIT, @TEXT VARCHAR(MAX), @FILTER VARCHAR(MAX), @SELECT_FK VARCHAR(MAX);
        SET @TABLE_NAME = @OWNER + '.' + @TABLE;
        SELECT 
               @FILTER = ' ' + @FILTER_CONDITION;

        /***************/

        DECLARE @query AS NVARCHAR(MAX);
        DECLARE @queryResult AS NVARCHAR(MAX);
        DECLARE @queryResultExec AS NVARCHAR(MAX);
        DECLARE db_cursor CURSOR LOCAL
        FOR
            WITH FK_TABLE
                 AS(SELECT 
                           tab.name AS fkTable, 
                           SCHEMA_NAME(tab.schema_id) AS fkTableSchema, 
                           fk.name AS fkName, 
                           pk_tab.name pkTable, 
                           SCHEMA_NAME(pk_tab.schema_id) AS pkTableSchema, 
                           pk_col.name AS primarykeyColumn, 
                           col.name AS fkColName
                    FROM 
                         sys.tables tab
                    INNER JOIN
                        sys.columns col ON
                            col.object_id = tab.object_id
                    LEFT OUTER JOIN
                        sys.foreign_key_columns fk_cols ON
                            fk_cols.parent_object_id = tab.object_id
                            AND
                            fk_cols.parent_column_id = col.column_id
                    LEFT OUTER JOIN
                        sys.foreign_keys fk ON
                            fk.object_id = fk_cols.constraint_object_id
                    LEFT OUTER JOIN
                        sys.tables pk_tab ON
                            pk_tab.object_id = fk_cols.referenced_object_id
                    LEFT OUTER JOIN
                        sys.columns pk_col ON
                            pk_col.column_id = fk_cols.referenced_column_id
                            AND
                            pk_col.object_id = fk_cols.referenced_object_id
                    WHERE
                            tab.name = @table
                            AND pk_col.name IS NOT NULL)
                 -- Recursive script to extract dependency
                 SELECT 
                        'SELECT TOP 1 @queryResult=''EXECUTE  edfi.GenerateDataLoadScript ' + '''' + QUOTENAME(pkTableSchema, '''') + ''',''' + QUOTENAME(pkTable, '''') + ''',' + '''''WHERE ' + REPLACE('**' + STUFF(
                                                                                                                                                                                                                               ( SELECT DISTINCT 
                                                                                                                                                                                                                                        ' AND ' + primarykeyColumn + '''+ ''= ''''''+(QUOTENAME(CAST(' + fkColName + ' AS VARCHAR(max)),''''''''))+' + ''''''' '
                                                                                                                                                                                                                                 FROM 
                                                                                                                                                                                                                                      FK_TABLE
                                                                                                                                                                                                                                 WHERE
                                                                                                                                                                                                                                         fkName = A.fkName FOR
                                                                                                                                                                                                                                 XML PATH('')
                                                                                                                                                                                                                               ), 1, 1, ''), '**AND', ' ') + ' '''''' FROM ' + fkTableSchema + '.' + fkTable + @FILTER
                 FROM 
                      FK_TABLE A
                 GROUP BY 
                          fkName, 
                          fkTableSchema, 
                          pkTableSchema, 
                          pkTable, 
                          fkTable;
        OPEN db_cursor;
        FETCH NEXT FROM db_cursor INTO @SELECT_FK;
        WHILE
                @@FETCH_STATUS = 0
            BEGIN
                SET @query = @SELECT_FK;
                -- Recursive call
                EXECUTE sp_executesql 
                        @query, 
                        N'@queryResult varchar(max) OUTPUT', 
                        @queryResult = @queryResult OUTPUT;
                IF(@queryResult IS NOT NULL)
                    BEGIN
                        EXECUTE sp_executesql 
                                @queryResult;
                END;
                FETCH NEXT FROM db_cursor INTO @SELECT_FK;
            END;
        CLOSE db_cursor;
        DEALLOCATE db_cursor;

        /**********/
        -- Check if it is an identity column
        SELECT 
               @HAS_IDENTITY = 1
        FROM 
             sys.all_columns
        WHERE
                OBJECT_ID = OBJECT_ID(@TABLE_NAME)
                AND is_identity = 1;
        SELECT 
               @HAS_IDENTITY = ISNULL(@HAS_IDENTITY, 0);
        SELECT 
               @CSV_COLUMN = STUFF(
                                    ( SELECT 
                                             ',' + NAME + ''
                                      FROM 
                                           sys.all_columns
                                      WHERE
                                              OBJECT_ID = OBJECT_ID(@TABLE_NAME) FOR
                                      XML PATH('')
                                    ), 1, 1, '');
        SELECT 
               @QUOTED_DATA = STUFF(
                                     ( SELECT 
                                              ' ISNULL(QUOTENAME(' + NAME + ',' + QUOTENAME('''', '''''') + '),' + '''NULL''' + ')+'',''' + '+'
                                       FROM 
                                            sys.all_columns
                                       WHERE
                                               OBJECT_ID = OBJECT_ID(@TABLE_NAME) FOR
                                       XML PATH('')
                                     ), 1, 1, '');
        SELECT 
               @query = 'SELECT @queryResultExec=' + CASE WHEN
                ISNULL(@HAS_IDENTITY, 0) = 1
                                                         THEN '''SET IDENTITY_INSERT ' + @TABLE_NAME + ' ON;'
                                                         ELSE ''' '
                                                     END + 'INSERT INTO ' + @TABLE_NAME + '(' + @CSV_COLUMN + ')' + '(SELECT TOP 1''' + '+' + SUBSTRING(@QUOTED_DATA, 1, LEN(@QUOTED_DATA) - 5) + '+' + ''' ' + ' WHERE NOT EXISTS(' + 'SELECT  1  FROM ' + @TABLE_NAME + '''' + '''' + REPLACE(TRIM(@FILTER), '''', '''''') + '''' + '''' + ')' + ');' + CASE WHEN
                ISNULL(@HAS_IDENTITY, 0) = 1
                                                                                                                                                                                                                                                                                                                                                              THEN 'SET IDENTITY_INSERT ' + @TABLE_NAME + ' OFF;'''
                                                                                                                                                                                                                                                                                                                                                              ELSE ' '''
                                                                                                                                                                                                                                                                                                                                                          END + ' FROM ' + @TABLE_NAME + REPLACE(@FILTER, '''''', '''') + ';';
        EXECUTE sp_executesql 
                @query, 
                N'@queryResultExec varchar(max) OUTPUT', 
                @queryResultExec = @queryResultExec OUTPUT;
        IF(@queryResultExec IS NOT NULL)
            BEGIN
                SET @queryResultExec = REPLACE(REPLACE(@queryResultExec, '''WHERE ', ' WHERE '), '''));', '));');
                INSERT INTO edfi.DataLoadScript
                       (
                       statement
                       )
                ( SELECT 
                         TRIM(@queryResultExec)
                  WHERE NOT EXISTS
                                   ( SELECT 
                                            1
                                     FROM 
                                          edfi.DataLoadScript a
                                     WHERE
                                             a.statement = TRIM(@queryResultExec)
                                   )
                );
        END;
        SET NOCOUNT OFF;
    END;
GO