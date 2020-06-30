using CovidDashboard.Mappers;
using CovidDashboard.Models;
using CovidDashboard.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CovidDashboard.Controllers
{
    [ApiController]
    [Route("api/collections")]
    public class ObservationDataCollectionController : ControllerBase
    {
        private readonly ICovidObservationsDataRepository _covidObservationsDataRepository;
        private readonly ICovidObservationDataMapper _covidObservationDataMapper;

        public ObservationDataCollectionController(
            ICovidObservationsDataRepository covidObservationsDataRepository,
            ICovidObservationDataMapper covidObservationDataMapper)
        {
            _covidObservationsDataRepository = covidObservationsDataRepository ?? throw new ArgumentNullException(nameof(covidObservationsDataRepository));
            _covidObservationDataMapper = covidObservationDataMapper ?? throw new ArgumentNullException(nameof(covidObservationDataMapper));
        }

        [HttpPost]
        public ActionResult<IEnumerable<CovidObservationDatumDto>> CreateObservationCollection(
            IEnumerable<CovidObservationDatumInputDto> observationCollection)
        {
            var collection = _covidObservationDataMapper.ToObservationCollection(observationCollection);
            foreach(var item in collection)
            {
                _covidObservationsDataRepository.AddCovidObservationsDatum(item);
                _covidObservationsDataRepository.Save();
            }

            var result = _covidObservationDataMapper.ToCovidCaseDataListDto(collection);
            return Ok(result);
        }
    }
}
