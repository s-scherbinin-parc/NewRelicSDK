﻿using NewRelic.Platform.Sdk.Binding;

namespace NewRelic.Platform.Sdk.UnitTests
{
    internal class MockContext : IContext
    {
        public string Version { get { return "1.0.0"; } set { } }

        public RequestData RequestData { get; set; }

        public MockContext()
        {
            this.RequestData = new RequestData();
        }

        public void ReportMetric(string guid, string componentName, string metricName, string units, float? value)
        {
            this.RequestData.AddMetric(guid, componentName, metricName, units, value.Value);
        }

        public void ReportMetric(string guid, string componentName, string metricName, string units, float value, int count, float min, float max, float sumOfSquares)
        {
            this.RequestData.AddMetric(guid, componentName, metricName, units, value, count, min, max, sumOfSquares);
        }

        public void SendMetricsToService()
        {
            this.RequestData.Reset();
        }
    }
}
