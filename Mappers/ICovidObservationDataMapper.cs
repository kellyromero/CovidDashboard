using CovidDashboard.Entities;
using CovidDashboard.Models;
using System.Collections.Generic;

namespace CovidDashboard.Mappers
{
    public interface ICovidObservationDataMapper
    {
        CovidObservationDatumDto ToCovidCaseDataDto(CovidObservationDatum entity);

        IEnumerable<CovidObservationDatumDto> ToCovidCaseDataListDto(IEnumerable<CovidObservationDatum> entities);

        CovidObservationDatum ToCovidObservationDatum(CovidObservationDatumInputDto covidObservationDatum);

        CovidObservationDatum ToCovidObservationDatum(CovidObservationDatumUpdateDto covidObservationDatum);

        IEnumerable<CovidObservationDatum> ToObservationCollection(IEnumerable<CovidObservationDatumInputDto> observationCollection);
    }
}