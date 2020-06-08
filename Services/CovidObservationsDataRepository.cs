using CovidDashboard.DbContexts;
using CovidDashboard.Entities;
using System;
using System.Collections.Generic;
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

        public IEnumerable<CovidObservationDatum> GetTopConfirmed(
            int? numberOfItemsToDisplay, DateTime? observationDate)
        {
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
    }
}