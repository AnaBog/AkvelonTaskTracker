# Akvelon.TaskTracker

## Description 
This is a WEB API created with .NET 6.0, EntityFramework 6.0.6, Microsoft SQL Server Management Studio 18. 

This WEB API tracks the tasks and project. Each project has tasks, but each task can be a part of only one project. It has all the CRUD operations, as well as sorting and filtering. The entire program consists of three solutions, since this WEB API is a three-layered architecture. There is a Web Api layer, Data layer and Business layer. They are connected via Dependency Injection.
 

## Titles and internal titles

 - Akvelon.TaskTracker.WebApi
 - Akvelon.TaskTracker.BusinessLogic
 - Akvelon.TaskTracker.Repository
 - Akvelon.UnitTests

## Installation

### To be able to run this WEB API, please follow these steps:

- Before getting the code, please ensure that you have Visual Studio 2022 and Microsoft SQL Server Management Studio 18 installed on your PC
- Download zip file from GitHub (green button "Code" -> "Download ZIP"), extract it in the desired folder
- Open the Akvelon.TaskTracker.sln in Visual Studio
- Right-click on 'Solution Akvelon.TaskTracker' -> Manage NuGet packages for solution, and install the latest versions of the following:

        - Microsoft.EntityFrameworkCore
        - Microsoft.EntityFrameworkCore.Tools
        - Microsoft.EntityFrameworkCore.Design
        - Microsoft.EntityFrameworkCore.SqlServer
        - Microsoft.VisualStudio.Azure.Containers.Tools.Targets
        - xunit
        - xunit.runner.visualstudio
        - System.Runtime.CompilerServices.Unsafe
        - Swashbuckle.AspNetCore
        - Moq
        - FluentAssertions
        - Bogus
        - AutoMapper.Extensions.Microsoft.DependencyInjection
        - AutoMapper
        - AutoBogus

### Now, if you have installed Microsoft SQL Server Management Studio 18, you can now add migrations using Entity Framework and start the project. Below are the steps on adding the initial migration to create the database:

- Once you have opened the solution, in the lower end of VisualStudio, click on Package Manager Console
- For "Default Project" choose the option Akvelon.TaskTracker.Repository
- Type the following: Add-Migration CreateDatabase -o Data/Migrations
- When the migration is added, type Update-Database, and you can open the MSSMS to check if the database has appeared

### When the database is set up, you can run the project on green play button - this will open Swagger

### Swagger has all of the endpoints that we can now use

## Usage

- GET/api/Project
#### This endpoint contains all the filters and sort functionalities for Projects. By clicking on "Try it out", you can test: startProject, endProject, searchTerm, sortColumn, sortDirection, priority. 

    - startProject and endProject are dates, this is an example of the date to be used here: 2021-07-05T13:11:39.197Z

    - searchTerm is a string, for example "project"

    - sortColumn is the column we want to sort by (name, startDate, completeDate, priority and status)

    - sortDirection can be ascending or descending, can be tested by using either "asc" or "desc". If neither of these two are used, the program will automatically sort them in ascending order

    - Click Execute, and scroll down for response 

- POST/api/Project

#### This endpoint creates a new project with name, projectPriority and projectStatus fields. When these fields are filled out, click on Execute.

- GET/api/Project/{id} 

#### This endpoint gets a single Project with the specified id. 

- PUT/api/Project

#### This endpoint updates the existing Project via id. Fields that can be edited are name, projectPriority and projectStatus.

- DELETE/api/{id}

#### This endpoint deletes the project and all associated tasks with it.

- GET/api/Task 

#### This endpoint gets all the tasks from a selected project, Project id is needed for this action.

- POST/api/Task 

#### This endpoint creates a new task with Project id attached to it. Fields to be filled are name, taskDescription, taskPriority and taskStatus

- GET/api/Task/{id} 

#### This endpoint gets a task with a specified id.

- PUT/api/Task

#### This endpoint updates the task with specified id, and the fields to edit are name, taskDescription, taskPriority and taskStatus

- DELETE/api/Task/{id}

#### This deletes the specified task.

- PUT/api/Task/{taskId}/move-to-project

#### This endpoint moves a task from one project to another, using TaskId and ProjectId

# Unit Tests

Unit tests consist of classes that prepare the data for the tests, and tests for logic behind ProjectService.cs. These tests are done with xunit.

- Data 
  - GetAllData
  - GetAllInvalidProjectDateData
  - GetAllProjectSortedByNameData
  - UpdateAsync

- Services  
  - ProjectServiceTests

ProjectServiceTests test the following:

- GetAllProjects based on invalid data, this test should throw an exception
- GetAllProjects sorted by name, should return all projects sorted by name
- GetAllProjects even when the fields are null, return all projects
- GetById update project should update the project


## Support
For any further questions, or any help in starting the project, you can contact me on anabogdanovic995@gmail.com, I'd be happy to help or provide more information.