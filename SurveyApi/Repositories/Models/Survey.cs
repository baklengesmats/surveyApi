namespace SurveyApi.Repositories.Models
{
    public class Survey
    {
        public Guid SurveyId { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
    }
}
