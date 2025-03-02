# Use the official ASP.NET runtime image as the base image for the final container.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Set the working directory within the container.
WORKDIR /app
# Expose port 80 for HTTP traffic.
EXPOSE 80
# Expose port 443 for HTTPS traffic.
EXPOSE 443

# Use the official .NET SDK image as the build environment.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Set the working directory in the build container.
WORKDIR /src
# Copy the project file to the container. This helps with dependency caching.
COPY ["ProductsWeb.csproj", "."]

# Restore the NuGet packages specified in the project file.
RUN dotnet restore "./ProductsWeb.csproj"
# Copy the rest of the source code into the container.
COPY . .
# Build the project in Release configuration, outputting the result to /app/build.
RUN dotnet build "ProductsWeb.csproj" -c Release -o /app/build

# Create a new stage for publishing the application.
FROM build AS publish
# Publish the application in Release configuration to the /app/publish directory,
# and disable generating an executable host (UseAppHost=false) for a more portable image.
RUN dotnet publish "ProductsWeb.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage: create the runtime image.
FROM base AS final
# Set the working directory in the final image.
WORKDIR /app
# Copy the published output from the publish stage to the final image.
COPY --from=publish /app/publish .
# Set the entry point to run the application using the dotnet command.
ENTRYPOINT ["dotnet", "ProductsWeb.dll"]
