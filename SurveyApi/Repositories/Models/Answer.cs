namespace SurveyApi.Repositories.Models
{
    public class Answer
    {
        public Guid AnswerId { get; set;}
        public Guid QuestionId{ get; set; }
        public Guid SurveyResponseId { get; set; }
        public int Grade { get; set; }
    }
}
