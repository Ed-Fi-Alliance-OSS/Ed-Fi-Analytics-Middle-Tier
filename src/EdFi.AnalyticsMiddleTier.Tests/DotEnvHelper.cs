using dotenv.net;
using System.Collections.Generic;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class DotEnvHelper
    {
        private IDictionary<string, string> _variables;
        
        public DotEnvHelper()
        {
            if (_variables != null)
                return;
            _variables = DotEnv.Read();
        }

        public string Value(string key)
        {
            return _variables.ContainsKey(key) ? _variables[key] : null;
        }

        public bool HasValue(string key)
        {
            return _variables.ContainsKey(key);
        }
    }
}
