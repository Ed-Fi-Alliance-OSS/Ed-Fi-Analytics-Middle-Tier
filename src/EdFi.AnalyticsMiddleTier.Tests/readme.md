# Analytics Middle Tier Testing

This test package does not test the created SQL Schema in detail. It does,
however, ensure that the migration library executes correctly. Here is how this
project operates:

## For SQL Server:
1. Check to see if the target testing database exists on the localhost default
   database instance.
    1. If not, then create it from the dacpac file for that specific Data
       Standard. There is `EdFi_Ods_2.0.dacpac`, `EdFi_Ods_3.1.dacpac`, and
       `EdFi_Ods_3.2.dacpac` for each Data Standard. These dacpac's contain all
       of the `edfi.*` tables from that specific Data Standard schema.
    2. Next, create a database snapshot of the target database, because
       restoring from a snapshot is faster than dropping and recreating the
       database.
2. Restore the database snapshot.
3. Run the migration utility once.
4. Run individual tests that confirm that each desired analytics middle tier
   database object was created.
    1. If a SQL view has an invalid reference in it, then the deployment of that
       view will fail, and hence a single test with its assertion statement will
       fail. Thus we get schema binding validation through the testing process.

## For Postgres:
The first two steps above are not run for Postgres and instead must be manually
done once, following steps defined [here in
TechDocs](https://techdocs.ed-fi.org/pages/viewpage.action?pageId=98570706). The
remaining steps are the same for running the migration utility and running the
tests.