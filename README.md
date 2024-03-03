This is the Demo Application Security Portal. The purpose of this application is to have a centralized web application portal to control the Role and Identity Access Management for any Software application created by Developers.

The Application contains Applications Management where users can be able to create customers for which applications will be created for, they can create customer applications then create role groups for these customer application and dynamically create role that are inside of those applications.

Once they have completed managing their applications they can then on-board users and assign role to different applications
This application contains both the Backend Api and Front-end web application in the same solution. 

This application is created using Clean Architecture for the Backend and the Front-end

Backend:
-Contains Asp.net core web api using .NET 8 with Clean Architecture. 
-The Api is using the CQRS and Mediator and Repository Design Patterns
-The Api contains Api versioning and uses Swagger Documentation
-The Api uses JWT Authentication
-The Api has Global Exception Handling
-The Api is using Entity Framework Core ORM with the Database First Approach

Front-end:
-The Front-end is created using .NET Core Blazor WebAssembly as an Asp.net core hosted application using .NET 8 with Clean Architecture
-The Front-end is using Radzen UI Library: https://blazor.radzen.com/

