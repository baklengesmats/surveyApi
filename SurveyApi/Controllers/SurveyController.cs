using Microsoft.AspNetCore.Mvc;
using SurveyApi.Services;

namespace SurveyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSurveys()
        {
           var surveys = await _surveyService.GetAllSurveys();
            return Ok(surveys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSurvey(string id)
        {
            var survey = await _surveyService.GetSurvey(id);
            return Ok(survey);
        }

    }
}
