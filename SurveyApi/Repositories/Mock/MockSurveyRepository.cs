using SurveyApi.Repositories.Models;

namespace SurveyApi.Repositories.Mock
{
    public class MockSurveyRepository : ISurveyRepository
    {
        private static List<Question> _questions = new List<Question>
        {
            new Question()
            {
                SurveyId = MockGuid.PredefinedSurveyGuid[0],
                QuestionOrder = 1,
                Text = "Would you recommend this app to friend?",
                minGrade = 1,
                maxGrade = 5,
                QuestionId = MockGuid.PredefinedQuestionGuid[0]
            },
            new Question()
            {
                SurveyId = MockGuid.PredefinedSurveyGuid[0],
                QuestionOrder = 2,
                Text = "Do you trust your leadership?",
                minGrade = 1,
                maxGrade = 5,
                QuestionId = MockGuid.PredefinedQuestionGuid[1]
            },
            new Question()
            {
                SurveyId = MockGuid.PredefinedSurveyGuid[0],
                QuestionOrder = 3,
                Text = "How much do you like yourself as a colleague?",
                minGrade = 1,
                maxGrade = 5,
                QuestionId = MockGuid.PredefinedQuestionGuid[2]
            },
            new Question()
            {
                SurveyId = MockGuid.PredefinedSurveyGuid[0],
                QuestionOrder = 4,
                Text = "Do you have fun in this app?",
                minGrade = 1,
                maxGrade = 5,
                QuestionId = MockGuid.PredefinedQuestionGuid[3]
            },
            new Question()
            {
                SurveyId = MockGuid.PredefinedSurveyGuid[0],
                QuestionOrder = 5,
                Text = "How much do you want to submit?",
                minGrade = 1,
                maxGrade = 5,
                QuestionId = MockGuid.PredefinedQuestionGuid[4]
            },
        };

        public static List<Survey> _surveys = new List<Survey>
        {
            new Survey()
            {
                SurveyId = MockGuid.PredefinedSurveyGuid[0],
                Questions = _questions,
                Title = "Employee Survey",
            }
        };

        public Task<Survey> AddSurvey(Survey survey)
        {
            _surveys.Add(survey);
            return Task.FromResult(survey);
        }

        public Task<Guid> DeleteSurvey(Guid surveyId)
        {
            var survey = _surveys.FirstOrDefault(s => s.SurveyId == surveyId);
            if (survey != null)
            {
                _surveys.Remove(survey);
            }
            return Task.FromResult(surveyId);
        }

        public Task<List<Survey>> GetAllSurveys()
        {
            return Task.FromResult(_surveys);
        }

        public Task<Survey> GetSurvey(Guid surveyId)
        {
            return Task.FromResult(_surveys.FirstOrDefault(s => s.SurveyId == surveyId));
        }

        public Task<Survey> UpdateSurvey(Survey survey)
        {
            var existingSurvey = _surveys.FirstOrDefault(s => s.SurveyId == survey.SurveyId);
            if (existingSurvey != null)
            {
                _surveys.Remove(existingSurvey);
                _surveys.Add(survey);
            }
            return Task.FromResult(survey);
        }

        Task<Survey> ISurveyRepository.DeleteSurvey(Guid surveyId)
        {
            throw new NotImplementedException();
        }
    }
}
