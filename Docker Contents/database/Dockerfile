#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.



FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:2.1-alpine AS build
WORKDIR /src
COPY ["Brands.sln", "Brands.sln"]
COPY ["Brands.Web", "Brands.Web"]
COPY ["Brands.DataLayer", "Brands.DataLayer"]
COPY ["TestLayer", "TestLayer"]
COPY ["Brands.Core", "Brands.Core"]
RUN dotnet restore "Brands.sln"
WORKDIR "/src/Brands.Web"
RUN dotnet build "Brands.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Brands.Web.csproj" -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Brands.Web.dll"]
#ENV ASPNETCORE_ENVIRONMENT=Development