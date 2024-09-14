# BoatRentalSystem Web API

## Overview

BoatRentalSystem is a web API designed to manage boat rental operations. It provides endpoints for managing boats, customers, rentals, and other related entities. This API is built using ASP.NET Core.

## Features

- **Boat Management**: Add, update, delete, and retrieve boat information.
- **Customer Management**: Manage customer details and their rental history.
- **Rental Operations**: Create, update, and manage boat rentals.
- **Authentication & Authorization**: Secure endpoints using JWT authentication.
- **Swagger Documentation**: Interactive API documentation using Swagger UI.

### Admin Features

- **User Management**:
  - Approve or reject registration requests from users.
- **Vehicle Management**:
  - Approve or reject boats registered by owners.
- **Reservation Management**:
  - Monitor and manage the list of reservations across the platform.

### Owner Features

- **Registration & Approval**:
  - Register on the platform and await approval from the Admin.
  - Add boats to the system, pending Admin approval.
- **Boat & Trip Management**:
  - Create and manage trips by selecting a boat from their fleet.
  - Add trip details, including trip name, description, price per person, capacity, and the maximum cancellation period.
- **Additions**:
  - Offer additional services or amenities that users can select when booking a boat or trip, each with its own pricing.
- **Financial Management**:
  - Manage a wallet for receiving payments.
  - Process refunds for canceled reservations.
  - Track reservations and cancellations.
### Customer Features
- **Registration & Wallet Management**:
  - Register on the platform and manage a wallet for payments.
- **Trip Booking**:
  - Browse and view available trips, including detailed descriptions.
  - Select the number of participants and any additional services, calculate the total cost, and pay using the wallet.
- **Boat Booking**:
  - Browse and view available boats.
  - Book a boat by selecting it and providing additional information, such as required services, purpose of booking, and crew needs.
- **Authentication & Authorization**: Secure endpoints using JWT authentication.
- **Swagger Documentation**: Interactive API documentation using Swagger UI.

## Technologies Used

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **AutoMapper**
- **Hangfire**
- **Serilog**
- **Swagger**
- **Repository Pattern**
- **MediatR**
- **CQRS**

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. **Clone the repository**:
    ```bash
    git clone https://github.com/shazlee00/BoatRentalSystem.git
    cd BoatRentalSystem
    ```

2. **Set up the database**:
    - Update the connection string in `appsettings.json`:
      ```json
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=BoatRentalDB;User Id=your_user;Password=your_password;"
      }
      ```
    - Apply migrations:
      ```bash
      dotnet ef database update
      ```

3. **Run the application**:
    ```bash
    dotnet run --project BoatRentalSystem.API
    ```

### Usage

- **Swagger UI**: Navigate to `https://localhost:5001/swagger` to explore the API endpoints.
- **Postman**: Import the provided Postman collection to test the API.

## Project Structure

- **BoatRentalSystem.API**: Contains the API controllers and startup configuration.
- **BoatRentalSystem.Application**: Business logic and service layer.
- **BoatRentalSystem.Core**: Core entities and interfaces.
- **BoatRentalSystem.Infrastructure**: Data access layer and repository implementations.


## Contact

For any inquiries or issues, please contact [melshazly56@gmail.com](mailto:yourname@domain.com).

---
