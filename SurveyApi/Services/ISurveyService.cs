using SurveyApi.Repositories.Models;

namespace SurveyApi.Services
{
    public interface ISurveyService
    {
        public Task<List<Survey>> GetAllSurveys();
        public Task<Survey> GetSurvey(string surveyId);
    }
}
