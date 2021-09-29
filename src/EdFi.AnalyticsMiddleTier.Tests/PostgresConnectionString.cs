namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class PostsgreConnectionStringDS32 : PostgresConnectionString
    {
        public override string ToString()
        {
            if (UseDefaultConnString)
                return "User ID=postgres;Host=localhost;Port=5432;Database=edfi_ods_tests;Pooling=false;";
            else
                return $"User ID={User};Host={Host};Port={Port};Database={Database_ds32};Pooling={Pooling};password={Pass}";
        }
    }

    public abstract class PostgresConnectionString
    {
        protected  DotEnvHelper dotEnvHelper;

        public PostgresConnectionString()
        {
            dotEnvHelper = new DotEnvHelper();
        }

        protected bool UseDefaultConnString => !dotEnvHelper.HasValue("USE_POSTGRES_DEFAULT_CONN_STRING")
                    || dotEnvHelper.Value("USE_POSTGRES_DEFAULT_CONN_STRING").ToLower() == "true";

        protected string Host => dotEnvHelper.Value("POSTGRES_HOST");

        protected string Database_ds32 => dotEnvHelper.Value("POSTGRES_DATABASE");

        protected string Port => dotEnvHelper.Value("POSTGRES_PORT");

        protected string Pooling => dotEnvHelper.Value("POSTGRES_POOLING");

        protected string User => dotEnvHelper.Value("POSTGRES_USER");

        protected string Pass => dotEnvHelper.Value("POSTGRES_PASS");
    }
}
