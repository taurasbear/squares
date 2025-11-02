# Development stage (for hot-reloading)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev

# Install Visual Studio Debugger
RUN apt-get update && apt-get install -y curl unzip && \
    curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /remote_debugger && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

WORKDIR /app

COPY ["Squares.Server/Squares.Server.csproj", "Squares.Server/"]
COPY ["Squares.Application/Squares.Application.csproj", "Squares.Application/"]
COPY ["Squares.Infrastructure/Squares.Infrastructure.csproj", "Squares.Infrastructure/"]
COPY ["Squares.Domain/Squares.Domain.csproj", "Squares.Domain/"]
RUN dotnet restore "./Squares.Server/Squares.Server.csproj"

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "watch", "run", "--no-restore", "--no-launch-profile", "--project", "/app/Squares.Server/Squares.Server.csproj"]