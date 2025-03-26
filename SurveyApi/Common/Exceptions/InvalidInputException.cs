namespace SurveyApi.Common.Exceptions
{
    public class InvalidInputException : HttpException
    {
        public override int StatusCode => StatusCodes.Status400BadRequest;

        public InvalidInputException(string message) : base(message) { }
    }

}
