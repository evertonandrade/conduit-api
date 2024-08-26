FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["src/WebApi/WebApi.csproj", "WebApi/"]
RUN dotnet restore 'WebApi/WebApi.csproj'

COPY ["src/WebApi/", "WebApi/"]
WORKDIR /src/WebApi
RUN dotnet build 'WebApi.csproj' -c Release -o /app/build

FROM build as publish
RUN dotnet publish 'WebApi.csproj' -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "WebApi.dll" ]
