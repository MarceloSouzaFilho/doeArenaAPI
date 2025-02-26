DoeArenaAPI

DoeArenaAPI é uma API desenvolvida em .NET Core que realiza web scraping na página da campanha Doe Arena, promovida pelo Corinthians, para obter informações sobre as doações arrecadadas e a meta atingida.

Funcionalidades

Extrai o valor total arrecadado até o momento.

Obtém o percentual da meta já atingido.

Exibe os dados em um formato estruturado via API.

Requisitos

.NET Core SDK 7.0 ou superior

Dependências listadas no projeto

Instalação

Clone este repositório:

git clone https://github.com/MarceloSouzaFilho/doeArenaAPI.git

Acesse o diretório do projeto:

cd doeArenaAPI

Restaure as dependências:

dotnet restore

Execute a aplicação:

dotnet run

Uso

A API fornece endpoints para acessar os dados extraídos do site.

1. Obter informações de doações

Endpoint: GET /doacoes

Resposta:

{
    "total_arrecadado": "R$ 100.000,00",
    "percentual_meta": "25%"
}

Contribuição

Sinta-se à vontade para abrir issues e pull requests para melhorias no projeto.

Licença

Este projeto é licenciado sob a MIT License. Veja o arquivo LICENSE para mais detalhes.
