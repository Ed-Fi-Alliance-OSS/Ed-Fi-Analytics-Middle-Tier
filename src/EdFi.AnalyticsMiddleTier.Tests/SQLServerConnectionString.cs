namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class SQLServerConnectionStringDS2 : SQLServerConnectionString
    {
        public override string ToString()
        {
            return $"server={Server};database={Database_ds2};integrated security={Integrated_security};User={User};Password={Pass}";
        }
    }

    public class SQLServerConnectionStringDS31 : SQLServerConnectionString
    {
        public override string ToString()
        {
            return $"server={Server};database={Database_ds31};integrated security={Integrated_security};User={User};Password={Pass}";
        }
    }

    public class SQLServerConnectionStringDS32 : SQLServerConnectionString
    {
        public override string ToString()
        {
            return $"server={Server};database={Database_ds32};integrated security={Integrated_security};User={User};Password={Pass}";
        }
    }

    public abstract class SQLServerConnectionString
    {
        protected string Server => new DotEnvHelper().Value("SQLSERVER_SERVER");

        public string Database_ds2 => new DotEnvHelper().Value("SQLSERVER_DATABASE_DS2");

        public string Database_ds31 => new DotEnvHelper().Value("SQLSERVER_DATABASE_DS31");

        public string Database_ds32 => new DotEnvHelper().Value("SQLSERVER_DATABASE_DS32");

        protected string Integrated_security => new DotEnvHelper().Value("SQLSERVER_INTEGRATED_SECURITY");

        protected string User => new DotEnvHelper().Value("SQLSERVER_USER");

        protected string Pass => new DotEnvHelper().Value("SQLSERVER_PASS");
    }
}
