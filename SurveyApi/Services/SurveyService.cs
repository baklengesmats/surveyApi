using SurveyApi.Common.Exceptions;
using SurveyApi.Repositories;
using SurveyApi.Repositories.Models;

namespace SurveyApi.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }
        public async Task<List<Survey>> GetAllSurveys()
        {
            var surveys = await _surveyRepository.GetAllSurveys();
            return surveys;
        }

        public async Task<Survey> GetSurvey(string surveyId)
        {
            var validGuid = Guid.TryParse(surveyId, out Guid surveyGuid);
            if (!validGuid)
            {
                throw new InvalidInputException("Invalid survey id");
            }
            var survey = await _surveyRepository.GetSurvey(surveyGuid);
            if(survey == null)
            {
                throw new ItemNotFoundException($"Survey with id:{surveyId} not found");
            }
            return survey;
        }


    }
}
