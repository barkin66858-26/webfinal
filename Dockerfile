FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FitnessApp.csproj", "./"]
RUN dotnet restore "FitnessApp.csproj"
COPY . .
RUN dotnet publish "FitnessApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
COPY fitness.db .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "FitnessApp.dll"]
