# Ampla Log Reader

Ampla logs can be spread across WCF, Production Analyst, and Windows Event Logs. Pulling them together when something goes wrong can take time.

Ampla Log Reader helps you review those logs in one place. It creates Excel reports with summaries and detailed records, making it easier to spot errors, track activity, and investigate issues.

## What it reads

- **WCF logs:** call counts, errors, durations, and message activity.
- **Production Analyst remoting logs:** calls between the Ampla Server and Production Analyst clients.
- **Windows Event Logs:** event summaries and details.

## Build and test

Restore the dependencies:

```bash
dotnet restore src/Ampla.LogReader.sln
```

Build the solution:

```bash
dotnet build src/Ampla.LogReader.sln --configuration Release
```

Run the tests:

```bash
dotnet test src/Ampla.LogReader.sln --configuration Release
```

## Run it

Place your project logs under:

```text
%ProgramData%\Citect\Ampla\Projects
```

Then run:

```text
Ampla.LogReader.Console.exe
```

For each project, the tool generates:

```text
{ProjectName}.Wcf.xlsx
{ProjectName}.Remoting.xlsx
```

The tool also creates `EventLog.Details.xlsx` from the local Windows Event Logs, in the app’s current working directory.

## Reports

The Excel workbooks include summary and detail reports for WCF, Event Log, and remoting data.

Depending on the report, you’ll find breakdowns by action, fault, URL, identity, or hour. Reports can include:

- Event and error counts
- Error percentages
- First and last record times
- Total and average durations

Use the summary sheets to spot patterns, then open the detail sheets to investigate specific records.

## Project structure

```text
src/
├── Ampla.LogReader
├── Ampla.LogReader.Console
├── Ampla.LogReader.EventLog.Console
└── Ampla.LogReader.Tests
```

## Modernisation

This fork updates the project with SDK-style .NET projects, GitHub Actions CI, modern NuGet packages, NUnit 3 support, and updated ClosedXML and OpenXML dependencies.
