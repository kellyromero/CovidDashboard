using CovidDashboard.Entities;
using CovidDashboard.Models;
using System.Collections.Generic;

namespace CovidDashboard.Mappers
{
    public class CovidObservationDataMapper : ICovidObservationDataMapper
    {
        public CovidObservationDatumDto ToCovidCaseDataDto(CovidObservationDatum entity)
        {
            var dto = new CovidObservationDatumDto()
            {
                Country = entity.Country,
                Confirmed = entity.Confirmed,
                Recovered = entity.Recovered,
                Deaths = entity.Deaths
            };

            return dto;
        }

        public IEnumerable<CovidObservationDatumDto> ToCovidCaseDataListDto(IEnumerable<CovidObservationDatum> entities)
        {
            var covidCaseDataListDto = new List<CovidObservationDatumDto>();

            foreach (var entity in entities)
            {
                var dto = new CovidObservationDatumDto()
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

        public CovidObservationDatum ToCovidObservationDatum(CovidObservationDatumInputDto covidObservationDatum)
        {
            var entity = new CovidObservationDatum()
            {
                ObservationDate = covidObservationDatum.ObservationDate,
                ProvinceState = covidObservationDatum.ProvinceState,
                Country = covidObservationDatum.Country,
                LastUpdate = covidObservationDatum.LastUpdate,
                Confirmed = covidObservationDatum.Confirmed,
                Deaths = covidObservationDatum.Deaths,
                Recovered = covidObservationDatum.Recovered
            };

            return entity;
        }

        public CovidObservationDatum ToCovidObservationDatum(CovidObservationDatumUpdateDto covidObservationDatum)
        {
            var entity = new CovidObservationDatum()
            {
                ObservationDate = covidObservationDatum.ObservationDate,
                ProvinceState = covidObservationDatum.ProvinceState,
                Country = covidObservationDatum.Country,
                LastUpdate = covidObservationDatum.LastUpdate,
                Confirmed = covidObservationDatum.Confirmed,
                Deaths = covidObservationDatum.Deaths,
                Recovered = covidObservationDatum.Recovered
            };

            return entity;
        }

        public IEnumerable<CovidObservationDatum> ToObservationCollection(IEnumerable<CovidObservationDatumInputDto> observationCollection)
        {
            var observationList = new List<CovidObservationDatum>();

            foreach(var item in observationCollection)
            {
                var entity = new CovidObservationDatum()
                {
                    ObservationDate = item.ObservationDate,
                    ProvinceState = item.ProvinceState,
                    Country = item.Country,
                    LastUpdate = item.LastUpdate,
                    Confirmed = item.Confirmed,
                    Deaths = item.Deaths,
                    Recovered = item.Recovered
                };

                observationList.Add(entity);
            }

            return observationList;
        }
    }
}