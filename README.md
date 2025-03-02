Below is an updated version of your README in English with the project structure revised to include the Docker Compose file, without duplicating its code:

---

# Products Management System

A simple product management system built with .NET 8. It consists of a REST API, a web interface, and Selenium tests for end-to-end testing.

---

## Project Structure

```
ProductsTest-Selenium/
├── ProductsAPI/           # REST API project
│   ├── Controllers/       # API endpoints
│   ├── Models/            # Data models
│   ├── Dockerfile         # API containerization
│   
│
├── ProductsWeb/           # Web interface project
│   ├── Controllers/       # MVC controllers
│   ├── Models/            # View models
│   ├── Views/             # Razor views
│   ├── Dockerfile         # Web app containerization
│   ├── appsettings.Production.json  # Production configuration (uses Docker service names)
│   
│
├── ProductsWeb.Tests/     # Selenium test project
│   ├── Pages/             # Page Object Models
│   ├── Tests/             # Test cases
│   
│
└── docker-compose.yml     # Docker Compose configuration for the entire system
```

---

## Technologies Used

- .NET 8.0
- ASP.NET Core MVC
- ASP.NET Core Web API
- Selenium WebDriver
- Docker
- NUnit

---

## Prerequisites

- .NET SDK 8.0
- Docker Desktop
- Visual Studio 2022 or VS Code
- Chrome Browser (for Selenium tests)

---

## Getting Started

### Local Development

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/EdgarC97/ProductsTest-Selenium
   cd ProductsTest-Selenium
   ```

2. **Restore Dependencies:**

   ```bash
   dotnet restore
   ```

3. **Build the Solution:**

   ```bash
   dotnet build
   ```

4. **Run the Projects:**

   - For the API (from the `ProductsAPI` directory):
     ```bash
     dotnet run --project ProductsAPI
     ```
   - For the Web App (from the `ProductsWeb` directory):
     ```bash
     dotnet run --project ProductsWeb
     ```

### Using Docker

You can run the entire system using Docker Compose. The `docker-compose.yml` file is included in the project and defines two services—one for the API and one for the Web app. To build and run the containers, simply execute:

```bash
docker-compose up --build
```

After the containers are running, access the services at:

- **API:** [http://localhost:7001](http://localhost:7001)
- **Web Interface:** [http://localhost:7002](http://localhost:7002)

*Note:* In production, ensure that your configuration (e.g., in `appsettings.Production.json`) uses Docker service names (e.g., `http://api/api/products`) instead of `localhost` for internal communication between containers.

### Running Tests

1. Ensure both the API and the Web App are running.
2. Run the tests from the test project:

   ```bash
   dotnet test ProductsWeb.Tests
   ```

---

## API Endpoints

### Products

- **GET** `/api/products` – Retrieve all products.
- **GET** `/api/products/{id}` – Retrieve a specific product.
- **POST** `/api/products` – Create a new product.
- **PUT** `/api/products/{id}` – Update a product.
- **DELETE** `/api/products/{id}` – Delete a product.

---

## Web Interface Features

- View all products.
- Create new products.
- Edit existing products.
- Delete products.

---

## Testing

The project includes Selenium tests that verify:

- Product listing functionality.
- Product creation process.

---

## Development Guidelines

### Code Style

- Follow C# coding conventions.
- Use meaningful names for classes and methods.
- Add comments for complex logic.

### Testing

- Write tests for new features.
- Maintain existing tests.
- Use the Page Object Model pattern for new pages.

### Git Workflow

- Create feature branches.
- Write descriptive commit messages.
- Submit pull requests for review.

---

## Troubleshooting

### Docker Issues

- Ensure Docker Desktop is running.
- Check for port conflicts.
- Verify network connectivity between containers.

To stop the containers, run:

```bash
docker-compose down
```

### Test Failures

- Verify that both the API and Web App are running.
- Check the Chrome WebDriver version.
- Review test logs for details.

### Build Errors

- Clean the solution.
- Restore NuGet packages.
- Rebuild the solution.

---

## Contributing

1. **Fork** the repository.
2. Create your **feature branch**.
3. Commit your changes.
4. Push your changes to your branch.
5. Open a **Pull Request** for review.

---
