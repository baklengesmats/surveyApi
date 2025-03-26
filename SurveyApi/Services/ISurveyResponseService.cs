using SurveyApi.Repositories.DTO;
using SurveyApi.Repositories.Models;

namespace SurveyApi.Services
{
    public interface ISurveyResponseService
    {
        public Task<List<SurveyResponse>> GetAllSurveyResponses();
        public Task<SurveyResponse> GetSurveyResponse(string surveyResponseId);
        public Task<List<SurveyResponse>> GetSurveyResponseForSurvey(string surveyId);
        public Task<SurveyResponse> AddSurveyResponseToBenchMark(SurveyResponseDto surveyResponseDto);
    }
}
