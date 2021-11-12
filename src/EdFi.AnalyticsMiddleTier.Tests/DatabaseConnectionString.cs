using System;
using System.Collections.Generic;
using System.Text;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public abstract class DatabaseConnectionString
    {
        private DotEnvHelper dotEnvHelper;

        protected DatabaseConnectionString()
        {
            dotEnvHelper = new DotEnvHelper();
        }

        protected string GetEnvironmentVariable(string key)
            => ((Environment.GetEnvironmentVariable("GA_USE_GITHUB_ENV", EnvironmentVariableTarget.Process) ?? "false").ToLower().Equals("true"))
                ? Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process) ?? string.Empty
                : dotEnvHelper.Value(key) ?? string.Empty;

        protected bool UseDefaultConnectionString(string key)
        {
            string useDefaultConnectionString = GetEnvironmentVariable(key).ToLower();
            return String.IsNullOrWhiteSpace(useDefaultConnectionString) || useDefaultConnectionString == "true";
        }
    }
}
