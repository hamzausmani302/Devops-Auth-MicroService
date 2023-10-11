FROM ubuntu AS builder
WORKDIR /app/devops
CMD ["echo" , "hello wold"]
COPY ["SharedProject1" ,  "SharedProject1/"]


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app/devops
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app/devops
# restore project
COPY *.csproj project1/
RUN dotnet restore project1/DevopsAuthMicroService.csproj

COPY . project1/
RUN dotnet publish project1/DevopsAuthMicroService.csproj -c Release -o out /p:UseAppHost=false
COPY --from=builder /app/devops/SharedProject1 SharedProject1

FROM base as final
WORKDIR /app/devops
COPY --from=build /app/devops/out .
ENTRYPOINT ["dotnet" , "DevopsAuthMicroService.dll"]



