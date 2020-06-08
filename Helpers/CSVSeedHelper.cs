using CovidDashboard.Entities;
using Npgsql;
using PostgreSQLCopyHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace CovidDashboard.Helpers
{
    public static class CSVSeedHelper
    {
        public static void SeedCSVData()
        {
            string fullPath = Environment.CurrentDirectory + "\\covid_19_data.csv";

            using (StreamReader sr = new StreamReader(fullPath))
            {
                string[] headers = sr.ReadLine().Split(',');

                Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                List<CovidObservationDatum> tableRows = new List<CovidObservationDatum>();

                while (!sr.EndOfStream)
                {
                    var lineData = sr.ReadLine();
                    string[] row = CSVParser.Split(lineData);

                    var rowData = new CovidObservationDatum
                    {
                        Id = Convert.ToInt32(row[0]),
                        ObservationDate = Convert.ToDateTime(row[1]),
                        ProvinceState = row[2],
                        Country = row[3],
                        LastUpdate = Convert.ToDateTime(row[4]),
                        Confirmed = Convert.ToInt32(row[5]),
                        Deaths = Convert.ToInt32(row[6]),
                        Recovered = Convert.ToInt32(row[7])
                    };

                    tableRows.Add(rowData);
                }

                var copyHelper = new PostgreSQLCopyHelper<CovidObservationDatum>("covid_observations")
                    .MapInteger(headers[0], x => x.Id)
                    .MapDate(headers[1], x => x.ObservationDate)
                    .MapText(headers[2], x => x.ProvinceState)
                    .MapText(headers[3], x => x.Country)
                    .MapDate(headers[4], x => x.LastUpdate)
                    .MapInteger(headers[5], x => x.Confirmed)
                    .MapInteger(headers[6], x => x.Deaths)
                    .MapInteger(headers[7], x => x.Recovered);

                using (var connection = new NpgsqlConnection(Startup.ConnectionString))
                {
                    connection.Open();

                    copyHelper.SaveAll(connection, (tableRows));
                }
            }
        }
    }
}