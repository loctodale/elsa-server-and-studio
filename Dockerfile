# Use .NET SDK to build the solution
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and restore dependencies
COPY *.sln ./
COPY ElsaServer/ElsaServer.csproj ./ElsaServer/
COPY ElsaStudio/ElsaStudio.csproj ./ElsaStudio/
RUN dotnet restore

# Copy everything else and build the projects
COPY . .
RUN dotnet publish ElsaServer/ElsaServer.csproj -c Release -o /app/out

# Use ASP.NET runtime for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the built output
COPY --from=build /app/out .

## Expose ports
#EXPOSE 5000

# Start Elsa Server
ENTRYPOINT ["dotnet", "ElsaServer.dll"]
