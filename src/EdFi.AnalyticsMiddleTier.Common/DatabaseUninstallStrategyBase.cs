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
        
        protected DatabaseUninstallStrategyBase(IOrm orm)
        {
            Orm = orm ?? throw new ArgumentNullException(nameof(orm));
        }

        public virtual (bool Successful, string ErrorMessage) Uninstall()
        {
            try
            {
                RemoveAllViews(AnalyticsSchema);
                RemoveAllViews(AnalyticsConfigSchema);
                RemoveAllIndexes(AnalyticsConfigSchema);
                DropTable(AnalyticsConfigSchema, IndexJournalTable);
                DropTable(SchemaDefault, JournalingVersionsTable);
                RemoveAllStoredProcedures(AnalyticsConfigSchema);
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.ConcatenateInnerMessages());
            }
        }

        public virtual string GetDropIndexTemplate(string index)
        {
            return $"DROP INDEX IF EXISTS {index};";
        }

        public virtual string GetDropStoredProceduresTemplate(string schema, string storedProcedure)
        {
            return $"DROP PROCEDURE IF EXISTS {schema}.{storedProcedure};";
        }

        public virtual string GetDropTableTemplate(string schema, string table)
        {
            return $"DROP TABLE IF EXISTS {schema}.{table};";
        }

        public virtual string GetDropViewsTemplate(string schema, string view)
        {
            return $"DROP VIEW IF EXISTS {schema}.{view};";
        }

        public virtual string GetQueryIndexesTemplate(string schema)
        {
            return $"IF (SELECT OBJECT_ID('[{schema}].[IndexJournal]')) IS NOT NULL"
                  + " BEGIN "
                  + $" SELECT FullyQualifiedIndexName FROM {schema}.IndexJournal"
                  + " END;";
        }

        public virtual string GetQueryStoredProceduresTemplate(string schema)
        {
            return $"SELECT ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_SCHEMA =  '{schema}'";
        }

        public virtual string GetQueryViewsTemplate(string schema)
        {
            return $"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_SCHEMA = '{schema}'";
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
        /// Remove all stored procedures in a schema.
        /// </summary>
        /// <param name="schema">Schema to filter.</param>
        public int RemoveAllStoredProcedures(string schema)=> RemoveDbObjectsBySchema(GetQueryStoredProceduresTemplate, GetDropStoredProceduresTemplate, schema);


        protected int RemoveDbObjectsBySchema(Func<string, string>queryTemplate, Func<string, string, string>DropTemplate, string schema)
        {
            var objectsToDrop = Orm.Query<string>(queryTemplate(schema));
            if ((objectsToDrop?.Count ?? 0) <= 0) return 0;
            var sql = String.Join(string.Empty, objectsToDrop.Select(i => (DropTemplate(schema, i))));
            return Orm.Execute(sql);
        }
        protected int RemoveDbObjectsBySchema(Func<string, string> queryTemplate, Func<string, string> DropTemplate, string schema)
        {
            var objectsToDrop = Orm.Query<string>(queryTemplate(schema));
            if ((objectsToDrop?.Count ?? 0) <= 0) return 0;
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
       
        public void Dispose()
        {
            this.Orm?.Dispose();
        }
    }
}
