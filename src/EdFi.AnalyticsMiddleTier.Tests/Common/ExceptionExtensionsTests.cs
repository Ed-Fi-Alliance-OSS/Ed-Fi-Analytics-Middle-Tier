// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.AnalyticsMiddleTier.Common;
using NUnit.Framework;
using Shouldly;
using System;

namespace EdFi.AnalyticsMiddleTier.Tests.Common
{
    [TestFixture]
    [Category("UnitTest")]
    internal class ExceptionExtensionsTests
    {
        private readonly string exceptionMessage = "Exception message";
        private readonly string innerExceptionMessage = "Inner exception message";

        [Test]
        public void Inner_exception_are_concatenated_properly()
        {
            var exception = new Exception(exceptionMessage, new Exception(innerExceptionMessage));
            var message = exception.ConcatenateInnerMessages();

            message.ShouldBe<string>($"{exceptionMessage}{Environment.NewLine}Inner exception: {innerExceptionMessage}");
        }

        [Test]
        public void Null_exception_should_return_empty()
        {
            Exception exception = null;
            var message = exception.ConcatenateInnerMessages();

            message.ShouldBe<string>(string.Empty);
        }
    }
}
