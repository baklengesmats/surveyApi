using System.ComponentModel.DataAnnotations;

namespace SurveyApi.Repositories.DTO
{
    public class AnswerDto
    {
        [Required(ErrorMessage = "QuestionId is required")]
        public string QuestionId { get; set; }
        [Required(ErrorMessage = "Grade is required")]
        public int Grade { get; set; }
    }
}
