using CovidDashboard.Entities;
using CovidDashboard.Models;
using System.Collections.Generic;

namespace CovidDashboard.Mappers
{
    public interface ICovidObservationDataMapper
    {
        CovidObservationsDatumDto ToCovidCaseDataDto(CovidObservationDatum entity);

        IEnumerable<CovidObservationsDatumDto> ToCovidCaseDataListDto(IEnumerable<CovidObservationDatum> entities);
    }
}