FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build 
COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish -c Release -o build
ENTRYPOINT ["dotnet", "build/WebApplication.EFCore.dll"]