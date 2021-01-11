#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["GraphQLWebApplication/GraphQLWebApplication.csproj", "GraphQLWebApplication/"]
RUN dotnet restore "GraphQLWebApplication/GraphQLWebApplication.csproj"
COPY . .
WORKDIR "/src/GraphQLWebApplication"
RUN dotnet build "GraphQLWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GraphQLWebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQLWebApplication.dll"]