using CovidDashboard.Entities;
using System;
using System.Collections.Generic;

namespace CovidDashboard.Services
{
    public interface ICovidObservationsDataRepository
    {
        IEnumerable<CovidObservationDatum> GetTopConfirmed();

        IEnumerable<CovidObservationDatum> GetTopConfirmed(int? numberOfItemsToDisplay, DateTime? observationDate);
    }
}