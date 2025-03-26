namespace SurveyApi.Repositories.Mock
{
    /// <summary>
    /// Need to predifine the Guids to be able to connect the answers to the correct questions.
    /// For the mock data.
    /// </summary>
    public static class MockGuid
    {
        public static readonly Guid[] PredefinedQuestionGuid = new Guid[]
        {
            Guid.Parse("566caaea-dced-431f-84c6-693715ab6549"),
            Guid.Parse("b1b3b3b3-1b3b-4b3b-8b3b-9b3b3b3b3b3b"),
            Guid.Parse("e11479b1-8b84-4f9c-be34-25efe161712b"),
            Guid.Parse("5a5c7a30-7dd4-42ea-96fd-0f22300b29fc"),
            Guid.Parse("01d28f8b-40e8-408a-a629-9dbf73a8496a"),
        };
        public static readonly Guid[] PredefinedSurveyGuid = new Guid[]
        {
            Guid.Parse("5db1e490-9486-4d2b-b5ef-7d78ed33447c"),
        };
        public static readonly Guid[] PredefinedSurveyResponseGuid = new Guid[]
{
            Guid.Parse("8accc1fd-7c69-4331-ad30-2c81d0ec8f44"),
            Guid.Parse("91add4a2-ec21-43db-b5e6-416f5abfbb40"),
            Guid.Parse("06c2bef9-f601-4da9-a74b-583ffeee82b4"),
            Guid.Parse("b4935e5c-7a26-4bad-afca-7628ed534310"),
            Guid.Parse("a1720cf5-04da-4be1-b28e-4f26f0577016"),
};
    }
}
