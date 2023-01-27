// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EdFi.AnalyticsMiddleTier.Common
{
    public abstract class InstallBase
    {
        protected string ConnectionString;
        protected int TimeoutSeconds;
        private readonly IDatabaseMigrationStrategy _databaseMigrationStrategy;
        //Some options require other options to be installed first.
        private readonly List<KeyValuePair<Component, List<Component>>> _componentDependency
            = new List<KeyValuePair<Component, List<Component>>>()
                { (new KeyValuePair<Component, List<Component>>(Component.Qews, new List<Component>(){ Component.RLS, Component.Ews })),
                  (new KeyValuePair<Component, List<Component>>(Component.Equity, new List<Component>(){ Component.Chrab, Component.Ews }))
            };

        protected InstallBase(IDatabaseMigrationStrategy databaseMigrationStrategy)
        {
            _databaseMigrationStrategy = databaseMigrationStrategy ?? throw new ArgumentNullException(nameof(databaseMigrationStrategy));
        }

        public (bool Successful, string ErrorMessage) Run(string connectionString,
            int timeoutSeconds, params Component[] components)
        {
            ConnectionString = connectionString;
            TimeoutSeconds = timeoutSeconds;

            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("connection string cannot be empty", nameof(connectionString));
            }

            try
            {
                RunInstall("Base");
                //Get all components and its dependencies.
                List<Component> componentsToInstall = GetComponentsToInstall(components.ToList());
                componentsToInstall.ForEach(x => { RunInstall(x.ToString()); });
            }
            catch (Exception ex)
            {
                return (false, ex.ConcatenateInnerMessages());
            }
            return (true, string.Empty);
        }

        protected void Install(Assembly assembly, string directoryName)
        {
            var result = _databaseMigrationStrategy.Migrate(assembly, directoryName, ConnectionString, TimeoutSeconds);
            if (!result.Successful)
            {
                throw result.Error;
            }
        }

        protected abstract void RunInstall(string directoryName);

        public List<Component> GetComponentsToInstall(List<Component> components)
        {
            List<Component> componentsToInstall = new List<Component>();
            if (components?.Count > 0)
            {
                foreach (var component in components)
                {
                    if (!componentsToInstall.Contains(component))
                    {
                        var dependencies = _componentDependency.FindAll(x => x.Key == component);

                        List<Component> listDependencies =
                            ((dependencies.Count >= 1) ? dependencies[0].Value : new List<Component>());
                        foreach (var dependency in listDependencies)
                        {
                            componentsToInstall.Remove(dependency);
                            componentsToInstall.Insert(0, dependency);
                        }

                        componentsToInstall.Remove(component);
                        componentsToInstall.Add(component);
                    }
                }
            }

            return componentsToInstall;
        }
    }
}
