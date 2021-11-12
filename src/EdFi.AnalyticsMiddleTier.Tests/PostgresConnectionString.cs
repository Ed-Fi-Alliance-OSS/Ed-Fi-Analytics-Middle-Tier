﻿using System;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class PostsgreConnectionStringDS32 : PostgresConnectionString
    {
        public override string ToString()
        {
            if (UseDefaultConnString)
                return "User ID=postgres;Host=localhost;Port=5432;Database=edfi_ods_tests;Pooling=false";
            else
                return $"User ID={User};Host={Host};Port={Port};Database={Database_ds32};Pooling={Pooling};password={Pass}";
        }
    }

    public abstract class PostgresConnectionString : DatabaseConnectionString
    {
        protected PostgresConnectionString() : base() {}

        protected bool UseDefaultConnString => UseDefaultConnectionString("USE_POSTGRES_DEFAULT_CONN_STRING");

        protected string Host => GetEnvironmentVariable("POSTGRES_HOST");

        protected string Database_ds32 => GetEnvironmentVariable("POSTGRES_DATABASE");

        protected string Port => GetEnvironmentVariable("POSTGRES_PORT");

        protected string Pooling => GetEnvironmentVariable("POSTGRES_POOLING");

        protected string User => GetEnvironmentVariable("POSTGRES_USER");

        protected string Pass => GetEnvironmentVariable("POSTGRES_PASS");
    }
}
