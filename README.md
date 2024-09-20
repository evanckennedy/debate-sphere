# DebateSphere Web API

DebateSphere is a web API designed to provide a platform for creating, participating in, and voting on debates. It aims to promote critical thinking and structured discussions by enabling users to create debates, post arguments, and vote on the side they support.

## Table of Contents

- [Project Overview](#project-overview)
- [Architecture](#architecture)
- [Features](#features)
- [Installation](#installation)
- [Setup](#setup)
- [Usage](#usage)
- [Testing the API](#testing-the-api)
- [Future Enhancements](#future-enhancements)
- [Target Audience](#target-audience)
- [Use Cases](#use-cases)

## Project Overview

The DebateSphere API offers the following functionalities:
1. **User Management**: Register, login, and update profiles.
2. **Debate Management**: Create, update, and delete debates.
3. **Argument Management**: Post and manage arguments in debates.
4. **Voting System**: Cast votes on debates.

The API has 16 endpoints spanning user, debate, argument, and vote management.

## Architecture

The project follows a layered architecture with the following components:
- **Models**: Defines the structure of data stored in the database (users, debates, arguments, votes).
- **Data Access Layer (DAL)**: Handles database operations.
- **Business Logic Layer (BLL)**: Contains business logic for managing users, debates, arguments, and votes.

## Features

- **User Management**: Register, login, and view user details.
- **Debate Management**: Create and manage debates.
- **Argument Management**: Post and manage arguments in debates.
- **Voting System**: Cast votes and view vote counts.

---

## Installation

### Prerequisites

- **.NET 6.0 SDK**
- **SQL Server** (or another supported database)
- **Entity Framework Core**

### Setup

1. **Clone the repository**:

2. **Restore dependencies**:
   Navigate to the root folder and restore the necessary NuGet packages.

3. **Update the database connection string**:
   In `appsettings.json`, set the connection string for your SQL Server database

4. **Apply database migrations**:
   Run the following command to apply database migrations:
   ```bash
   dotnet ef database update
   ```

5. **Run the API**:

---

## Usage

Once the application is running, you can interact with the API using tools like [Postman](https://www.postman.com/) or directly through the provided Swagger UI.

### API Endpoints

- **User Endpoints**:
  - `POST /users/register`: Register a new user.
  - `POST /users/login`: Login an existing user.
  - `GET /users/{userId}`: Retrieve user details.
  - `PUT /users/{userId}`: Update user details.

- **Debate Endpoints**:
  - `POST /debates`: Create a new debate.
  - `GET /debates`: Retrieve a list of debates.
  - `GET /debates/{debateId}`: Get details of a specific debate.
  - `PUT /debates/{debateId}`: Update a debate.
  - `DELETE /debates/{debateId}`: Delete a debate.

- **Argument Endpoints**:
  - `POST /debates/{debateId}/arguments`: Post a new argument to a debate.
  - `GET /debates/{debateId}/arguments`: Get arguments for a debate.
  - `GET /arguments/{argumentId}`: Get a specific argument.
  - `PUT /arguments/{argumentId}`: Update an argument.
  - `DELETE /arguments/{argumentId}`: Delete an argument.

- **Vote Endpoints**:
  - `POST /debates/{debateId}/vote`: Cast a vote on a debate.
  - `GET /debates/{debateId}/votes`: Retrieve the total number of votes for each side.

---

## Testing the API

Once the API is running, you can use [Swagger](https://swagger.io/) for testing:

1. **Open Swagger UI**:
   After running the project, open a browser and go to:
   ```
   http://localhost:{port}/swagger
   ```
   (Replace `{port}` with the actual port the API is running on, e.g., `http://localhost:5000/swagger`).

2. **Test Endpoints**:
   Use the Swagger UI to test each of the 16 endpoints, filling out the required parameters and data.

---

## Future Enhancements

- **Token-based authentication** using JWT.
- **Password hashing** for improved security.
- **Comments**: Allow users to add comments to debates.
- **Trending Debates**: Retrieve the most popular debates.
- **User Roles**: Add roles such as admin, moderator, or guest.

---

## Target Audience

- **Developers**: Integrate debate functionality into applications or build debate platforms.
- **End-users**: Participate in online debates by posting arguments and voting.

---

## Use Cases

1. **Debate Platform**: Build an entire platform dedicated to online debates using the API.
2. **Feature Integration**: Add debate functionality to an existing website or application.