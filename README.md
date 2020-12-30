Setup project:

Step 1 - Restore database:
	Open data\restore_db.bat with any text editor 
	Change mysql variable value to your MySql executable path
	Change password variable value to your MySql password
	Run restore_db.bat

Step 2 - Configure connection strings:
	Edit connection string in appsettings.Development.json
	Edit credentials in log4net.config

Step 3 - Run:
	Build IStore.sln and run IStore.Web project
