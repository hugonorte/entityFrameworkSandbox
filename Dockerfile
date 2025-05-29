FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app
COPY ./app ./app
EXPOSE 8080
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
CMD ["dotnet", "watch", "--project", "TarefasAPI/TarefasAPI.csproj", "run", "--urls", "http://0.0.0.0:8080"]