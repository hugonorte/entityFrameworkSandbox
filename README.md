
# Entity Framework Sandbox

Projeto criado para experimentar o SDK do Dotnet.

###  Dependências
- Docker
- Docker Compose Plugin

#### Instalação

1. Baixe esse repositório para o seu computador: 
```bash
git@github.com:hugonorte/entityFrameworkSandbox.git
```
2. Acesse a pasta do repositório recém-criado no seu computador
```bash
cd entityFrameworkSandbox
```
3. Crie uma pasta chamada "app" na raiz do projeto
```bash
mkdir app
```
4. Para usar o banco de dados, crie na raiz do seu projeto um arquivo .env para salvar as variáveis de ambiente
```bash
touch .env
```
5. Cole no conteúdo desse arquivo .env, as seguintes variáveis de ambiente:

```bash
MYSQL_ROOT_PASSWORD=RootPass123
MYSQL_DATABASE=sandbox_db
MYSQL_USER=sandbox_user
MYSQL_PASSWORD=UserPass456
```
6. Crie o ambiente com o Docker
```bash
docker compose up --build
```
Agora o ambiente está pronto para uso.
