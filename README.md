# LabDatabasesBlazor

## About

LabDatabasesBlazor is a school project that demonstrates database interaction using Blazor WebAssembly. The application provides CRUD functionality for managing data in a relational database.

## Features

- **Blazor WebAssembly** frontend
- **Entity Framework Core** for database interactions
- **CRUD operations** (Create, Read, Update, Delete)
- **Configuration via `appsettings.json`**

## Prerequisites

- **.NET 9 SDK**
- **SQL Server** or another compatible database provider
- **Optional**: Visual Studio 2022 or Visual Studio Code for development

## Getting Started

### Clone the repository:

```sh
git clone https://github.com/Victor19941221/LabDatabasesBlazor.git
cd LabDatabasesBlazor
```

### Check `.gitignore` and `appsettings.json`
Ensure sensitive data (such as connection strings, passwords, and API keys) are not checked into source control. Use user secrets or environment variables for local development.

## Configuration

### Connection Strings
Update the `ConnectionStrings:DefaultConnection` in `appsettings.json` or `appsettings.Development.json`.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=YourDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## Running the Application

### Restore and Build:
```sh
dotnet restore
dotnet build
```

### Apply Migrations:
```sh
dotnet ef database update
```

### Run the application:
```sh
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000` by default (depending on launch settings).

## Database Setup

The project uses **Entity Framework Core Migrations** to manage the database schema.

### Create a new migration if needed:
```sh
dotnet ef migrations add InitialCreate
```

### Apply migrations to your local database:
```sh
dotnet ef database update
```

## Project Structure

```
LabDatabasesBlazor/
│── Components/           # Blazor components
│── Model/                # Data models
│── Service/              # Database and API services
│── wwwroot/              # Static web assets
│── Program.cs            # Application entry point
│── appsettings.json      # Configuration file
│── LabDatabasesBlazor.sln # Visual Studio solution file
```

## License

This code is open source and can be used under the MIT license.
