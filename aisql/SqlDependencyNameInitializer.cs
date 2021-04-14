using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace aisql
{
	public class SqlDependencyNameInitializer : ITelemetryInitializer
	{
		public void Initialize(ITelemetry telemetry)
		{
			if (telemetry is Microsoft.ApplicationInsights.DataContracts.DependencyTelemetry { Type: "SQL" } dependency)
			{
				dependency.Target = "SQL_Target";
				dependency.Name = "SQL_Name";
			}
		}
	}
}