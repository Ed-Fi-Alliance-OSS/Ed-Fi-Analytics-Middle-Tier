# Solution Architecture

- [Solution Architecture](#solution-architecture)
  - [Projects](#projects)
  - [Naming Conventions](#naming-conventions)
  - [Adding SQL Transitions](#adding-sql-transitions)
  - [Testing](#testing)
  - [Continuous Integration and Publishing](#continuous-integration-and-publishing)

*[Back to main readme](../readme.md)*

## Projects

| Project | Framework | Dependencies | Purpose |
| ------- | --------- | ------------ | ------- |
| `EdFi.AnalyticsMiddleTier.Lib` | .NET 8.0 | DbUp, System.Data.SqlClient | Contains the SQL scripts and DbUp framework for installing them. |
| `EdFi.AnalyticsMiddleTier.Console` | .NET 8.0 | `Lib` project, CommandLineParser | Provides a console interface for executing the `Lib` code |
| `EdFi.AnalyticsMiddleTier.Tests` | .NET 8.0 | `Lib` project, NUnit3, FluentAssertions, DacFx.x64, System.Data.SqlClient | Integration tests that execute the `Lib` code, bypassing the console |

## Naming Conventions

* Names should clearly and simply describe their functionality.
* Suffixes:
  * `-Dimension` applies to views that contain _dimensions_ or _attributes_
    that describe some fact.
  * `-Fact` applies to views that are at the center of a star schema,
    containing keys (linking to Dimension tables) and measures.
  * `-Event` applies to specialized fact views, which record a specific
    _transaction_ rather than recording a _state_.
* Index names should follow the pattern `IX_AMT_<tablename>_<purpose>`. The
  "purpose" might be a key name or the name of a dimension table, for example.

## Adding SQL Transitions

Both new SQL objects _and changes to existing objects_ should go into new
scripts in the `Lib` project's `Scripts` folder. It is critical that changes go
into new scripts, since the migration utility will not re-run existing scripts
unless the user runs the [uninstall](#uninstall) process. Each new file must be
named sequentially. In order for the files to be executed, they must be setup as
[Embedded
Resources](https://codeopinion.com/asp-net-core-csproj-embedded-resources/).

The script naming pattern is straightforward:
`<sequence>-<object type>-<object name>-<action>`.

As described above, the runtime [options](#options) allow the user to choose
whether or not to install any custom indexes. Indexes should only be created if
they make a significant difference in performance of a view. The presence of the
word "Index" in the script name is the trigger of inclusion or exclusion.

## Testing

The primary aim of the test project is to ensure that each script installs
cleanly into a 2.0 standard ODS. Visual Studio will not in itself provide any
compile-time warnings if there is a syntax error in a script, but the migration
will fail at runtime, which we can then catch in the tests. Secondarily, the
test project ensures interface stability by asserting the presence of specific
column names in each view.

Due to the complexity of setting up source data, the tests do not at this time
include any business logic verification.

The project assumes the user has a local SQL Server database. It uses a
2.0-based dacpac to create a new `EdFi_AnalyticsMiddleTier_Testing` database.
When run with the `DEBUG` flag, the framework creates a database snapshot for
faster clean up after each test. Otherwise, the framework fully re-applies the
dacpac for clean up, which is a much longer process (necessary to avoid problems
in the Alliance's CI process).

## Continuous Integration and Publishing

The Ed-Fi Alliance TeamCity server - available only to Alliance staff and
contractors - has several [build
configurations](https://intedfitools1.msdf.org/project.html?projectId=EdFiBuilds_DataAnalytics_AnalyticsMiddleTier&tab=projectOverview)
to support this project:

* Pre-Release
  * Build and Test Pull Request - triggers on creation of a pull request,
    with integration to the pull request. Pull requests are blocked within
    GitHub until they have a clean build.
  * Build and Test Pre-Release - triggers on merge to the `develop` branch.
  * Publish Pre-Release Packages - manually executed for build of the
    [FDD and SCD](https://docs.microsoft.com/en-us/dotnet/core/deploying/)
    binaries, with automatic upload to GitHub as a release with a new
    pre-release tag. Runs from the `develop` branch.
* Release
  * Build and Test Release - triggers on merge to the `master` branch.
  * Publish Release Packages - equivalent to pre-release above, using
    the `master` branch instead.

The PowerShell script `TagAndRelease.ps1` manages the publishing process using
the GitHub API v3.