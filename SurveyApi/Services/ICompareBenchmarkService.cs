using SurveyApi.Repositories.DTO;
using SurveyApi.Repositories.Models;

namespace SurveyApi.Services
{
    public interface ICompareBenchmarkService
    {
        public Task<List<CalcGradeDto>> CalculateMedianBenchmark(string surveyId);
        public Task<List<CalcGradeDto>> CalculateMeanBenchmark(string surveyId);
    }
}
