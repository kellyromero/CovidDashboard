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

   Method   : GET (Get data for a particular date showing max results)
   URL      : http://localhost:51044/top/confirmed?max_results=4&observation_date=2020-02-02

   Method   : GET (Get specific case data using caseId)
   URL      : http://localhost:51044/top/confirmed/{caseId}
   
   Method   : POST (Creating a new case data)
   URL      : http://localhost:51044/top/confirmed
   Request Body   :
      {
       "observationDate": "2020-06-11",
       "provinceState": "Pasig",
       "lastUpdate": "2020-06-11",
       "country": "Philippines",    
       "confirmed": 20000,
       "deaths": 1000,
       "recovered": 750
      }
      
   Method   : PUT (Update an existing case data)
   URL      : http://localhost:51044/top/confirmed/{caseId}
   REQUEST BODY:
      {
       "observationDate": "2020-06-11",
       "provinceState": "Caloocan",
       "country": "Philippines",
       "lastUpdate": "2020-06-11",
       "confirmed": 1000,
       "deaths": 1000,
       "recovered": 1000
      }

   Method   : POST (Creating multiple case data)
   URL      : http://localhost:51044/api/collections
   REQUEST BODY:
   [
    {
        "observationDate": "2020-06-11",
        "provinceState": "Alabang",
        "country": "Philippines",
        "lastUpdate": "2020-06-11",
        "confirmed": 1,
        "deaths": 2,
        "recovered": 3
    },
    {
        "observationDate": "2020-06-11",
        "provinceState": "Las Pinas",
        "country": "Philippines",
        "lastUpdate": "2020-06-11",
        "confirmed": 3,
        "deaths": 2,
        "recovered": 1
    }
   ]
