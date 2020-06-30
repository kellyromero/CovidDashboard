using CovidDashboard.Mappers;
using CovidDashboard.Models;
using CovidDashboard.ResourceParameters;
using CovidDashboard.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CovidDashboard.Controllers
{
    [ApiController]
    [Route("top/confirmed")]
    public class CovidDashboardController : ControllerBase
    {
        private readonly ICovidObservationsDataRepository _dashBoardRepository;
        private readonly ICovidObservationDataMapper _covidCaseDataMapper;

        public CovidDashboardController(ICovidObservationsDataRepository dashboardRepository, ICovidObservationDataMapper covidCaseDataMapper)
        {
            _dashBoardRepository = dashboardRepository;
            _covidCaseDataMapper = covidCaseDataMapper;
        }

        [HttpGet("{caseId}", Name = "GetSpecificData")]
        public ActionResult<CovidObservationDatumDto> GetSpecificData(int caseId)
        {
            var caseData = _dashBoardRepository.GetSpecificObservation(caseId);

            if (caseData == null)
            {
                return NotFound();
            }

            return Ok(_covidCaseDataMapper.ToCovidCaseDataDto(caseData));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<CovidObservationDatumDto>> GetTopConfirmed(
            [FromQuery()] CovidDashboardResourceParameters resourceParameters)
        {
            var results = _dashBoardRepository.GetTopConfirmed(resourceParameters);
            var covidCaseDataList = _covidCaseDataMapper.ToCovidCaseDataListDto(results);

            return Ok(covidCaseDataList);
        }

        [HttpPost]
        public ActionResult<CovidObservationDatumDto> CreateCovidCaseDatum(CovidObservationDatumInputDto covidObservationsDatum)
        {
            var entity = _covidCaseDataMapper.ToCovidObservationDatum(covidObservationsDatum);
            _dashBoardRepository.AddCovidObservationsDatum(entity);
            _dashBoardRepository.Save();

            var result = _covidCaseDataMapper.ToCovidCaseDataDto(entity);
            return CreatedAtRoute("GetSpecificData",
                new { caseId = entity.Id },
                result);
        }

        [HttpPut("{caseId}")]
        public ActionResult UpdateCovidCaseDatum(int caseId, CovidObservationDatumUpdateDto updateDto)
        {
            if(!_dashBoardRepository.caseDataExists(caseId))
            {
                return NotFound();
            }

            var entity = _covidCaseDataMapper.ToCovidObservationDatum(updateDto);
            entity.Id = caseId;
            _dashBoardRepository.UpdateCaseData(entity);
            _dashBoardRepository.Save();

            return NoContent();
        }
    }
}