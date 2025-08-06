# 📄 Documentação do Projeto: Sistema de Estacionamento (Bootcamp DIO - C#)

## 1. Visão Geral do Projeto 🚀
Este projeto é um sistema de gerenciamento de estacionamento desenvolvido em C#, como parte do bootcamp da DIO. Ele é uma aplicação de console 🖥️ que permite simular as operações básicas de um estacionamento, incluindo o registro de entrada e saída de veículos, a listagem dos veículos atualmente estacionados e o cálculo do valor a ser pago com base no tempo de permanência.

O objetivo principal é demonstrar conceitos fundamentais da linguagem C# e da Programação Orientada a Objetos (POO), como classes, objetos, encapsulamento, manipulação de coleções, tratamento de entrada de usuário e lógica de negócio.

## 2. Funcionalidades Atuais ✨
O sistema oferece as seguintes funcionalidades principais através de um menu interativo no console:

- Definição de Preços: Ao iniciar, o usuário configura o preço inicial (valor fixo de entrada) e o preço por hora de estacionamento. 💲

  **1 - Cadastrar Veículo:** 🚗➕
  
    - Solicita a placa do veículo ao usuário.
    - Verifica se a placa já está estacionada para evitar duplicidades.
    - Registra a placa e o DateTime (data e hora exata) da entrada do veículo no estacionamento.
    - Armazena as informações do veículo em uma lista interna.
  
  **2 - Remover Veículo**: 🚙➖
  
    - Solicita a placa do veículo que será removido.
    - Verifica se o veículo está realmente estacionado.
    - Calcula o tempo de permanência do veículo (diferença entre a hora de saída e a hora de entrada). ⏱️
    - Arredonda o tempo de permanência para a próxima hora cheia (ex: 2h10min são cobrados como 3h).
    - Calcula o valor total a ser pago com base no preço inicial e nas horas cobradas. 💰
    - Remove o veículo da lista de veículos estacionados.
    - Exibe a placa do veículo removido e o valor total a ser pago.
  
  **3 - Listar Veículos:** 📋👀
  
    - Exibe uma lista de todos os veículos atualmente estacionados, mostrando suas placas e as respectivas horas de entrada.
    - Informa se não há veículos estacionados.
  
  **4 - Encerrar:** 🚪👋
  
    - Finaliza a execução do programa.

### 3. Detalhes Técnicos e Conceitos Utilizados 💻
- O projeto é desenvolvido em **C#** e utiliza o framework **.NET.**

- Linguagem: **C#** 🧡

- Framework: **.NET 9.0 (ou superior, configurável no arquivo ``.csproj``)**

- Paradigma: **Programação Orientada a Objetos (POO)** 🧩

### Estrutura de Arquivos: 📁

- ``Program.cs:``
  
  - Ponto de entrada da aplicação (``Main`` method). ▶️

  - Gerencia o loop do menu principal e a interação inicial com o usuário (configuração de preços).

  - Instancia a classe ``Estacionamento``.

  - Realiza a validação robusta da entrada de dados para os preços iniciais e por hora usando ``decimal.TryParse()``. ✅

- ``Models/``: Diretório para classes de modelo/entidades.

  - ``Estacionamento.cs``:

    - Classe principal que encapsula a lógica de negócio do estacionamento. 🧠

    - Mantém o controle dos preços (``precoInicial``, ``precoPorHora``) e da lista de veículos estacionados (``List<Veiculo>``).

    - Contém os métodos ``AdicionarVeiculo()``, ``RemoverVeiculo()``, e ``ListarVeiculos()``.

  - ``Veiculo.cs``:

    - Classe que representa uma entidade ``Veiculo``. 🚗

    - Contém propriedades para ``Placa``(string) e ``HoraEntrada``(DateTime). ⏰

    - O construtor registra a ``HoraEntrada`` automaticamente ao criar um novo objeto ``Veiculo``.

## Conceitos de Programação Aplicados: 💡
- **Classes e Objetos:** Uso das classes Estacionamento e Veiculo para modelar o problema real.

- **Encapsulamento:** Propriedades e campos privados (``private``) com acesso controlado por métodos públicos, protegendo a integridade dos dados. 🔒

- **Listas Genéricas (``List<T>``):** Utilização de List<Veiculo> para armazenar e gerenciar dinamicamente os veículos estacionados, aproveitando sua capacidade de redimensionamento automático. 📊

- **Data e Hora (``DateTime`` e ``TimeSpan``)**: Registro e cálculo preciso do tempo de permanência dos veículos usando as classes ``DateTime`` (para pontos no tempo) e ``TimeSpan`` (para intervalos de tempo). 🗓️⏳

- **LINQ (Language Integrated Query):** Métodos como ``Any()``, ``FirstOrDefault()``, e ``RemoveAll()`` são utilizados para realizar consultas e manipulações eficientes na lista de veículos. 🔍

  - **``Any()``:** Verifica a existência de elementos que satisfazem uma condição.

  - **``FirstOrDefault()``:** Retorna o primeiro elemento que satisfaz uma condição ou null.

  - **``RemoveAll()``:** Remove todos os elementos que satisfazem uma condição.

- **Tratamento Robusto de Entrada:** Uso de ``decimal.TryParse()`` e ``int.TryParse()`` para converter entradas do usuário de forma segura, evitando que o programa falhe (crash) com entradas inválidas. ✅🛡️

- **Comparação de Strings Case-Insensitive:** Uso de ``StringComparison.OrdinalIgnoreCase`` para garantir que a comparação de placas ignore maiúsculas e minúsculas, aumentando a flexibilidade para o usuário. 🔡↔️

- **Controle de Fluxo:** Utilização de ``if/else``, ``switch/case`` e loops (``while``, ``foreach``) para gerenciar a lógica do programa. ➡️🔄

- **Formatação de Saída:** Formatação de valores monetários (``:F2``) e datas/horas para uma apresentação clara no console. 💲📅

### 4. Como Instalar e Rodar o Projeto 🚀⚙️
Para executar este projeto, você precisará ter o **.NET SDK** instalado em sua máquina.

#### Pré-requisitos: ✅
- SDK do .NET: Baixe e instale a versão 9.0 ou superior do .NET SDK. Você pode baixá-lo do site oficial da Microsoft: https://dotnet.microsoft.com/download/dotnet

**Recomendado:** **.NET SDK 9.0.x (x64)** para Windows (se estiver em outro SO, escolha a versão adequada).

#### Passos para Rodar: ▶️
- Obtenha o Código:

- Você pode baixar ou clonar o repositório do projeto para o seu computador. Assumindo que a pasta raiz do projeto é ``Estacionamento``. 📂

- Navegue até a Pasta do Projeto:

- Abra o Terminal (Windows Terminal, PowerShell, CMD) ou Prompt de Comando. 💻

- Use o comando cd para navegar até o diretório raiz do projeto onde o arquivo .csproj está localizado (ex: cd ``C:\Estudos\C#\Desafios\Estacionamento``).

- Execute o Projeto:

- No terminal, digite o seguinte comando:
  ```
  dotnet run
  ```
**O comando** ``dotnet run`` **irá automaticamente construir (compilar) e executar seu projeto. 🏗️**

### Alternativa (IDE): 👩‍💻

**Se estiver usando uma IDE como JetBrains Rider ou Visual Studio:**

- Abra a solução (``.sln``) ou o projeto (``.csproj``) na IDE.

- Certifique-se de que o "Target Framework" do projeto está configurado para .NET 9.0 (ou superior, conforme o SDK instalado).

- Clique no botão "Run" (geralmente um triângulo verde ▶️) na barra de ferramentas da IDE para compilar e executar o projeto.

### 5. Próximos Passos e Futuras Funcionalidades (Roadmap) 🛣️🎯
Este projeto de console é a base para um sistema de estacionamento mais completo. **Pretendo expandir este projeto significativamente**, adicionando as seguintes melhorias e expansões:

- **Desenvolvimento de Frontend:** A transição de uma interface de console para uma interface gráfica de usuário (GUI) ou web para melhorar a experiência do usuário. 🎨🌐

- **Integração com Banco de Dados:** Atualmente, os dados são perdidos ao encerrar o programa. Será implementada persistência de dados utilizando um banco de dados (ex: SQLite para simplicidade ou SQL Server para maior robustez), provavelmente com o auxílio do **Entity Framework Core**. 💾🗄️

- **Validação e Verificação Aprimorada de Placas:** Implementar validações de formato de placa mais rigorosas (ex: usando Expressões Regulares) para garantir que as placas inseridas sigam padrões específicos (Mercosul, antigo, etc.). ✅🔍

- **Gerenciamento de Vagas:** Adicionar uma funcionalidade para definir o número total de vagas e controlar a disponibilidade das mesmas. 🅿️↔️

- **Histórico e Relatórios:** Implementar a capacidade de consultar o histórico de veículos (entradas e saídas passadas) e gerar relatórios de faturamento diário, mensal, etc. 📈📜

- **Tratamento de Exceções:** Adicionar blocos ``try-catch`` mais específicos para tratar erros inesperados de forma graciosa. 🆘

Este é um projeto em constante evolução, e cada etapa adiciona novas camadas de aprendizado e funcionalidade, consolidando o conhecimento adquirido no bootcamp DIO. ✨🚀
