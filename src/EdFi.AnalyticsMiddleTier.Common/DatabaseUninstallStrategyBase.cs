// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EdFi.AnalyticsMiddleTier.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class DatabaseUninstallStrategyBase : IUninstallStrategy
    {
        protected IOrm Orm { get; set; }
        protected string AnalyticsSchema = "analytics";
        protected string AnalyticsConfigSchema = "analytics_config";
        protected string SchemaDefault = "dbo";
        protected string JournalingVersionsTable = "AnalyticsMiddleTierSchemaVersion";
        protected string IndexJournalTable = "IndexJournal";
        protected string Ews_LetterGradeTranslation = "ews_LetterGradeTranslation";
        protected string DescriptorConstant = "DescriptorConstant";
        protected string DescriptorMap = "DescriptorMap";
        protected string TypeMap = "TypeMap";

        protected DatabaseUninstallStrategyBase(IOrm orm)
        {
            Orm = orm ?? throw new ArgumentNullException(nameof(orm));
        }

        public virtual (bool Successful, string ErrorMessage) Uninstall()
        {
            return Uninstall(false);
        }

        public virtual (bool Successful, string ErrorMessage) Uninstall(bool uninstallAll)
        {
            try
            {
                RemoveAllViews(AnalyticsSchema);
                RemoveAllViews(AnalyticsConfigSchema);
                RemoveAllIndexes(AnalyticsConfigSchema);
                DropTable(AnalyticsConfigSchema, IndexJournalTable);
                DropTable(AnalyticsConfigSchema, Ews_LetterGradeTranslation);
                DropTable(AnalyticsConfigSchema, TypeMap);
                DropTable(AnalyticsConfigSchema, DescriptorMap);
                DropTable(AnalyticsConfigSchema, DescriptorConstant);
                DropTable(SchemaDefault, JournalingVersionsTable);
                RemoveAllStoredProcedures(AnalyticsConfigSchema);
                RemoveAllFunctions(AnalyticsSchema);
                if (uninstallAll)
                {
                    DropSchema(AnalyticsSchema);
                    DropSchema(AnalyticsConfigSchema);
                }

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.ConcatenateInnerMessages());
            }
        }

        public virtual string GetDropIndexTemplate(string index)
        {
            return $"DROP INDEX IF EXISTS {index};DROP INDEX IF EXISTS {index.ToLower()};";
        }

        public virtual string GetDropSchemaTemplate(string schema)
        {
            return $"DROP SCHEMA IF EXISTS {schema};DROP SCHEMA IF EXISTS {schema.ToLower()};";
        }

        public virtual string GetDropStoredProceduresTemplate(string schema, string storedProcedure)
        {
            return $"DROP PROCEDURE IF EXISTS {schema}.{storedProcedure};DROP PROCEDURE IF EXISTS {schema.ToLower()}.{storedProcedure.ToLower()};";
        }

        public virtual string GetDropTableTemplate(string schema, string table)
        {
            return $"DROP TABLE IF EXISTS {schema}.{table};DROP TABLE IF EXISTS {schema.ToLower()}.{table.ToLower()}";
        }

        public virtual string GetDropTableCascadeTemplate(string schema, string table)
        {
            return $"DROP TABLE IF EXISTS {schema}.{table} Cascade;DROP TABLE IF EXISTS {schema.ToLower()}.{table.ToLower()} Cascade;";
        }

        public virtual string GetDropViewsTemplate(string schema, string view)
        {
            return $"DROP VIEW IF EXISTS {schema}.{view};DROP VIEW IF EXISTS {schema.ToLower()}.{view.ToLower()};";
        }

        public virtual string GetDropFunctionTemplate(string schema, string function)
        {
            return $"DROP FUNCTION IF EXISTS {schema}.{function};DROP FUNCTION IF EXISTS {schema.ToLower()}.{function.ToLower()};";
        }

        public virtual string GetQueryIndexesTemplate(string schema)
        {
            return $"IF (SELECT OBJECT_ID('[{schema.ToLower()}].[IndexJournal]')) IS NOT NULL"
                  + " BEGIN "
                  + $" SELECT FullyQualifiedIndexName FROM {schema.ToLower()}.IndexJournal"
                  + " END;";
        }

        public virtual string GetQueryStoredProceduresTemplate(string schema)
        {
            return $"SELECT ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA =  '{schema.ToLower()}'";
        }

        public virtual string GetQueryViewsTemplate(string schema)
        {
            return $"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = '{schema.ToLower()}'";
        }

        public virtual string GetQueryTablesTemplate(string schema)
        {
            return $"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{schema.ToLower()}'";
        }

        public virtual string GetQueryFunctionsTemplate(string schema)
        {
            return $"SELECT SPECIFIC_NAME FROM INFORMATION_SCHEMA.ROUTINES where ROUTINE_TYPE = 'FUNCTION' AND SPECIFIC_SCHEMA = '{schema.ToLower()}'";
        }

        /// <summary>
        /// Remove all indexes in a schema.
        /// </summary>
        /// <param name="schema">Schema to filter.</param>
        public int RemoveAllIndexes(string schema)=> RemoveDbObjectsBySchema(GetQueryIndexesTemplate, GetDropIndexTemplate, schema);

        /// <summary>
        /// Remove all views in a schema.
        /// </summary>
        /// <param name="schema">Schema to filter.</param>
        public int RemoveAllViews(string schema) => RemoveDbObjectsBySchema(GetQueryViewsTemplate, GetDropViewsTemplate, schema);

        /// <summary>
        /// Remove all tables in a schema.
        /// </summary>
        /// <param name="schema">Schema to filter.</param>
        public int RemoveAllTables(string schema) => RemoveDbObjectsBySchema(GetQueryTablesTemplate, GetDropTableCascadeTemplate, schema);

        /// <summary>
        /// Remove all stored procedures in a schema.
        /// </summary>
        /// <param name="schema">Schema to filter.</param>
        public int RemoveAllStoredProcedures(string schema)=> RemoveDbObjectsBySchema(GetQueryStoredProceduresTemplate, GetDropStoredProceduresTemplate, schema);

        /// <summary>
        /// Remove all Functions in a schema.
        /// This applies for Data Stardard 4.0 and 5.0
        /// </summary>
        /// <param name="schema">Schema to filter.</param>
        public int RemoveAllFunctions(string schema) => RemoveDbObjectsBySchema(GetQueryFunctionsTemplate, GetDropFunctionTemplate, schema);

        protected int RemoveDbObjectsBySchema(Func<string, string>queryTemplate, Func<string, string, string>DropTemplate, string schema)
        {
            var dbSchema = schema.ToLower();
            var objectsToDrop = Orm.Query<string>(queryTemplate(dbSchema));
            if ((objectsToDrop?.Count ?? 0) <= 0){ return 0;}
            var sql = String.Join(string.Empty, objectsToDrop.Select(i => (DropTemplate(dbSchema, i))));
            return Orm.Execute(sql);
        }
        protected int RemoveDbObjectsBySchema(Func<string, string> queryTemplate, Func<string, string> DropTemplate, string schema)
        {
            var dbSchema = schema.ToLower();
            var objectsToDrop = Orm.Query<string>(queryTemplate(dbSchema));
            if ((objectsToDrop?.Count ?? 0) <= 0){ return 0;}
            var sql = String.Join(String.Empty, objectsToDrop.Select(i => (DropTemplate(i))));
            return Orm.Execute(sql);
        }

        /// <summary>
        /// Drop a single table.
        /// </summary>
        /// <param name="schema">Scheme to which the table belongs</param>
        /// <param name="tableName">Name of the table to drop</param>
        public int DropTable(string schema, string tableName)
        {
            return Orm.Execute(GetDropTableTemplate(schema, tableName));
        }

        /// <summary>
        /// Drop an schema.
        /// </summary>
        /// <param name="schema">Scheme to which the table belongs</param>
        public int DropSchema(string schema)
        {
            return Orm.Execute(GetDropSchemaTemplate(schema));
        }

        public void Dispose()
        {
            this.Orm?.Dispose();
        }
    }
}
