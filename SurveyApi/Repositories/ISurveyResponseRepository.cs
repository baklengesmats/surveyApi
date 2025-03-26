using SurveyApi.Repositories.Models;

namespace SurveyApi.Repositories
{
    public interface ISurveyResponseRepository
    {
        public Task<SurveyResponse> AddSurveyResponse(SurveyResponse surveyResponse);
        public Task<List<SurveyResponse>> GetAllSurveyResponses();
        public Task<List<SurveyResponse>> GetSurveyResponseForSurvey(Guid survey);
        public Task<SurveyResponse> GetSurveyResponse(Guid surveyResponseId);
    }
}
