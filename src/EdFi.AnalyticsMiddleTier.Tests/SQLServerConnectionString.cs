namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class SQLServerConnectionStringDS2 : SQLServerConnectionString
    {
        public override string ToString()
        {
            if (UseDefaultConnString)
                return "server=localhost;database=AnalyticsMiddleTier_Testing_Ds2;integrated security=sspi";
            else
                return $"server={Server};database={Database_ds2};integrated security={Integrated_security};User={User};Password={Pass}";
        }

        public string Database
        {
            get
            {
                if (UseDefaultConnString)
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
            if (UseDefaultConnString)
                return "server=localhost;database=AnalyticsMiddleTier_Testing_Ds31;integrated security=sspi";
            else
                return $"server={Server};database={Database_ds31};integrated security={Integrated_security};User={User};Password={Pass}";
        }

        public string Database
        {
            get
            {
                if (UseDefaultConnString)
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
            if (UseDefaultConnString)
                return "server=localhost;database=AnalyticsMiddleTier_Testing_Ds32;integrated security=sspi";
            else
                return $"server={Server};database={Database_ds32};integrated security={Integrated_security};User={User};Password={Pass}";
        }

        public string Database
        {
            get
            {
                if (UseDefaultConnString)
                    return "AnalyticsMiddleTier_Testing_Ds32";
                else
                    return Database_ds32;
            }
        }
    }

    public abstract class SQLServerConnectionString
    {
        protected DotEnvHelper dotEnvHelper;

        public SQLServerConnectionString()
        {
            dotEnvHelper = new DotEnvHelper();
        }

        protected bool UseDefaultConnString => !dotEnvHelper.HasValue("USE_MSSQL_DEFAULT_CONN_STRING")
                    || dotEnvHelper.Value("USE_MSSQL_DEFAULT_CONN_STRING").ToLower() == "true";

        protected string Server => dotEnvHelper.Value("SQLSERVER_SERVER");

        public string Database_ds2 => dotEnvHelper.Value("SQLSERVER_DATABASE_DS2");

        public string Database_ds31 => dotEnvHelper.Value("SQLSERVER_DATABASE_DS31");

        public string Database_ds32 => dotEnvHelper.Value("SQLSERVER_DATABASE_DS32");

        protected string Integrated_security => dotEnvHelper.Value("SQLSERVER_INTEGRATED_SECURITY");

        protected string User => dotEnvHelper.Value("SQLSERVER_USER");

        protected string Pass => dotEnvHelper.Value("SQLSERVER_PASS");
    }
}
