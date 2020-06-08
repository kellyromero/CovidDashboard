# CovidDashboard
CovidDashboard

Prerequisites:
Visual Studio
PostgreSQL
Postman

Steps to run/test the API:

1. Download all files in your local machine (on your desired local path)

2. Open TableCreateScript.Sql file using Postgre and execute the query. (to create the database table)

3. Open appsettings.json file and update the connection string as needed. (most importantly the password)

4. Run the API and test using Postman.
   Method   : GET 
   URL      : http://localhost:51044/top/confirmed?max_results=4&observation_date=2020-02-02
