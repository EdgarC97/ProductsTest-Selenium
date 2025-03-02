
# Products Management System

A simple product management system built with .NET 8, consisting of a REST API and a web interface. The project includes Selenium tests for end-to-end testing.

## Project Structure


ProductsAPI/           # REST API project
├── Controllers/       # API endpoints
├── Models/           # Data models
└── Dockerfile        # API containerization

ProductsWeb/          # Web interface project
├── Controllers/      # MVC controllers
├── Models/          # View models
├── Views/           # Razor views
└── Dockerfile       # Web app containerization

ProductsWeb.Tests/    # Selenium test project
├── Pages/           # Page Object Models
└── Tests/           # Test cases

```plaintext

## Technologies Used

- .NET 8.0
- ASP.NET Core MVC
- ASP.NET Core Web API
- Selenium WebDriver
- Docker
- NUnit

## Prerequisites

- .NET SDK 8.0
- Docker Desktop
- Visual Studio 2022 or VS Code
- Chrome Browser (for Selenium tests)

## Getting Started

### Local Development

1. Clone the repository:
```bash
git clone https://github.com/EdgarC97/ProductsTest-Selenium
cd ProductsTest-Selenium
```

2. Restore dependencies:


```shellscript
dotnet restore
```

3. Build the solution:


```shellscript
dotnet build
```

4. Run the projects:


```shellscript
# Run API (from ProductsAPI directory)
dotnet run --project ProductsAPI

# Run Web App (from ProductsWeb directory)
dotnet run --project ProductsWeb
```

### Using Docker

1. Build and run using Docker Compose:


```shellscript
docker-compose up --build
```

The services will be available at:

- API: [http://localhost:7001](http://localhost:7001)
- Web Interface: [http://localhost:7002](http://localhost:7002)


### Running Tests

1. Make sure both the API and Web application are running
2. Execute the tests:


```shellscript
dotnet test ProductsWeb.Tests
```

## API Endpoints

### Products

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get a specific product
- `POST /api/products` - Create a new product
- `PUT /api/products/{id}` - Update a product
- `DELETE /api/products/{id}` - Delete a product


## Web Interface Features

- View all products
- Create new products
- Edit existing products
- Delete products


## Testing

The project includes Selenium tests that verify:

- Product listing functionality
- Product creation process


## Development Guidelines

1. **Code Style**

1. Follow C# coding conventions
2. Use meaningful names for classes and methods
3. Add comments for complex logic


2. **Testing**

1. Write tests for new features
2. Maintain existing tests
3. Use Page Object Model pattern for new pages


3. **Git Workflow**

1. Create feature branches
2. Write meaningful commit messages
3. Submit pull requests for review


## Troubleshooting

1. **Docker Issues**

1. Ensure Docker Desktop is running
2. Check port conflicts
3. Verify network connectivity between containers

  
Si necesitas detener los contenedores:

```shellscript
docker-compose down
```


2. **Test Failures**

1. Verify both API and Web app are running
2. Check Chrome WebDriver version
3. Review test logs for details


3. **Build Errors**

1. Clear solution
2. Restore NuGet packages
3. Rebuild solution


## Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

