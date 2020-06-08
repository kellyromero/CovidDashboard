using CovidDashboard.Entities;
using CovidDashboard.Models;
using System.Collections.Generic;

namespace CovidDashboard.Mappers
{
    public class CovidObservationDataMapper : ICovidObservationDataMapper
    {
        public CovidObservationsDatumDto ToCovidCaseDataDto(CovidObservationDatum entity)
        {
            var dto = new CovidObservationsDatumDto()
            {
                Country = entity.Country,
                Confirmed = entity.Confirmed,
                Recovered = entity.Recovered,
                Deaths = entity.Deaths
            };

            return dto;
        }

        public IEnumerable<CovidObservationsDatumDto> ToCovidCaseDataListDto(IEnumerable<CovidObservationDatum> entities)
        {
            var covidCaseDataListDto = new List<CovidObservationsDatumDto>();

            foreach (var entity in entities)
            {
                var dto = new CovidObservationsDatumDto()
                {
                    Country = entity.Country,
                    Confirmed = entity.Confirmed,
                    Recovered = entity.Recovered,
                    Deaths = entity.Deaths
                };

                covidCaseDataListDto.Add(dto);
            }

            return covidCaseDataListDto;
        }
    }
}