#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BasketMicroserviceCleanArchitecture/BasketMicroserviceCleanArchitecture.csproj", "BasketMicroserviceCleanArchitecture/"]
COPY ["BasketMicroserviceCleanArchitecture-Application/BasketMicroserviceCleanArchitecture-Application.csproj", "BasketMicroserviceCleanArchitecture-Application/"]
COPY ["BasketMicroserviceCleanArchitecture-Infrastracture/BasketMicroserviceCleanArchitecture-Infrastracture.csproj", "BasketMicroserviceCleanArchitecture-Infrastracture/"]
COPY ["BaketMicroservice-Domain/BaketMicroservice-Domain.csproj", "BaketMicroservice-Domain/"]
RUN dotnet restore "./BasketMicroserviceCleanArchitecture/./BasketMicroserviceCleanArchitecture.csproj"
COPY . .
WORKDIR "/src/BasketMicroserviceCleanArchitecture"
RUN dotnet build "./BasketMicroserviceCleanArchitecture.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BasketMicroserviceCleanArchitecture.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketMicroserviceCleanArchitecture.dll"]