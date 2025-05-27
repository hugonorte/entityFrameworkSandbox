# Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dev
WORKDIR /app

# Copia os arquivos de código-fonte (caso já existam)
COPY ./app ./app

# Define porta padrão de execução
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

