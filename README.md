# Contacts CRUD Project

## Overview

This project is built using .NET 6.0 and follows the Clean Architecture approach. It is structured into multiple logically separated libraries to promote modularity and maintainability. The project includes an ASP.NET Core Web API for CRUD operations on contact data and is designed with extensibility and clean separation of concerns in mind.

## Project Structure

### 1. `Contacts.Api`
- **Project Template**: ASP.NET Core Web API
- **Purpose**: Serves as the entry point for external clients, providing endpoints for CRUD operations. It handles all configurations, controllers, middlewares, and exception handling.
- **Responsibilities**:
  - Controller definitions for CRUD endpoints
  - Middleware setup for exception handling and request processing

### 2. `Contacts.Application`
- **Purpose**: Contains the core business logic and validation rules for incoming data. This layer is also home to shared tools and classes that simplify development.
- **Responsibilities**:
  - Business logic implementation using the **CQRS (Command Query Responsibility Segregation)** pattern, separating read (queries) and write (commands) operations for cleaner architecture and better scalability.
  - Data validation for incoming requests
  - Shared helper classes, behaviors, and custom exceptions

### 3. `Contacts.Common`
- **Purpose**: Used to avoid magic values throughout the project by storing common constants.
- **Responsibilities**:
  - Defines constants and common utility functions (if needed in the future)

### 4. `Contacts.Domain`
- **Purpose**: Defines the entities and domain models used by the application.
- **Responsibilities**:
  - Entity definitions representing business data
  - Domain-level logic (if applicable)

### 5. `Contacts.Infrastructure`
- **Purpose**: Manages database-related concerns, including `DbContext` and database migrations.
- **Responsibilities**:
  - Entity Framework `DbContext` setup
  - Database migrations and configurations

## Running the Project

To simplify running the project, a `docker-compose` file is provided for spinning up a PostgreSQL database instance. Ensure you have Docker installed and follow the steps below:

### Steps to Run the Project
1. Clone the repository.
2. Navigate to the project root directory.
3. Run the following command to start the PostgreSQL database:
   ```bash
   docker-compose up

## Comments

While the task description indicated creating a simple CRUD project, I chose to structure the project using multiple Class Libraries and follow a more modular approach with the Clean Architecture pattern. This decision might initially seem like an over-engineered solution for a test task, but I believe it is justified by the potential for future extensibility and maintainability.

### My Thought Process:
- **Single vs Multiple Projects**: It would have been possible to implement all logic in a single project without separating it into different Class Libraries. Additionally, I could have avoided using tools like **FluentValidation**, **MediatR**, and **CQRS**, opting instead for a simpler **Minimal API** approach.
- **Why This Approach?**: The structure might appear overly complex for a simple test assignment, but my decision was driven by considerations of how a real-world project often evolves. Functionality can expand rapidly, and a modular, well-defined architecture makes it easier to add new features, maintain existing code, and manage dependencies without creating a monolithic, tightly coupled codebase.
- **Balancing Complexity and Extensibility**: While I recognize that this approach introduces some initial complexity, it also makes scaling and adding features smoother. This was a deliberate choice, reflecting my experience and understanding of how maintainable codebases are built for long-term success.

In summary, I aimed to balance the simplicity expected for a test project with the kind of architectural decisions that would benefit a real-world application as it grows.

## Additional Considerations

While it would have been possible to create a unit testing library using **xUnit** to test various components of the project, I decided not to include this as part of the initial implementation. Since this is a test task, adding a comprehensive set of unit tests might have been perceived as overcomplicating the solution. My primary goal was to demonstrate a well-structured project architecture and the ability to implement core functionality effectively.

If creating unit tests was an expectation, I sincerely apologize for any oversight. However, I am fully capable of demonstrating unit testing skills upon request or in future tasks.

## Openness to Improvements

I recognize that no solution is perfect, and I am open to constructive feedback and suggestions for improvement. While I made certain architectural and design choices based on my understanding of the task and best practices, I am fully willing to revisit, refine, or adapt these decisions to align better with specific requirements or team preferences. Collaboration and continuous learning are central to my development philosophy, and I am always ready to enhance my approach for better results.