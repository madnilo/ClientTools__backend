# ClientTool__backend

This project consists of the server side API for the ClientTools application. To run the solution, make sure you have .NET Core SDK 2.1 or higher. 

Download the source and run: `dotnet --project ./PartsTrader.ClientTools.API run`

For a better development experience use instead: `dotnet watch --project ./PartsTrader.ClientTools.API run`

The test suite can be run with the command: `dotnet test`

### Disclaimer 

The test project is currently unfinished, and most of the tests are commented. The problem seems to be related with the dependencies of the project, and I could not figure out how to solve the problem with Visual Studio for Mac. 

Status of the testing suite:
```
Controllers - Broken
Repositories - Broken
Services - Broken
Validators - OK
```

### The solution

This application serves the ClientTools frontend webapp. The clients from PartsTrader can utilize the simple UI to lookup for parts in the central catalogue. This catalogue was mocked for testing purposes.

#### Logging

NLog third party dependency was used to handle logging to files.

#### Validations

`DataAnnotations` were not used in this app. Instead, custom validators were implemented to facilitate unit testing and preserve the nature of POCOs as model classes. `Fluent Validation` was considered, but for the sake of the project it would be overkill.

#### Service layer

The service layer is responsible to validate business rules and transforms data between the repositories and controllers.

#### Repository 

The repositories call the external parts trader service. This call was replaced by a call to a json file just to facilitate the implementation.

#### TDD

The app was developed using TDD, despite the tests projects is having some issues when passing mocked dependencies to the components. Still investigating the issue. 

#### Documentation

`Swagger` (OpenAPi) was used to document the API for other developers. 