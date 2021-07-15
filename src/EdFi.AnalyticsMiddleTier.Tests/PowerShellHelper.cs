using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace EdFi.AnalyticsMiddleTier.Tests
{
    public class PowerShellHelper
    {
        public void DeleteDatabase()
        {
            //RunScript("dropdb -h localhost -p 5432 -U postgres --no-password --if-exists --maintenance-db=EdFi_ODS odstest", null);
        }

        public void CreateDatabase()
        {
            //RunScript("createdb -h localhost -p 5432 -U postgres --no-password --maintenance-db=EdFi_ODS odstest", null);
        }

        public void RestoreDB()
        {
            RunScript("psql --dbname odstest --host localhost --port 5432 --quiet --username postgres --file \"EdFi.Ods.Minimal.Template.sql\"", null);
        }

        /// <summary>
        /// Runs a PowerShell script with parameters
        /// </summary>
        /// <param name="scriptContents">The script file contents.</param>
        /// <param name="scriptParameters">A dictionary of parameter names and parameter values.</param>
        private void RunScript(string scriptContents, Dictionary<string, object> scriptParameters)
        {
            // create a new hosted PowerShell instance using the default runspace.
            // wrap in a using statement to ensure resources are cleaned up.

            using (PowerShell ps = PowerShell.Create())
            {
                // specify the script code to run.
                ps.AddScript(scriptContents);

                if (scriptParameters != null)
                    // specify the parameters to pass into the script.
                    ps.AddParameters(scriptParameters);

                // execute the script
                var pipelineObjects = ps.Invoke();
            }
        }
    }
}
