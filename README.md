# SurveyApi

SurveyApi is a .NET 9.0 Web API for managing surveys and survey responses. The API also includes functionality for comparing survey responses against benchmark data.

## Features

- Retrieve surveys
- Add and retrieve survey responses
- Compare survey responses against benchmark data
- OpenAPI and Swagger integration for API documentation
- CORS support for frontend applications

## Getting Started

### Prerequisites

- .NET 9.0 SDK

### Installation

1. Clone the repository:
git clone https://github.com/baklengesmats/surveyApi.git

2. Navigate to the project directory.
3. Restore the dependencies:
- dotnet restore

### Running the Application

1. Build the project:
- dotnet build
2. Run the project:
- dotnet run

The API will be available at `http://localhost:5283`.
Running on IIS Express on visual studio it will be at `https://localhost:44328`

### Using Swagger

Swagger UI is available at `http://localhost:5283/swagger`. It provides a user-friendly interface for exploring and testing the API endpoints.

## Project Structure

- `SurveyApi/Program.cs`: Configures the application and its services.
- `SurveyApi/Controllers`: Contains the API controllers.
- `SurveyApi/Repositories`: Contains the repository interfaces and implementations for accessing data.
- `SurveyApi/Services`: Contains the service interfaces and implementations for business logic.
- `SurveyApi/Common/Exceptions`: Contains custom exception classes.
- `SurveyApi/Repositories/DTO`: Contains data transfer objects (DTOs) for the API.
- `SurveyApi/Repositories/Models`: Contains the data models for the API.

## API Endpoints

- Survey API:
GET /Survey: Fetch all surveys.
GET /Survey/{id}: Fetch a survey by ID.

- Survey Response API:
GET /SurveyResponse/compareMean/{id}: Fetch mean grades for a survey.
GET /SurveyResponse/compareMedian/{id}: Fetch median grades for a survey.
POST /SurveyResponse/submit: Submit a survey response.

## Dependencies

- `Microsoft.AspNetCore.OpenApi`: For OpenAPI support.
- `Swashbuckle.AspNetCore`: For Swagger integration.

