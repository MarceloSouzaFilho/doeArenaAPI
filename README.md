# DoeArenaAPI

DoeArenaAPI é uma API desenvolvida em .NET Core que realiza web scraping na página da campanha [Doe Arena](https://www.doearena.com.br), promovida pelo Corinthians, para obter informações sobre as doações arrecadadas e a meta atingida.

## 📌 Funcionalidades

- 🔍 Extrai o valor total arrecadado até o momento.
- 📊 Obtém o percentual da meta já atingido.
- ⚡ Exibe os dados em um formato estruturado via API.

## 🔧 Requisitos

- .NET Core SDK 7.0 ou superior
- Dependências listadas no projeto

## 🚀 Instalação

1. Clone este repositório:
   ```sh
   git clone https://github.com/MarceloSouzaFilho/doeArenaAPI.git

## 📡 Uso
A API fornece endpoints para acessar os dados extraídos do site.

📌 1. Obter informações de doações
Endpoint: GET /getDoeArena
Resposta:
json
{
    "arrecadadoAtual": "R$ 1.000.000,00",
    "dataAtualizacao": "2025-02-25T12:00:00Z",
    "dataProximaAtualizacao": "2025-02-25T14:00:00Z",
    "meta": "R$ 2.000.000,00",
    "quantoFalta": "R$ 1.000.000,00"
}

## 🤝 Contribuição
Sinta-se à vontade para abrir issues e pull requests para melhorias no projeto.

## 📜 Licença
Este projeto é licenciado sob a MIT License. Veja o arquivo LICENSE para mais detalhes.
