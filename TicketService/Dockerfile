# Bu stage, uygulamanın build işlemini gerçekleştirir.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TicketService.csproj", "."]
RUN dotnet restore "TicketService.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet publish "TicketService.csproj" -c Release -o /app/publish /p:PublishReadyToRun=true

# Bu stage, uygulamayı çalıştırmak için minimal bir imaj oluşturur.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TicketService.dll"]