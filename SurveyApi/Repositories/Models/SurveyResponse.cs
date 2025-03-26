namespace SurveyApi.Repositories.Models
{
    public class SurveyResponse
    {
        public Guid SurveyResponseId { get; set; }
        public Guid SurveyId { get; set; }
        public Guid UserId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
