namespace SurveyApi.Repositories.DTO
{
    public class CalcGradeDto
    {
        public string SurveyId { get; set; }
        public double Grade { get; set; }
        public Guid QuestionId { get; set; }
    }
}
