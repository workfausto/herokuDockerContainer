# Dockerfile

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

#ENV ASPNETCORE_URLS="0.0.0.0:5000"

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
#local command
ENTRYPOINT [ "dotnet", "herokuDockerContainer_netCore.dll" ]
#heroku command
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet herokuDockerContainer_netCore.dll 
#new version bby

################
