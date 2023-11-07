# MiniQr - Backend Challenge

## Overview

MiniQr is a backend solution crafted as a technical challenge to showcase advanced software development skills. The project facilitates user management, including merchants and administrators, enabling the creation, cancellation, and status tracking of charges within the system.

## Getting Started

### Prerequisites

- Visual Studio 2022 or equivalent IDE

### Setup

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio 2022 or your preferred IDE.
3. Run the migrations
4. Run the API project to start the service.

## Technologies

- .NET 6
- Entity Framework Core
- Flurl Http for external HTTP calls
- MediatR for CQRS pattern implementation
- AutoMapper for object mapping
- Newtonsoft Json for JSON serialization

## Architecture

The codebase adopts a clean architecture model with business logic encapsulated in 'strategies'. The workflow is as follows:

- Controllers route incoming requests to services.
- Services transform data into commands using AutoMapper.
- MediatR dispatches commands to the domain layer.
- Domain handlers execute business rules through 'strategies' and commit the operations.

## Projects Structure

The system is modularized as follows:

- `DesafioBackendMiniQr.Api` - Presentation and request handling.
- `DesafioBackendMiniQrApi.Application` - Business logic and application services.
- `DesafioBackendMiniQrApi.Domain` - Core business entities and logic.
- `DesafioBackendMiniQrApi.Data` - Data persistence and retrieval.
- `DesafioBackendMiniQrApi.CrossCutting` - Cross-cutting concerns like logging, caching, etc.
- `DesafioBackendMiniQrApi.CrossCutting.IoC` - Dependency injection setup.
- `Pipedream.Integration` - External API integration handling.
- `DesafioBackendMiniQrApi.Tests` - Dedicated to unit and integration tests (to be developed).

## Future Improvements

- Implementation of unit tests for strategies, services, and repositories.
- Validation of HTTP requests with Flurl Http.

## License

This project is open-sourced under the MIT license.

## Contact

Paulo Vieira - paulo.cvieiradev@gmail.com

Project Link: https://github.com/linxpayhub/mini-qrlinx-backend

LinkedIn: https://www.linkedin.com/in/paulo-vieira-dev/

