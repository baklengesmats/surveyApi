using Microsoft.AspNetCore.Mvc;
using SurveyApi.Repositories.DTO;
using SurveyApi.Services;

namespace SurveyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyResponseController : ControllerBase
    {
        private readonly ISurveyResponseService _surveyResponseService;
        private readonly ICompareBenchmarkService _compareSurveyService;
        public SurveyResponseController(ICompareBenchmarkService compareSurveyService, ISurveyResponseService surveyResponseService)
        {
            _compareSurveyService = compareSurveyService;
            _surveyResponseService = surveyResponseService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSurveyResponses()
        {
            var surveyResponses = await _surveyResponseService.GetAllSurveyResponses();
            return Ok(surveyResponses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSurveyResponse(string id)
        {
            var response = await _surveyResponseService.GetSurveyResponse(id);
            return Ok(response);
        }

        [HttpPost("submit")]
        public async Task<ActionResult> SubmiitSurveyResponse(SurveyResponseDto surveyResponse)
        {
            var response = await _surveyResponseService.AddSurveyResponseToBenchMark(surveyResponse);
            return Ok(response);
        }

        [HttpGet("compareMedian/{surveyId}")]
        public async Task<ActionResult> CompareMedianSurveyResponses(string surveyId)
        {
            var response = await _compareSurveyService.CalculateMedianBenchmark(surveyId);
            return Ok(response);
        }

        [HttpGet("compareMean/{surveyId}")]
        public async Task<ActionResult> CompareMeanSurveyResponses(string surveyId)
        {
            var response = await _compareSurveyService.CalculateMeanBenchmark(surveyId);
            return Ok(response);
        }
    }
}
