using SurveyApi.Common.Exceptions;
using SurveyApi.Repositories;
using SurveyApi.Repositories.DTO;
using SurveyApi.Repositories.Models;

namespace SurveyApi.Services
{
    public class SurveyResponseService : ISurveyResponseService
    {
        private readonly ISurveyResponseRepository _surveyResponseRepository;
        public SurveyResponseService(ISurveyResponseRepository surveyResponseRepository)
        {
            _surveyResponseRepository = surveyResponseRepository;
        }
        public SurveyResponse CreateSurveyResponse(SurveyResponseDto surveyResponse)
        {
            var newGuidSurveyResponse = Guid.NewGuid();
            var newAnswers = new List<Answer>();
            foreach (var answer in surveyResponse.Answers)
            {
                newAnswers.Add(new Answer
                {
                    AnswerId = Guid.NewGuid(),
                    QuestionId = Guid.Parse(answer.QuestionId),
                    Grade = answer.Grade,
                    SurveyResponseId = newGuidSurveyResponse
                });
            }
            var newSurveyResponse = new SurveyResponse
            {
                SurveyId = Guid.Parse(surveyResponse.SurveyId),
                UserId = surveyResponse.UserId,
                SubmittedOn = DateTime.Now,
                Answers = newAnswers,
                SurveyResponseId = newGuidSurveyResponse
            };
            return newSurveyResponse;
        }

        public async Task<SurveyResponse> AddSurveyResponseToBenchMark(SurveyResponseDto surveyResponse)
        {
            var newSurveyResponse = CreateSurveyResponse(surveyResponse);
            await _surveyResponseRepository.AddSurveyResponse(newSurveyResponse);
            return newSurveyResponse;
        }

        public async Task<List<SurveyResponse>> GetAllSurveyResponses()
        {
            var responses = await _surveyResponseRepository.GetAllSurveyResponses();
            return responses;
        }

        public async Task<SurveyResponse> GetSurveyResponse(string surveyResponseId)
        {
            var validSurveyResponseId = Guid.TryParse(surveyResponseId, out Guid surveyResponseGuid);
            if (!validSurveyResponseId)
            {
                throw new InvalidInputException($"Survey response id: {surveyResponseId} is not a valid guid");
            }

            var response = await _surveyResponseRepository.GetSurveyResponse(surveyResponseGuid);
            if (response == null)
            {
                throw new ItemNotFoundException($"Survey response with id: {surveyResponseId} was not found");
            }
            return response;
        }

        public async Task<List<SurveyResponse>> GetSurveyResponseForSurvey(string surveyId)
        {
            var validSurveyId = Guid.TryParse(surveyId, out Guid surveyGuid);
            if(!validSurveyId)
            {
                throw new InvalidInputException($"Survey id: {surveyId} is not a valid guid");
            }
            var response = await _surveyResponseRepository.GetSurveyResponseForSurvey(surveyGuid);
            if (response == null)
            {
                throw new ItemNotFoundException($"Survey response for survey with id: {surveyId} was not found");
            }
            return response;
        }

    }
}
