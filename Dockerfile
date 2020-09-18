FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11
ENV MSBUILDSINGLELOADCONTEXT=1 BROWSER=chrome
WORKDIR /app
COPY ./src ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "test", "out/AdminAcceptanceTests.Tests.dll"]