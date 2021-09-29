namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class PostsgreConnectionStringDS32 : PostgresConnectionString
    {
        public override string ToString()
        {
            return $"User ID={User};Host={Host};Port={Port};Database={Database_ds32};Pooling={Pooling};password={Pass}";
        }
    }

    public abstract class PostgresConnectionString
    {
        protected string Host => new DotEnvHelper().Value("POSTGRES_HOST");

        protected string Database_ds32 => new DotEnvHelper().Value("POSTGRES_DATABASE");

        protected string Port => new DotEnvHelper().Value("POSTGRES_PORT");

        protected string Pooling => new DotEnvHelper().Value("POSTGRES_POOLING");

        protected string User => new DotEnvHelper().Value("POSTGRES_USER");

        protected string Pass => new DotEnvHelper().Value("POSTGRES_PASS");
    }
}
