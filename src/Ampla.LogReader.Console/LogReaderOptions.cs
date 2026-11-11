using CommandLine;

namespace Ampla.LogReader.Console
{
    public class LogReaderOptions
    {
        [Option('w', "wcf", Required = false, HelpText = "Skip the Wcf Log processing")]
        public bool SkipWcf { get; set; } = false;

        [Option('r', "remoting", Required = false, HelpText = "Skip the Remoting Log processing")]
        public bool SkipRemoting { get; set; } = false;

        [Option('e', "eventlog", Required = false, HelpText = "Skip the Event Log processing")]
        public bool SkipEventLog { get; set; } = false;

        [Option('p', "project", Required = false, HelpText = "Select the output files to log")]
        public string Project { get; set; } = "AmplaProject";

        [Option('m', "mode", Required = false, HelpText = "Select the Output mode (Text, Xml, Excel)")]
        public OutputMode OutputMode { get; set; } = OutputMode.Excel;

        [Option('o', "output", Required = false, HelpText = "Select the Output file")]
        public string OutputFile { get; set; }

        [Option('d', "directory", Required = false, HelpText = "Directory where ReplayLogs is found")]
        public string LogDirectory { get; set; }

        [Option('x', "debug", Required = false, HelpText = "Attach the debugger")]
        public bool Debug { get; set; } = false;

        [Option('z', "timezone", HelpText = "TimeZone for local date times")]
        public string TimeZone { get; set; }
    }
}