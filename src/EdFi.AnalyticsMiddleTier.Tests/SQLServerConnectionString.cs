using System;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class SQLServerConnectionStringDS2 : SQLServerConnectionString
    {
        public override string ToString()
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
                    return "AnalyticsMiddleTier_Testing_Ds32";
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
    }
}
