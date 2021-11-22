using System;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class PostsgreConnectionStringDS32 : PostgresConnectionString
    {
        public override string ToString()
        {
            if (UseDefaultConnectionString)
                return "User ID=postgres;Host=localhost;Port=5432;Database=edfi_ods_tests_ds32;Pooling=false";
            else
                return $"User ID={User};Host={Host};Port={Port};Database={Database_ds32};Pooling={Pooling};password={Pass}";
        }
    }

    public class PostsgreConnectionStringDS33 : PostgresConnectionString
    {
        public override string ToString()
        {
            if (UseDefaultConnectionString)
                return "User ID=postgres;Host=localhost;Port=5432;Database=edfi_ods_tests_ds33;Pooling=false";
            else
                return $"User ID={User};Host={Host};Port={Port};Database={Database_ds33};Pooling={Pooling};password={Pass}";
        }
    }

    public abstract class PostgresConnectionString : DatabaseConnectionString
    {
        protected PostgresConnectionString() : base() {}

        public bool UseDefaultConnectionString => UseEnvironmentConnectionString("USE_POSTGRES_DEFAULT_CONN_STRING");

        protected string Host => GetEnvironmentVariable("POSTGRES_HOST");

        protected string Database_ds32 => GetEnvironmentVariable("POSTGRES_DATABASE_DS32");

        protected string Database_ds33 => GetEnvironmentVariable("POSTGRES_DATABASE_DS33");

        protected string Port => GetEnvironmentVariable("POSTGRES_PORT");

        protected string Pooling => GetEnvironmentVariable("POSTGRES_POOLING");

        protected string User => GetEnvironmentVariable("POSTGRES_USER");

        protected string Pass => GetEnvironmentVariable("POSTGRES_PASS");
    }
}
