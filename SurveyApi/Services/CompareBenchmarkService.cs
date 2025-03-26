using SurveyApi.Common.Exceptions;
using SurveyApi.Repositories.DTO;
using SurveyApi.Repositories.Models;

namespace SurveyApi.Services
{
    public class CompareBenchmarkService : ICompareBenchmarkService
    {
        private readonly ISurveyResponseService _surveyResponseService;
        private readonly ISurveyService _surveyService;

        public CompareBenchmarkService(ISurveyResponseService surveyResponseService, ISurveyService surveyService)
        {
            _surveyResponseService = surveyResponseService;
            _surveyService = surveyService;
        }
        public async Task<List<CalcGradeDto>> CalculateMeanBenchmark(string surveyId)
        {
            var survey = await _surveyService.GetSurvey(surveyId);
            var surveyResponses = await _surveyResponseService.GetSurveyResponseForSurvey(surveyId);
            
            var meanGrade = new List<CalcGradeDto>();
            if (survey == null)
            {
                throw new ItemNotFoundException($"Survey with id:{surveyId} was not found");
            }
            if (surveyResponses == null)
            {
                throw new ItemNotFoundException($"Survey responses with surveyId:{surveyId} not found");
            }

            foreach (var question in survey.Questions)
            {
                var questionResponses = surveyResponses.SelectMany(sr => sr.Answers).Where(a => a.QuestionId == question.QuestionId);
                var mean = questionResponses.Select(a => a.Grade).Average();
                meanGrade.Add(new CalcGradeDto()
                {
                    QuestionId = question.QuestionId,
                    Grade = mean,
                    SurveyId = survey.SurveyId.ToString(),
                });
            }

            return meanGrade;
        }

        public async Task<List<CalcGradeDto>> CalculateMedianBenchmark(string surveyId)
        {
            var survey = await _surveyService.GetSurvey(surveyId);
            var surveyResponses = await _surveyResponseService.GetSurveyResponseForSurvey(surveyId);

            var medianGrade = new List<CalcGradeDto>();
            if (survey == null)
            {
                throw new ItemNotFoundException($"Survey with id:{surveyId} was not found");
            }
            if (surveyResponses == null)
            {
                throw new ItemNotFoundException($"Survey responses with surveyId:{surveyId} not found");
            }

            foreach (var question in survey.Questions)
            {
                var questionResponses = surveyResponses.SelectMany(sr => sr.Answers).Where(a => a.QuestionId == question.QuestionId);
                var median = CalculateMedian(questionResponses.Select(a => a.Grade).ToList());
                medianGrade.Add(new CalcGradeDto()
                {
                    QuestionId = question.QuestionId,
                    Grade = median,
                    SurveyId = survey.SurveyId.ToString(),
                });
            }
            return medianGrade;
        }

        public static int CalculateMedian(List<int> values)
        {
            values.Sort();
            int size = values.Count;
            int mid = size / 2;
            return (size % 2 != 0) ? values[mid] : (values[mid] + values[mid - 1]) / 2;
        }
    }
}
