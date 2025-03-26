using SurveyApi.Repositories.Models;

namespace SurveyApi.Repositories.Mock
{
    public class MockSurveyResponseRepository : ISurveyResponseRepository
    {
        private static List<int[]> benchmarkData = new List<int[]>
        {
            new int[] { 3, 4, 4, 3, 1 },
            new int[] { 3, 4, 4, 4, 5 },
            new int[] { 1, 2, 2, 1, 2 },
            new int[] { 4, 5, 5, 4, 5 },
            new int[] { 2, 3, 4, 4, 4 }
        };
        private static List<SurveyResponse> benchmarkAnswers = new List<SurveyResponse>();

        private List<SurveyResponse> CreateBenchmarkData()
        {
            List<SurveyResponse> benchmarkAnswers = new List<SurveyResponse>();
            foreach (var group in benchmarkData)
            {
                var userId = Guid.NewGuid();
                var answers = new List<Answer>();
                var groupIndex = 0;
                for (int i = 0; i < group.Length; i++)
                {
                    answers.Add(new Answer
                    {
                        AnswerId = Guid.NewGuid(),
                        QuestionId = MockGuid.PredefinedQuestionGuid[i],
                        Grade = group[i],
                        SurveyResponseId = MockGuid.PredefinedSurveyResponseGuid[i]
                    });
                }
                benchmarkAnswers.Add(new SurveyResponse
                {
                    SurveyResponseId = MockGuid.PredefinedSurveyResponseGuid[groupIndex],
                    Answers = answers,
                    SubmittedOn = DateTime.Now,
                    SurveyId = MockGuid.PredefinedSurveyGuid[0],
                    UserId = userId,
                });
                groupIndex++;
            }
            return benchmarkAnswers;
        }

        public MockSurveyResponseRepository()
        {
            if(benchmarkAnswers.Count == 0)
                benchmarkAnswers = CreateBenchmarkData();
        }   
        public Task<SurveyResponse> AddSurveyResponse(SurveyResponse surveyResponse)
        {
            benchmarkAnswers.Add(surveyResponse);
            return Task.FromResult(surveyResponse);
        }

        public Task<List<SurveyResponse>> GetAllSurveyResponses()
        {
            return Task.FromResult(benchmarkAnswers);
        }

        public Task<List<SurveyResponse>> GetSurveyResponseForSurvey(Guid survey)
        {
            var reposnses = benchmarkAnswers.Where(x => x.SurveyId == survey).ToList();
            return Task.FromResult(reposnses);
        }

        public Task<SurveyResponse> GetSurveyResponse(Guid surveyResponseId)
        {
            var response = benchmarkAnswers.FirstOrDefault(x => x.SurveyResponseId == surveyResponseId);
            return Task.FromResult(response);
        }
    }
}
