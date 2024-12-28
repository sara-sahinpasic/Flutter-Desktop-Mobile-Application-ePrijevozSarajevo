FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ePrijevozSarajevo.Subscriber/ePrijevozSarajevo.Subscriber.csproj", "ePrijevozSarajevo.Subscriber/"]
RUN dotnet restore "ePrijevozSarajevo.Subscriber/ePrijevozSarajevo.Subscriber.csproj"
COPY . .
WORKDIR "/src/ePrijevozSarajevo.Subscriber"
RUN dotnet build "ePrijevozSarajevo.Subscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ePrijevozSarajevo.Subscriber.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ePrijevozSarajevo.Subscriber.dll"]