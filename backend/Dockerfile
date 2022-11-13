FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
WORKDIR /src
COPY . .
RUN dotnet restore "API/API.csproj"
RUN dotnet publish "API/API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 44303
EXPOSE 5000
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]