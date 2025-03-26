namespace SurveyApi.Common.Exceptions
{
    public abstract class HttpException : Exception
    {
        public abstract int StatusCode { get; }

        protected HttpException(string message) : base(message) { }
    }
}
