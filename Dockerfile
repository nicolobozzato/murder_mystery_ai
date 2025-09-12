# Dockerfile per backend .NET

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
# Copia tutti i progetti necessari
COPY MurderMysteryAI.Api/MurderMysteryAI.Api.csproj MurderMysteryAI.Api/
COPY MurderMysteryAI.Domain/MurderMysteryAI.Domain.csproj MurderMysteryAI.Domain/
COPY MurderMysteryAI.Application/MurderMysteryAI.Application.csproj MurderMysteryAI.Application/
COPY MurderMysteryAI.Infrastructure/MurderMysteryAI.Infrastructure.csproj MurderMysteryAI.Infrastructure/
# Ripristina i pacchetti
RUN dotnet restore "MurderMysteryAI.Api/MurderMysteryAI.Api.csproj"
# Copia tutto il codice sorgente
COPY . .
WORKDIR /src/MurderMysteryAI.Api
RUN dotnet build "MurderMysteryAI.Api.csproj" -c Release -o /app/build
RUN dotnet publish "MurderMysteryAI.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MurderMysteryAI.Api.dll"]
