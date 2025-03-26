namespace SurveyApi.Repositories.DTO
{
    public class SurveyResponseDto
    {
        public List<AnswerDto> Answers { get; set; }
        public string SurveyId { get; set; }
        public Guid UserId { get; set; }
    }
}
