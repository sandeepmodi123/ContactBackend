# Contacts Management Backend API

## Project Overview
This project is a .NET Core Web API that provides an interface to manage contacts in JSON file as a storage. It is designed to be a scalable, maintainable, and efficient solution for managing contacts.

## Table of Contents
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Built With](#built-with)
- [Run Application](#run-application)

## Getting Started
These instructions will help you set up the project on your local machine for development and testing purposes.

## Prerequisites
Before you begin, ensure you have the following software installed on your local machine:
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio or Visual Studio Code](https://visualstudio.microsoft.com/)

## Installation
1. Clone the repository to your local machine:
   ```sh
   git clone https://github.com/sandeepmodi123/ContactBackend.git
Navigate to the project directory:

  sh
  cd ContactBackend

Restore the project dependencies:

  sh
  dotnet restore
## Running the Application
Set up your log file path in nlog.config file.

  sh
  dotnet run
The API will be available at https://localhost:7129/swagger/index.html (or another port if specified).

## API Endpoints
Here are some of the main API endpoints:

GET /api/Contact - Retrieve all values

GET /api/Contact/{id} - Retrieve a value by ID

POST /api/Contact - Create a new value

PUT /api/Contact/{id} - Update an existing value

DELETE /api/Contact/{id} - Delete a value

## Built With
.NET Core 6.0

ASP.NET Core Web API

## Run Application
To run the application, open a solution in Visual Studio and run it. A Swagger UI will represent all endpoints for contact management.
