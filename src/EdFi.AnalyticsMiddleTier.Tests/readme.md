# Analytics Middle Tier Testing

This test package does not test the created SQL Schema in detail. It does,
however, ensure that the migration library executes correctly. Here is how this
project operates:

1. Check to see if the target testing database exists on the localhost default
   database instance.
    1. If not, then create it from the `EdFi_Ods_2.0.dacpac`. This dacpac contains
       all of the `edfi.*` tables from the Data Standard v2.0.
    1. Next, create a database snapshot of the target database, because restoring
       from a snapshot is faster than dropping and recreating the database.
1. Restore the database snapshot.
1. Run the migration utility once.
1. Run individual tests that confirm that each desired analytics middle tier
   database object was created.
    1. If a SQL view has an invalid reference in it, then the deployment of that
       view will fail, and hence a single test with its assertion statement will
       fail. Thus we get schema binding validation through the testing process.
