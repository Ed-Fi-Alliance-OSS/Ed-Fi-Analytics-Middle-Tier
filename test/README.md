# Analytics Middle Tier Testing Scripts

This folder contains various scripts, tools, and analysis documents for
large-scale testing of the Analytics Middle Tier. Typically these scripts would
be run manually my a programmer working on exploration or performance tuning.
Automated tests at the "unit" level are included directly in the Analytics
Middle Tier solution, with one exception: the `ENGAGE` collection automated
tests are in the [LMS
Toolkit](https://github.com/Ed-Fi-Alliance-OSS/LMS-Toolkit/tree/main/utils/amt-integration-tests).

## Contents

* docs
  * [Engage Collection Performance Testing](docs/Engage-Collection-Performance.md)
* scripts
  * [export-data.ps1](scripts/export-data.ps1): dumps view contents out to text
    file for simple before/after comparison.
  * [create-data-load](scripts/create-data-load): these scripts aided in creating the
    initial data sets for many of the unit test XML files.
  * [perf-testing-script.ps1](scripts/perf-testing-script.ps1) : can query a list of views in SQL Server and Postgres a user specified number of times (5 by default) and then store average statistics about the number of columns and rows returned along with the execution time it takes to complete each of the queries into a CSV file.
  * [LMS-413-sample-data-for-ENGAGE-collection-on-Northridge.sql](scripts/LMS-413-sample-data-for-ENGAGE-collection-on-Northridge.sql):
    loads additional sample data into a Northridge  database to support
    performance testing of the `ENGAGE` collection (and possibly other).
    * Based on Northridge 5.1.0 with the the LMSX extension and the LMS Toolkit
      installed.
    * About 20,000 students, enrolled in 8 courses per session, with two
      sessions total in the 2017-2018 school year.
    * Randomly-assigned Digital Equity collection data for each student (stored
      in the student's relationship with local education agency)
    * Demographics stored on the student's relationship with the school have
      been copied to the student's relationship with the local education agency,
      so that either `StudentSchoolDim` or `StudentLocalEducationAgencyDim` (and
      their demographic briddges) can be used in testing.
    * In the LMSX extension: one fake assignment per section per week for 36
      weeks; and each student has an assignment submission record for each
      assignment, with psudeo-random assignment statuses.
