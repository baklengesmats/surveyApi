namespace SurveyApi.Repositories.Models
{
    /// <summary>
    /// Change the structure to be to easier filtering between group of question and individual qeustions.
    /// Also easier to add new groups of questions. Add grade interval for each question, make it possible to other grade than what would been hardcoded.
    /// </summary>
    public class Question
    {
        public Guid QuestionId { get; set; }
        public Guid SurveyId { get; set; }
        public int QuestionOrder { get; set; }
        public string Text { get; set; }
        public int minGrade { get; set; }
        public int maxGrade { get; set; }
    }
}
