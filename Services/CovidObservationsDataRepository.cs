using CovidDashboard.DbContexts;
using CovidDashboard.Entities;
using CovidDashboard.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CovidDashboard.Services
{
    public class CovidObservationsDataRepository : ICovidObservationsDataRepository
    {
        private readonly CovidObservationsContext _context;

        public CovidObservationsDataRepository(CovidObservationsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCovidObservationsDatum(CovidObservationDatum covidObservationDatum)
        {
            if (covidObservationDatum == null)
            {
                throw new ArgumentNullException(nameof(covidObservationDatum));
            }

            var collection = _context.CovidObservationData as IEnumerable<CovidObservationDatum>;

            var lastDataId = collection.LastOrDefault().Id;

            covidObservationDatum.Id = lastDataId + 1;

            _context.CovidObservationData.Add(covidObservationDatum);
        }

        public CovidObservationDatum GetSpecificObservation(int observationDatumId)
        {
            return _context.CovidObservationData.FirstOrDefault(
                record => record.Id == observationDatumId);
        }

        public IEnumerable<CovidObservationDatum> GetTopConfirmed(
            CovidDashboardResourceParameters resourceParameters)
        {
            var numberOfItemsToDisplay = resourceParameters?.Max_Results ?? null;
            var observationDate = resourceParameters.Observation_Date ?? null;

            if (numberOfItemsToDisplay == null && observationDate == null)
            {
                return GetTopConfirmed();
            }

            var collection = _context.CovidObservationData as IEnumerable<CovidObservationDatum>;

            if(observationDate != null)
            {
                collection = collection.Where(x => x.ObservationDate == observationDate)
                    .GroupBy(x => x.Country)
                    .Select(group =>
                        new CovidObservationDatum
                        {
                            Country = group.Key,
                            Confirmed = group.Sum(x => x.Confirmed),
                            Recovered = group.Sum(x => x.Recovered),
                            Deaths = group.Sum(x => x.Deaths)
                        })
                    .OrderByDescending(group => group.Confirmed);
            }

            if (numberOfItemsToDisplay != null)
            {
                collection = collection.Take(numberOfItemsToDisplay.Value);
            }

            return collection.ToList();
        }

        public IEnumerable<CovidObservationDatum> GetTopConfirmed()
        {
            return _context.CovidObservationData.ToList<CovidObservationDatum>();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCaseData(CovidObservationDatum covidObservationDatum)
        {
            var item = _context.CovidObservationData.FirstOrDefault(x => x.Id == covidObservationDatum.Id);
            item.Confirmed = covidObservationDatum.Confirmed;
            item.Deaths = covidObservationDatum.Deaths;
            item.Recovered = covidObservationDatum.Recovered;

            _context.CovidObservationData.Update(item);
        }

        public bool caseDataExists(int caseId)
        {
            return _context.CovidObservationData.Any(x=> x.Id == caseId);
        }
    }
}