# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY *.sln ./
COPY CleanArchitecture.Application/*.csproj CleanArchitecture.Application/
COPY CleanArchitecture.Domain/*.csproj CleanArchitecture.Domain/
COPY CleanArchitecture.Infastructure/*.csproj CleanArchitecture.Infastructure/
COPY CleanArchitecture.Presentation/*.csproj CleanArchitecture.Presentation/

# Restore dependencies
RUN dotnet restore CleanArchitecture.Presentation/CleanArchitecture.Presentation.csproj

# Copy source code
COPY . .

# Publish the app
RUN dotnet publish CleanArchitecture.Presentation/CleanArchitecture.Presentation.csproj -c Release -o /app/publish --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Set environment
ENV ASPNETCORE_ENVIRONMENT=Production

# Expose port (adjust if needed)
EXPOSE 8080

# Copy published app
COPY --from=build /app/publish .

# Run as non-root user
USER $APP_UID

# Start the app
ENTRYPOINT ["dotnet", "CleanArchitecture.Presentation.dll"]