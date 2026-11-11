using System;
using System.Collections.Generic;
using Ampla.LogReader.ReportWriters;
using Ampla.LogReader.Wcf;
using NUnit.Framework;

namespace Ampla.LogReader.Reports.Wcf
{
    [TestFixture]
    public class WcfReportUnitTests : TestFixture
    {
        [TestCase(typeof(WcfSummaryReport))]
        [TestCase(typeof(WcfFaultSummaryReport))]
        [TestCase(typeof(WcfActionSummaryReport))]
        [TestCase(typeof(WcfUrlSummaryReport))]
        [TestCase(typeof(WcfHourlySummaryReport))]
        public void EmptyCalls_DoNotThrow(Type reportType)
        {
            var writer = new SimpleReportWriter();

            dynamic report = Activator.CreateInstance(
                reportType,
                new List<WcfCall>(),
                writer);

            report.Render();

            Assert.That(writer.ToString(), Is.Not.Empty);
        }
    }
}