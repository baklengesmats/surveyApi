namespace SurveyApi.Common.Exceptions
{
    public class InternalException: HttpException
    {
        public override int StatusCode => StatusCodes.Status500InternalServerError;

        public InternalException(string message) : base(message) { }
    }

}
