# EmployeeList
An exercise of listing employees by types of active or terminated.
To build it:
1. Run the SQL script employee.sql to create a SQL database with one table Employee. 
2. Build a project using asp.net core MVC.  
3. Change the connection string in appsettings.json file.
4. Add the data context in startup.cs file.
5. Replace Employee controller and other views with files in the repo. 
6. Run the solution and add a few employees with TerminationDate: -left blank for active employees - with dates in the past, inlcuding some in the last month. 

Voila! You can see the list of active employees, the employees terminated, or the full list.

