# Analytics Middle Tier Sample Scripts

## AMT-DataMart

This script will create a data mart with the views materialized into tables.
Run this with sqlcmd or in SSMS with "sqlcmd mode" turned on. Adjust the two 
variables on line 16 and 17. 

Assumes that the destination database already exists and is on the same server 
as the ODS. Run the script periodically to refresh the data.

> :setvar DataMartDB EdFi_AMT_DataMart
:setvar OdsDb EdFi_Ods_Glendale_v510

AMT-DataMart script contains a final section that is commented out. 
Uncomment it when you need to combine the data from 2 different Ods sources. 
Additionally you have to set the SecondOdsDb variable. 

> :setvar SecondOdsDb EdFi_Ods_Northridge_v510

