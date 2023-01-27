// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.AnalyticsMiddleTier.Common
{
    public static class ExceptionExtensions
    {
        public static string ConcatenateInnerMessages(this Exception outer)
        {
            if (outer == null)
            {
                return string.Empty;
            }

            var message = outer.Message;

            if (outer.InnerException != null)
            {
                message += $"{Environment.NewLine}Inner exception: {outer.InnerException.ConcatenateInnerMessages()}";
            }

            return message;
        }
    }
}
