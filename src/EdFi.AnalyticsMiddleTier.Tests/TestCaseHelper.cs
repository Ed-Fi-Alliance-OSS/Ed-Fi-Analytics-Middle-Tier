// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Dapper;
using Microsoft.XmlDiffPatch;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [XmlRoot(ElementName = "TestCase")]
    public class TestCaseHelper<T> : IDisposable
    {
        [XmlIgnore]
        public IDbConnection Connection { get; set; }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [XmlElement(ElementName = "DBMS")]
        public string DBMS { get; set; }

        [XmlElement(ElementName = "ControlDataInsertion")]
        public List<string> ControlDataInsertion { get; set; }

        [XmlElement(ElementName = "Query")]
        public string Query { get; set; }

        [XmlElement(ElementName = "Result")]
        public List<T> Result { get; set; }

        public (bool success, string errorMessage) RunTestCase()
        {
            var testCaseResult = Connection.Query<T>(this.Query).AsList();
            var areEquals = this.CompareResultsets(testCaseResult);
            return areEquals;
        }
        /// <summary>
        /// This method inserts control data to the database. It takes ControlDataInsertion statements and executes them.
        /// </summary>
        public void LoadControlData()
        {
            if ((this.ControlDataInsertion?.Count ?? 0) > 0)
            {
                string sqlCommand = string.Join(' ', this.ControlDataInsertion);
                if (!String.IsNullOrWhiteSpace(sqlCommand))
                {
                    Connection.Execute(sqlCommand);
                }
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if ( disposing )
            {
                this.Connection?.Dispose();
            }
        }

        private string GetResultXml()
        {
            StringWriter sw = new StringWriter();
            XmlSerializer s = new XmlSerializer(this.Result.GetType());
            s.Serialize(sw, this.Result);
            return sw.ToString();
        }

        private (bool success, string errorMessage) CompareResultsets(List<T> queryResultList)
        {
#pragma warning disable S3265 // Non-flags enums should not be used in bitwise operations. We can't change XmlDiffOptions to fix this
            XmlDiff xmlDiff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder
                                          | XmlDiffOptions.IgnoreNamespaces
                                          | XmlDiffOptions.IgnoreComments
                                          | XmlDiffOptions.IgnorePrefixes
                                          | XmlDiffOptions.IgnoreWhitespace);
            string queryResult = queryResultList.SerializeToXml();
            var nodeControl = XElement.Parse(this.GetResultXml()).CreateReader();
            var nodeDb = XElement.Parse(queryResult).CreateReader();
            var result = new XDocument();
            var writer = result.CreateWriter();
            bool bIdentical = xmlDiff.Compare(nodeControl, nodeDb, writer);
            writer.Flush();
            writer.Close();
            string comparisonResult = !bIdentical
                ? $"The expected data set does not match the one received from the database.{Environment.NewLine}Xml Diff Result:{Environment.NewLine}{(result.Root?.ToString() ?? string.Empty)}"
                : string.Empty;
            return (bIdentical, comparisonResult);
#pragma warning restore S3265
        }
    }
}

