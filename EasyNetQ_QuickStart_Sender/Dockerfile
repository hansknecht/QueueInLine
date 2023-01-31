#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EasyNetQ_QuickStart_Sender/EasyNetQ_QuickStart_Sender.csproj", "EasyNetQ_QuickStart_Sender/"]
COPY ["EasyNetQMessages/EasyNetQMessages.csproj", "EasyNetQMessages/"]
RUN dotnet restore "EasyNetQ_QuickStart_Sender/EasyNetQ_QuickStart_Sender.csproj"
COPY . .
WORKDIR "/src/EasyNetQ_QuickStart_Sender"
RUN dotnet build "EasyNetQ_QuickStart_Sender.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyNetQ_QuickStart_Sender.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyNetQ_QuickStart_Sender.dll"]