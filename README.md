# ToDoApp

ToDoApp is a simple task management application built with Angular 15, .NET Core, and Microsoft SQL Server. It allows users to create, update, and delete tasks, providing a basic interface to manage their to-do list.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Running the Application](#running-the-application)
- [Testing](#testing)
- [Usage](#usage)
- [Assumptions and Decisions](#assumptions-and-decisions)

## Prerequisites

Before running the application, ensure that you have the following prerequisites installed on your machine:

- Node.js and npm
- Angular CLI (`npm install -g @angular/cli`)
- Visual Studio 2022
- Microsoft SQL Server

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/Harshavardhan1901/ToDoApp.git

2. Navigate to the project directory:

   ```bash
   cd ToDoApp

3. Install Angular dependencies:

   ```bash
   cd ToDoApp.Web
   npm install
   
4. Install .NET dependencies:

   ```bash
   cd ToDoApp.API
   dotnet restore
   
5. Create a SQL Server database named 'ToDoAppDb'.

6. Update the connection string in appsettings.json in the ToDoApp.API project with your SQL Server details.

## Running the Application

1. Run the API (from the ToDoApp.API directory):

   ```bash
   dotnet run

  The API will be available at 'http://localhost:5031'.

2. Run the Angular app (from the ToDoApp.Web directory):

   ```bash
   ng serve
The Angular app will be available at 'http://localhost:4200'.

## Testing

1. Open Visual Studio and navigate to Test > Test Explorer.
2. Click the "Run All Tests" button to execute backend tests.

## Usage

1. Open your browser and navigate to http://localhost:4200.
2. Use the interface to manage your to-do list:
    - Click "Add Task" to create a new task.
    - Click "Edit" to update a task.
    - Click "Delete" to remove a task.

## Assumptions and Decisions

- **Database Connection:** The application assumes a SQL Server database named 'ToDoAppDb'. The connection string is set in 'appsettings.json' for the API.

- **Frontend Styling:** Bootstrap is used for basic styling.  You can customize the styles based on your preferences.

- **Testing Frameworks:** NUnit is used for backend testing. Feel free to choose other testing frameworks if preferred.

- **Cross-Origin Resource Sharing (CORS):** CORS is configured to allow requests from 'http://localhost:4200'. Update it based on your deployment scenario.

### Feel free to reach out if you have any questions or encounter issues during setup or usage. Enjoy managing your tasks with ToDoApp!
