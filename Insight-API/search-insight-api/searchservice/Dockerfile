FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app
RUN mkdir /src
# Copy csproj and restore as distinct layers
COPY  search-insight-api.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 5008
ENTRYPOINT  ["dotnet", "search-insight-api.dll"]
