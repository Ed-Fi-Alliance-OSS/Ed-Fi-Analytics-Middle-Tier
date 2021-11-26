# Analytics Middle Tier Testing

This test package does not test the created SQL Schema in detail. It does,
however, ensure that the migration library executes correctly. Here is how this
project operates:

## For SQL Server:
1. Check to see if the target testing database exists on the localhost default
   database instance.
    1. If not, then create it from the dacpac file for that specific Data
       Standard. There is `EdFi_Ods_2.0.dacpac`, `EdFi_Ods_3.1.dacpac`, `EdFi_Ods_3.2.dacpac`
       and `EdFi_Ods_3.3.dacpac` for each Data Standard. These dacpac's contain all
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

# Alternate Connection Information: 
By way of an env file, the project offers the possibility of setup up alternate connection string information, such as host, database, username, password, etc.
There are a few considerations to make, when using these settings.

### Postgres

Every time a new scenario is executed, the database is reset. Particularly for Postgres this means the project executes a Truncate statement on all the tables in the databases that belong to the schemas `edfi` and `analytics_config`. It’s very important to know this, because whatever data in this database exists, is going to be deleted. 

At this point Postgres has been implemented for Data Standard 3.2 and Data Standard 3.3. This means you must make sure these databases configured contain these data standards.

The databases must exist before the tests can be executed. The tests framework doesn’t create the database for Postgres.

##### The settings

`USE_POSTGRES_DEFAULT_CONN_STRING` = Whether we want to use the default connection string. By default it’s set to `TRUE`. 
This is a very important setting. Internally the project has a hardcoded connection string. If you don’t change this value, then the rest of the settings will be ignored. This is the connection string used internally hardcoded for data standard 3.2: 
`User ID=postgres;Host=localhost;Port=5432;Database=edfi_ods_tests_ds32;Pooling=false;`

And this is the one for data standard 3.3:
`User ID=postgres;Host=localhost;Port=5432;Database=edfi_ods_tests_ds33;Pooling=false;`

`POSTGRES_HOST` = The host to connect to.  
`POSTGRES_DATABASE_DS32` = The PostgreSQL database with Data Standard 3.2 to connect to. Remember, all data here will be deleted.
`POSTGRES_DATABASE_DS33` = The PostgreSQL database with Data Standard 3.3 to connect to. Remember, all data here will be deleted.
`POSTGRES_PORT` = Port used to get connected to Postgres.  
`POSTGRES_USER` = The username to connect with.  
`POSTGRES_PASS` = The password to connect with.  
`POSTGRES_POOLING` = Whether connection pooling should be used.  

### MS SQL

The database reset process works very different for SQL Server. 

When the database configured doesn’t exist, the framework creates it.

To create the databases a dacpac file is used. These files are part of the project. 
Specifically, to reset the database, for SQL Server we use snapshots of the database, instead of executing a truncate on all tables, which is what we do for Postgres. 

##### The settings
`USE_MSSQL_DEFAULT_CONN_STRING` = Whether we want to use the default connection string. By default it’s set to `TRUE`. 
This is a very important setting. Internally the project has a hardcoded connection string. If you don’t change this value, then the rest of the settings will be ignored. This is the connection string used internally hardcoded: 

`server=localhost;database=AnalyticsMiddleTier_Testing_Ds2;integrated security=sspi`

`SQLSERVER_SERVER` = The host to connect to.  
`SQLSERVER_DATABASE_DS2` = The database with Data Standard 2 to connect to.  
`SQLSERVER_DATABASE_DS31` = The database with Data Standard 3.1 to connect to.  
`SQLSERVER_DATABASE_DS32` = The database with Data Standard 3.2 to connect to.  
`SQLSERVER_DATABASE_DS33` = The database with Data Standard 3.3 to connect to.  
`SQLSERVER_INTEGRATED_SECURITY` = The type of user authentication. True corresponds to “Windows Authentication”, and False corresponds to “SQL Server Authentication”;  
`SQLSERVER_USER` = The username to connect with.  
`SQLSERVER_PASS` = The password to connect with.  
