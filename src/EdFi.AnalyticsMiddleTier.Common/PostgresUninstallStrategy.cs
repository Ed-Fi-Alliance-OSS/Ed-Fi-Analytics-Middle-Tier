// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace EdFi.AnalyticsMiddleTier.Common
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PostgresUninstallStrategy : DatabaseUninstallStrategyBase
    {
        public PostgresUninstallStrategy(IOrm orm) : base(orm)
        {
            this.SchemaDefault = "public";
            this.JournalingVersionsTable = $"\"{JournalingVersionsTable}\"";
        }
        public override (bool Successful, string ErrorMessage) Uninstall()
        {
            try
            {
                RemoveAllViews(AnalyticsSchema);
                RemoveAllViews(AnalyticsConfigSchema);
                RemoveAllIndexes(AnalyticsConfigSchema);
                DropTable(AnalyticsConfigSchema, IndexJournalTable);
                DropTable(SchemaDefault, JournalingVersionsTable);
                RemoveAllTables(AnalyticsConfigSchema);
                RemoveAllStoredProcedures(AnalyticsConfigSchema);
                DropSchema(AnalyticsSchema);
                DropSchema(AnalyticsConfigSchema);
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.ConcatenateInnerMessages());
            }
        }
        public override string GetQueryIndexesTemplate(string schema)
        {
            return $"SELECT indexname as FullyQualifiedIndexName FROM pg_indexes WHERE schemaname = '{schema.ToLower()}';";
        }
        public override string GetDropViewsTemplate(string schema, string view)
        {
            return $"DROP VIEW IF EXISTS {schema.ToLower()}.{view.ToLower()} CASCADE;";
        }
    }
}