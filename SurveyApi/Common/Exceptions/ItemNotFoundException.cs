namespace SurveyApi.Common.Exceptions
{
    public class ItemNotFoundException : HttpException
    {
        public override int StatusCode => StatusCodes.Status404NotFound;

        public ItemNotFoundException(string message) : base(message) { }
    }

}
