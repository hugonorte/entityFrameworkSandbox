# Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /app

# Copia os arquivos para dentro da imagem (opcional em dev)
COPY ./app ./app

# Instala a ferramenta dotnet-ef globalmente
RUN dotnet tool install -g dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Expõe a porta padrão da aplicação
EXPOSE 8080

# Usa polling para arquivos (necessário para watch em sistemas com volume bindado)
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV ASPNETCORE_URLS=http://+:5271

# Comando genérico: entra no shell para deixar o dev usar dotnet watch manualmente ou via docker-compose
CMD [ "bash" ]
