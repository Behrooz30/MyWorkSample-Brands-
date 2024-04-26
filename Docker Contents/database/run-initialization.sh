# Wait to be sure that SQL Server came up
sleep 90
# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P asdASD123!!! -Q "CREATE DATABASE BrandsDb ON (FILENAME = '/var/opt/mssql/data/BrandsDb.mdf'), (FILENAME = '/var/opt/mssql/data/BrandsDb_log.ldf') FOR ATTACH"
