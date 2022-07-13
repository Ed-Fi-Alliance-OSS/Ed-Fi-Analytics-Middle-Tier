// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public static class TestCaseSerializer
    {
        private const string XmlExtension = ".xml";
        private const string JsonExtension = ".json";

        private static readonly Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();

        public static TestCaseHelper<T> LoadTestCase<T>(string filename)
        {
            if (filename.EndsWith(XmlExtension))
            {
                return LoadTestCaseFromXml<T>(filename);
            }
            else if (filename.EndsWith(JsonExtension))
            {
                return LoadTestCaseFromJson<T>(filename);
            }
            return new TestCaseHelper<T>();
        }

        private static TestCaseHelper<T> LoadTestCaseFromXml<T>(string xmlFilename)
        {
            var resourceName = $"{ExecutingAssembly.GetName().Name}.{xmlFilename}";

            TestCaseHelper<T> returnObject;
            using (var stream = ExecutingAssembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException($"Unable to load resource ${resourceName}");
                }

                XmlSerializer serializer = new XmlSerializer(typeof(TestCaseHelper<T>));
                returnObject = (TestCaseHelper<T>) serializer.Deserialize(stream);
            }
            return returnObject;
        }
        private static TestCaseHelper<T> LoadTestCaseFromJson<T>(string jsonFilename)
        {
            TestCaseHelper<T> returnObject;
            using (var stream = ExecutingAssembly.GetManifestResourceStream($"{ExecutingAssembly.GetName().Name}.{jsonFilename}"))
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(TestCaseHelper<T>));
                returnObject = (TestCaseHelper<T>) js.ReadObject(stream);
            }
            return returnObject;
        }

        public static string SerializeToXml<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            var xmlSerializer = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(writer, value);
                return stringWriter.ToString();
            }
        }
    }
}
