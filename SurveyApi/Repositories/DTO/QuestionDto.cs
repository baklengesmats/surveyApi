namespace SurveyApi.Repositories.DTO
{
    public class QuestionDto
    {
        public Guid QuestionId { get; set; }
        public int QuestionOrder { get; set; }
        public string QuestionGroupId { get; set; }
        public string Text { get; set; }
    }
}
