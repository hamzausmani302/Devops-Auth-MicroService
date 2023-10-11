FROM ubuntu AS builder
WORKDIR /app/devops
COPY ["SharedProject1" ,  "SharedProject1/"]


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app/devops
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app/devops
# restore project
COPY Devops-Auth-MicroService/DevopsAuthMicroService.csproj project1/
RUN dotnet restore project1/DevopsAuthMicroService.csproj

COPY Devops-Auth-MicroService/. project1/
COPY --from=builder /app/devops/SharedProject1 SharedProject1
RUN dotnet tool install -g Microsoft.dotnet-httprepl
RUN dotnet dev-certs https --trust
RUN dotnet publish project1/DevopsAuthMicroService.csproj -c Release -o out /p:UseAppHost=false

FROM base as final
WORKDIR /app/devops
COPY --from=build /app/devops/out .
ENTRYPOINT ["dotnet" , "DevopsAuthMicroService.dll"]



