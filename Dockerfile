FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
ARG port
ENV PORT=$port

WORKDIR /app

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out ./
EXPOSE $PORT
ENV ASPNETCORE_URLS=http://+:$PORT
ENTRYPOINT ["dotnet", "WeatherBot.Sunny.dll"]
