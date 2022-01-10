// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.AnalyticsMiddleTier.Common;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class SqlServerConnectionString : DatabaseConnectionString
    {
        public SqlServerConnectionString(DataStandard dataStandard)
        {
            DatabaseDataStandard = dataStandard;
            DefaultDataBaseName = new Dictionary<DataStandard, string>()
            {
                { DataStandard.Ds2, "AnalyticsMiddleTier_Testing_Ds2" },
                { DataStandard.Ds31, "AnalyticsMiddleTier_Testing_Ds31" },
                { DataStandard.Ds32, "AnalyticsMiddleTier_Testing_Ds32" },
                { DataStandard.Ds33, "AnalyticsMiddleTier_Testing_Ds33" }
            };
            ParameterDataBaseName = new Dictionary<DataStandard, string>()
            {
                { DataStandard.Ds2, "SQLSERVER_DATABASE_DS2" },
                { DataStandard.Ds31, "SQLSERVER_DATABASE_DS31" },
                { DataStandard.Ds32, "SQLSERVER_DATABASE_DS32" },
                { DataStandard.Ds33, "SQLSERVER_DATABASE_DS33" }
            };
            Initialize();
        }
        private void Initialize()
        {
            DatabaseEngine = Engine.MSSQL;

            UseDefaultConnectionString = UseEnvironmentConnectionString("USE_MSSQL_DEFAULT_CONN_STRING");

            Server = GetEnvironmentVariable("SQLSERVER_SERVER");

            IntegratedSecurity = GetEnvironmentVariable("SQLSERVER_INTEGRATED_SECURITY");

            User = GetEnvironmentVariable("SQLSERVER_USER");

            Pass = GetEnvironmentVariable("SQLSERVER_PASS");

            AdminUser = GetEnvironmentVariable("SQLSERVER_ADMIN_USER") ?? "sa";

            AdminUserPass = GetEnvironmentVariable("SQLSERVER_ADMIN_PASS");
        }

        public override string GetMainDatabaseConnectionString()
            => String.Format(GetConnectionStringFormat(), Server, "master", IntegratedSecurity, AdminUser, AdminUserPass);

        public override string GetDatabaseConnectionString()
            => String.Format(GetConnectionStringFormat(), Server, DatabaseName, IntegratedSecurity, User, Pass);

        private string GetConnectionStringFormat()
        {
            var integratedSecurityList = new List<string> { "true", "sspi" };
            bool useIntegratedSecurity = integratedSecurityList
                .Any(s => IntegratedSecurity.ToLower().Contains(s));

            if (UseDefaultConnectionString)
            {
                return "server=localhost;database={1};integrated security=sspi";
            }
            else if (useIntegratedSecurity)
            {
                return "server={0};database={1};integrated security={2};";
            }
            else
            {
                return "server={0};database={1};User={3};Password={4}";
            }
        }
    }

        /* public override string ToString()
         {
             if (UseDefaultConnectionString)
                 return "server=localhost;database=AnalyticsMiddleTier_Testing_Ds2;integrated security=sspi";
             else
                 return $"server={Server};database={Database_ds2};integrated security={Integrated_security};User={User};Password={Pass}";
         }

         public string Database
         {
             get
             {
                 if (UseDefaultConnectionString)
                     return "AnalyticsMiddleTier_Testing_Ds2";
                 else
                     return Database_ds2;
             }
         }
     }

     public class SQLServerConnectionStringDS31 : SQLServerConnectionString
     {
         public override string ToString()
         {
             if (UseDefaultConnectionString)
                 return "server=localhost;database=AnalyticsMiddleTier_Testing_Ds31;integrated security=sspi";
             else
                 return $"server={Server};database={Database_ds31};integrated security={Integrated_security};User={User};Password={Pass}";
         }

         public string Database
         {
             get
             {
                 if (UseDefaultConnectionString)
                     return "AnalyticsMiddleTier_Testing_Ds31";
                 else
                     return Database_ds31;
             }
         }
     }

     public class SQLServerConnectionStringDS32 : SQLServerConnectionString
     {
         public override string ToString()
         {
             if (UseDefaultConnectionString)
                 return "server=localhost;database=AnalyticsMiddleTier_Testing_Ds32;integrated security=sspi";
             else
                 return $"server={Server};database={Database_ds32};integrated security={Integrated_security};User={User};Password={Pass}";
         }

         public string Database
         {
             get
             {
                 if (UseDefaultConnectionString)
                     return "AnalyticsMiddleTier_Testing_Ds32";
                 else
                     return Database_ds32;
             }
         }
     }

     public class SQLServerConnectionStringDS33 : SQLServerConnectionString
     {
         public override string ToString()
         {
             if (UseDefaultConnectionString)
                 return "server=localhost;database=AnalyticsMiddleTier_Testing_Ds33;integrated security=sspi";
             else
                 return $"server={Server};database={Database_ds33};integrated security={Integrated_security};User={User};Password={Pass}";
         }

         public string Database
         {
             get
             {
                 if (UseDefaultConnectionString)
                     return "AnalyticsMiddleTier_Testing_Ds33";
                 else
                     return Database_ds33;
             }
         }
     }

     public abstract class SQLServerConnectionString : DatabaseConnectionString
     {
         protected SQLServerConnectionString() : base() { 
         }

         public bool UseDefaultConnectionString => UseEnvironmentConnectionString("USE_MSSQL_DEFAULT_CONN_STRING");

         protected string Server => GetEnvironmentVariable("SQLSERVER_SERVER");

         public string Database_ds2 => GetEnvironmentVariable("SQLSERVER_DATABASE_DS2");

         public string Database_ds31 => GetEnvironmentVariable("SQLSERVER_DATABASE_DS31");

         public string Database_ds32 => GetEnvironmentVariable("SQLSERVER_DATABASE_DS32");

         public string Database_ds33 => GetEnvironmentVariable("SQLSERVER_DATABASE_DS33");

         protected string Integrated_security => GetEnvironmentVariable("SQLSERVER_INTEGRATED_SECURITY");

         protected string User => GetEnvironmentVariable("SQLSERVER_USER");

         protected string Pass => GetEnvironmentVariable("SQLSERVER_PASS");

         protected string SQL_SA_Pass => GetEnvironmentVariable("SQLSERVER_SA_PASS");

         public override string GetMainDatabaseConnectionString
         {
             get 
             {
                 if (!UseDefaultConnectionString)
                 {
                     string saPassword = SQL_SA_Pass;
                     return $"server=localhost;database=master;integrated security=false;User=sa;Password={SQL_SA_Pass}";
                 }
                 else
                 {
                     return "server=localhost;database=master;integrated security=sspi";
                 }
             }
         }
     }*/
    }
