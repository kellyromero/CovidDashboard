using CovidDashboard.Mappers;
using CovidDashboard.Models;
using CovidDashboard.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CovidDashboard.Controllers
{
    [ApiController]
    public class CovidDashboardController : ControllerBase
    {
        private readonly ICovidObservationsDataRepository _dashBoardRepository;
        private readonly ICovidObservationDataMapper _covidCaseDataMapper;

        public CovidDashboardController(ICovidObservationsDataRepository dashboardRepository, ICovidObservationDataMapper covidCaseDataMapper)
        {
            _dashBoardRepository = dashboardRepository;
            _covidCaseDataMapper = covidCaseDataMapper;
        }

        [HttpGet("top/confirmed")]
        public ActionResult<IEnumerable<CovidObservationsDatumDto>> GetTopConfirmed(
            [FromQuery(Name = "max_results")] int? numberOfItemsToDisplay,
            [FromQuery(Name ="observation_date")] DateTime? observationDate)
        {
            var results = _dashBoardRepository.GetTopConfirmed(numberOfItemsToDisplay, observationDate);
            var covidCaseDataList = _covidCaseDataMapper.ToCovidCaseDataListDto(results);

            return Ok(covidCaseDataList);
        }
    }
}