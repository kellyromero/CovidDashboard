using CovidDashboard.Entities;
using CovidDashboard.ResourceParameters;
using System;
using System.Collections.Generic;

namespace CovidDashboard.Services
{
    public interface ICovidObservationsDataRepository
    {
        IEnumerable<CovidObservationDatum> GetTopConfirmed();

        IEnumerable<CovidObservationDatum> GetTopConfirmed(CovidDashboardResourceParameters resourceParameters);

        void AddCovidObservationsDatum(CovidObservationDatum covidObservationDatum);

        bool Save();

        CovidObservationDatum GetSpecificObservation(int observationDatumId);

        void UpdateCaseData(CovidObservationDatum covidObservationDatum);

        bool caseDataExists(int caseId);
    }
}