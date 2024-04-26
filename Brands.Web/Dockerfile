FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Brands.Web/Brands.Web.csproj", "Brands.Web/"]
COPY ["Brands.DataLayer/Brands.DataLayer.csproj", "Brands.DataLayer/"]
COPY ["Brands.Core/Brands.Core.csproj", "Brands.Core/"]
RUN dotnet restore "Brands.Web/Brands.Web.csproj"
COPY . .
WORKDIR "/src/Brands.Web"
RUN dotnet build "Brands.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Brands.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Brands.Web.dll"]