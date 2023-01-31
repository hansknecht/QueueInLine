#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EasyNetQ_QuickStart_Subscriber/EasyNetQ_QuickStart_Subscriber.csproj", "EasyNetQ_QuickStart_Subscriber/"]
COPY ["EasyNetQMessages/EasyNetQMessages.csproj", "EasyNetQMessages/"]
RUN dotnet restore "EasyNetQ_QuickStart_Subscriber/EasyNetQ_QuickStart_Subscriber.csproj"
COPY . .
WORKDIR "/src/EasyNetQ_QuickStart_Subscriber"
RUN dotnet build "EasyNetQ_QuickStart_Subscriber.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyNetQ_QuickStart_Subscriber.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyNetQ_QuickStart_Subscriber.dll"]