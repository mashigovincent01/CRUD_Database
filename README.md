# CRUD Application for Student Management

This README provides an overview of the CRUD (Create, Read, Update, Delete) application for managing student records. The application is built using ASP.NET MVC and interacts with a SQL Server database to perform CRUD operations.

## Table of Contents
- [Project Structure](#project-structure)
- [Setup Instructions](#setup-instructions)
- [Database Configuration](#database-configuration)
- [Controller Actions](#controller-actions)
- [Models](#models)
- [Views](#views)
- [Error Handling](#error-handling)
- [Future Enhancements](#future-enhancements)

## Project Structure
The project is organized into the following key components:
- **Models**: Contains the `Student` class representing the data structure.
- **Controllers**: Contains the `StudentController` which handles all CRUD operations.
- **Views**: Contains the views for displaying, creating, editing, and deleting student records.
- **Globals**: Contains the global settings such as the database connection string.

## Setup Instructions
1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   ```
   Open the project in Visual Studio:

Ensure you have Visual Studio with ASP.NET MVC and SQL Server support installed.
Restore NuGet packages:

Right-click on the solution in Visual Studio and select "Restore NuGet Packages."
Update the database connection string:

In Globals.cs, update the ConnectionString variable with your SQL Server instance details.
Run the application:

Press F5 or select "Start Debugging" from the Debug menu.
Database Configuration
This application requires a SQL Server database. The connection string is configured in the Globals class.

# Database Structure
The database should have a table named Student with the following structure:

sql
Copy code
```sql
CREATE TABLE Student (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) NOT NULL,
    StudentNo NVARCHAR(50) NOT NULL,
    GPA DECIMAL(3, 2) NOT NULL,
    Age INT NOT NULL
);
```
##Controller Actions
The StudentController handles the following CRUD operations:

##Index (Read)
Action: Index

Description: Retrieves and displays a list of all students.
Route: /Student/Index
Create (Create)
Action: Create
Description: Displays a form to create a new student and inserts the record into the database.
Route: /Student/Create
Method: GET and POST
Edit (Update)
Action: Edit
Description: Retrieves a specific student's details for editing and updates the record in the database.
Route: /Student/Edit/{id}
Method: GET and POST
Delete (Delete)
Action: Delete
Description: Deletes a student record based on the ID.
Route: /Student/Delete/{id}
# Models
## Student Model
The Student class represents the student entity with the following properties:

Id (int): The unique identifier for the student.

Name (string): The name of the student.

StudentNo (string): The student number.

GPA (decimal): The grade point average of the student.

Age (int): The age of the student.

# Views
The application includes the following views:

Index: Displays a list of all students.
Create: Form for creating a new student.
Edit: Form for editing an existing student.
Delete: Confirmation page for deleting a student.
Error Handling
Basic error handling is implemented using try-catch blocks in the controller actions. Errors are displayed using ViewBag.Error.
