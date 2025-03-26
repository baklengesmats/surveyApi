using SurveyApi.Repositories.Models;

namespace SurveyApi.Repositories
{
    public interface ISurveyRepository
    {
        public Task<List<Survey>> GetAllSurveys();
        public Task<Survey> GetSurvey(Guid surveyId);
        public Task<Survey> AddSurvey(Survey survey);
        public Task<Survey> UpdateSurvey(Survey survey);
        public Task<Survey> DeleteSurvey(Guid surveyId);
    }
}
