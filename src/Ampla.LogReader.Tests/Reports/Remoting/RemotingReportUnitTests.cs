using System;
using System.Collections.Generic;
using Ampla.LogReader.Remoting;
using Ampla.LogReader.ReportWriters;
using NUnit.Framework;

namespace Ampla.LogReader.Reports.Remoting
{
    [TestFixture]
    public class RemotingReportUnitTests : TestFixture
    {
        [TestCase(typeof(RemotingSummaryReport))]
        [TestCase(typeof(RemotingIdentitySummaryReport))]
        public void EmptyCalls_DoNotThrow(Type reportType)
        {
            var writer = new SimpleReportWriter();

            dynamic report = Activator.CreateInstance(
                reportType,
                new List<RemotingEntry>(),
                writer);

            report.Render();

            Assert.That(writer.ToString(), Is.Not.Empty);
        }
    }
}