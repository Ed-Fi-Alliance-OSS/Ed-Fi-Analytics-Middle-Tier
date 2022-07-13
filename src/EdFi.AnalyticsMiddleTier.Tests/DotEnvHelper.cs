// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using dotenv.net;
using System.Collections.Generic;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class DotEnvHelper
    {
        private readonly IDictionary<string, string> _variables;

        public DotEnvHelper()
        {
            if (_variables != null)
            {
                return;
            }

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
