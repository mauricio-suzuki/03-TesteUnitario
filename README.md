# 🧪 Laboratório: Testes Unitários e TDD com C# e XUnit

> **Disciplina:** Qualidade de Software  
> **Duração estimada:** 2h  
> **Pré-requisitos:** Conta no GitHub, noções básicas de C#

---

## 📋 Sumário

1. [Objetivos de Aprendizagem](#-objetivos-de-aprendizagem)
2. [Revisão Teórica — Testes Unitários](#-revisão-teórica--testes-unitários)
3. [Revisão Teórica — TDD](#-revisão-teórica--tdd)
4. [Preparação do Ambiente](#%EF%B8%8F-preparação-do-ambiente)
5. [Estrutura do Repositório](#-estrutura-do-repositório)
6. [Parte 1 — Exemplo Guiado: Construtor da Conta Bancária](#-parte-1--exemplo-guiado-construtor-da-conta-bancária)
7. [Parte 2 — Exercício: Crie os Demais Testes](#-parte-2--exercício-crie-os-demais-testes)
8. [Referência Rápida — XUnit](#-referência-rápida--xunit)
9. [Entregáveis](#-entregáveis)

---

## 🎯 Objetivos de Aprendizagem

Ao final desta atividade, você será capaz de:

- Explicar o que são testes unitários e por que são importantes para a qualidade de software.
- Aplicar o ciclo **Red → Green → Refactor** da metodologia TDD.
- Escrever testes unitários em C# utilizando o framework **XUnit**.
- Usar os atributos `[Fact]` e `[Theory]` para diferentes cenários de teste.
- Executar testes de forma interativa dentro do VS Code.
- Organizar um projeto de testes seguindo as convenções do ecossistema .NET.

---

## 📖 Revisão Teórica — Testes Unitários

### O que é um Teste Unitário?

Um **teste unitário** é um trecho de código que verifica o comportamento de uma **unidade isolada** do sistema — geralmente um método ou função. O objetivo é garantir que cada parte do código funcione corretamente de forma independente.

### Características de um bom teste unitário

| Característica | Descrição |
|---|---|
| **Rápido** | Executa em milissegundos |
| **Isolado** | Não depende de banco de dados, rede ou outros testes |
| **Repetível** | Produz o mesmo resultado toda vez que é executado |
| **Auto-verificável** | O resultado é "passou" ou "falhou" — sem inspeção manual |
| **Oportuno** | Escrito no momento certo (idealmente antes do código, no TDD) |

> Essas características formam o acrônimo **F.I.R.S.T** (Fast, Isolated, Repeatable, Self-validating, Timely).

### O padrão AAA (Arrange-Act-Assert)

Todo teste unitário segue uma estrutura de três etapas:

```
Arrange  →  Preparar os dados e objetos necessários
Act      →  Executar a ação que será testada
Assert   →  Verificar se o resultado é o esperado
```

**Exemplo concreto em C# com XUnit:**

```csharp
[Fact]
public void Construtor_DadosValidos_CriaContaCorretamente()
{
    // Arrange & Act
    var conta = new Conta("Maria", 100);

    // Assert
    Assert.Equal("Maria", conta.Titular);
    Assert.Equal(100, conta.Saldo);
    Assert.True(conta.Ativa);
}
```

### Por que escrever testes unitários?

- **Detecção precoce de bugs:** encontra erros antes que cheguem à produção.
- **Documentação viva:** os testes descrevem o comportamento esperado do código.
- **Refatoração segura:** é possível alterar o código com confiança de que nada quebrou.
- **Redução de custo:** quanto mais cedo um defeito é encontrado, mais barato é corrigi-lo.

### Convenções de nomenclatura

Usaremos o padrão **`Método_Cenário_ResultadoEsperado`**:

```
Construtor_DadosValidos_CriaContaCorretamente
Depositar_ValorNegativo_LancaArgumentException
Sacar_SaldoInsuficiente_LancaInvalidOperationException
```

Isso torna os relatórios de teste autoexplicativos.

---

## 🔄 Revisão Teórica — TDD

### O que é TDD?

**Test-Driven Development** (Desenvolvimento Guiado por Testes) é uma metodologia onde os **testes são escritos antes do código de produção**. Foi popularizada por Kent Beck como parte das práticas de Extreme Programming (XP).

### O Ciclo Red → Green → Refactor

```
    ┌──────────────────────────────────────┐
    │                                      │
    │   🔴 RED                             │
    │   Escreva um teste que FALHE         │
    │                                      │
    │          │                           │
    │          ▼                           │
    │                                      │
    │   🟢 GREEN                           │
    │   Escreva o código MÍNIMO para       │
    │   o teste PASSAR                     │
    │                                      │
    │          │                           │
    │          ▼                           │
    │                                      │
    │   🔵 REFACTOR                        │
    │   Melhore o código mantendo          │
    │   todos os testes passando           │
    │                                      │
    │          │                           │
    │          └──────── ↩ Repita ─────────┘
    │
    └──────────────────────────────────────┘
```

**Detalhando cada etapa:**

| Etapa | O que fazer | Duração típica |
|---|---|---|
| 🔴 **Red** | Escrever um teste para um comportamento que *ainda não existe*. O teste deve **falhar**. | 1–3 min |
| 🟢 **Green** | Escrever o **código mínimo** necessário para que o teste passe. Não otimize ainda. | 1–5 min |
| 🔵 **Refactor** | Melhorar a estrutura do código (eliminar duplicação, renomear variáveis, simplificar lógica) **sem alterar o comportamento**. Todos os testes devem continuar passando. | 1–5 min |

### Benefícios do TDD

- **Design emergente:** o código nasce com responsabilidades claras e interfaces bem definidas.
- **Cobertura de testes alta por padrão:** se todo código nasce de um teste, a cobertura é naturalmente alta.
- **Feedback imediato:** erros são detectados em segundos, não em dias.
- **Confiança ao mudar código:** a suíte de testes funciona como uma rede de segurança.

### TDD **NÃO** é:

- ❌ Escrever o código e depois os testes (isso é "test-after").
- ❌ Escrever todos os testes de uma vez e depois todo o código.
- ❌ Uma garantia de que o software está livre de bugs (mas reduz muito o risco).

---

## ⚙️ Preparação do Ambiente

### Passo 1 — Fork do repositório

1. Acesse o repositório original no GitHub.
2. Clique no botão **"Fork"** (canto superior direito).
3. Selecione sua conta pessoal como destino.

### Passo 2 — Abrir no GitHub Codespaces

1. No **seu fork**, clique no botão verde **"<> Code"**.
2. Selecione a aba **"Codespaces"**.
3. Clique em **"Create codespace on main"**.
4. Aguarde o ambiente ser carregado (2–3 minutos na primeira vez).

> 💡 O Codespace já vem com o .NET SDK 10.0 e todas as extensões do VS Code pré-configuradas.

### Passo 3 — Verificar o ambiente

Abra o terminal integrado (`Ctrl + `` `) e execute:

```bash
dotnet --version
```

Deve exibir a versão 10.x. Em seguida, restaure os pacotes e compile:

```bash
dotnet restore
dotnet build
```

### Passo 4 — Conhecer o Test Explorer

A extensão **.NET Test Explorer** permite executar testes de forma visual:

1. Clique no ícone de **tubo de ensaio** (🧪) na barra lateral esquerda do VS Code.
2. Você verá a árvore de testes organizados por projeto e classe.
3. Clique no botão ▶️ ao lado de um teste para executá-lo individualmente.
4. Use o botão ▶️ no topo para executar **todos** os testes.

Você também pode executar testes pelo terminal:

```bash
# Executar todos os testes
dotnet test

# Executar com mais detalhes
dotnet test --verbosity normal

# Filtrar por nome
dotnet test --filter "NomeDoTeste"
```

---

## 📁 Estrutura do Repositório

```
tdd-xunit-csharp/
├── .devcontainer/
│   └── devcontainer.json          ← Configuração do Codespaces
├── .vscode/
│   └── extensions.json            ← Extensões recomendadas
├── src/
│   └── ContaBancaria/
│       ├── ContaBancaria.csproj   ← Projeto da biblioteca
│       └── Conta.cs               ← Classe de produção (construtor implementado)
├── tests/
│   └── ContaBancaria.Tests/
│       ├── ContaBancaria.Tests.csproj
│       └── ContaTests.cs          ← Testes (exemplo do construtor + você escreverá o restante)
├── TddXUnit.sln                   ← Solution file
├── .gitignore
└── README.md                      ← Este roteiro
```

---

## 🟢 Parte 1 — Exemplo Guiado: Construtor da Conta Bancária

> **Objetivo:** Entender a estrutura de um teste unitário com XUnit e o ciclo TDD, usando o construtor da classe `Conta` como exemplo completo.

### 1.1 Analisar o código de produção

Abra o arquivo `src/ContaBancaria/Conta.cs` e observe o **construtor** da classe `Conta`. Ele já está implementado com as seguintes regras:

- O **titular** não pode ser nulo ou vazio (lança `ArgumentException`).
- O **saldo inicial** não pode ser negativo (lança `ArgumentException`).
- A conta é criada como **ativa**.

Os **demais métodos** (`Depositar`, `Sacar`, `Transferir`, `Encerrar`) ainda não estão implementados — lançam `NotImplementedException`. É você quem vai implementá-los usando TDD na Parte 2.

### 1.2 Analisar os testes do construtor

Abra `tests/ContaBancaria.Tests/ContaTests.cs` e analise os testes prontos para o **Construtor**:

- **`Construtor_DadosValidos_CriaContaCorretamente`** — teste básico com `[Fact]` que verifica titular, saldo e status ativo.
- **`Construtor_SemSaldoInicial_CriaContaComSaldoZero`** — testa o valor padrão do saldo.
- **`Construtor_TitularNulo_LancaArgumentException`** — testa cenário de exceção.
- **`Construtor_TitularVazio_LancaArgumentException`** — outro cenário de exceção.
- **`Construtor_SaldoNegativo_LancaArgumentException`** — valida regra de negócio.
- **`Construtor_VariosValoresValidos_CriaContaCorretamente`** — teste parametrizado com `[Theory]` e `[InlineData]`.

### 1.3 Executar os testes do construtor

No terminal, execute:

```bash
dotnet test tests/ContaBancaria.Tests --filter "Construtor"
```

Ou pelo Test Explorer, expanda **ContaBancaria.Tests → ContaTests** e clique ▶️ nos testes de `Construtor`.

✅ Todos os testes do construtor devem **passar** (verde).

### 1.4 Pontos a observar

Analise atentamente os testes do construtor e observe:

- **Padrão AAA:** cada teste segue a estrutura Arrange → Act → Assert.
- **`[Fact]`** é usado para testes com valores fixos (sem parâmetros).
- **`[Theory]` + `[InlineData]`** permite executar o mesmo teste com valores diferentes.
- **`Assert.Throws<T>`** verifica que uma exceção específica é lançada.
- **Nomenclatura:** os nomes dos testes seguem `Método_Cenário_ResultadoEsperado`.
- **Cobertura:** há testes para o caminho feliz, cenários de exceção e casos de borda.

### 1.5 Entendendo o ciclo TDD aplicado ao construtor

Vamos recapitular como o construtor foi implementado seguindo TDD:

#### 🔴 RED — O teste foi escrito primeiro

```csharp
[Fact]
public void Construtor_DadosValidos_CriaContaCorretamente()
{
    var conta = new Conta("Maria", 100);

    Assert.Equal("Maria", conta.Titular);
    Assert.Equal(100, conta.Saldo);
    Assert.True(conta.Ativa);
}
```

Com o construtor lançando `NotImplementedException`, este teste **falhava**.

#### 🟢 GREEN — O código mínimo foi implementado

```csharp
public Conta(string titular, decimal saldoInicial = 0)
{
    if (string.IsNullOrWhiteSpace(titular))
        throw new ArgumentException("O titular não pode ser nulo ou vazio.", nameof(titular));
    if (saldoInicial < 0)
        throw new ArgumentException("O saldo inicial não pode ser negativo.", nameof(saldoInicial));

    Titular = titular;
    Saldo = saldoInicial;
    Ativa = true;
}
```

Após implementar, o teste **passou**.

#### 🔵 REFACTOR — O código já está limpo

Neste caso, não há necessidade de refatoração. Em métodos mais complexos, esta é a hora de eliminar duplicação e melhorar nomes.

---

## 🏦 Parte 2 — Exercício: Crie os Demais Testes

> **Objetivo:** Praticar TDD do zero, escrevendo testes e implementando os métodos restantes da classe `Conta`.

Agora é a sua vez! Usando como modelo os testes do construtor, você deve aplicar o ciclo TDD para cada um dos métodos abaixo.

### Requisitos

Abra o arquivo `src/ContaBancaria/Conta.cs` e leia a documentação de cada método. Você encontrará:

| Método | Regras |
|---|---|
| **Depositar** | Valor > 0, conta ativa |
| **Sacar** | Valor > 0, conta ativa, saldo suficiente |
| **Transferir** | Ambas ativas, valor > 0, saldo suficiente |
| **Encerrar** | Conta ativa, saldo = 0 |

### Instruções

1. Abra `tests/ContaBancaria.Tests/ContaTests.cs`.
2. Leia as **sugestões de testes** nos comentários de cada seção.
3. Para **cada método**, siga o ciclo TDD:
   - 🔴 Escreva **um** teste → execute → veja falhar.
   - 🟢 Implemente o código mínimo em `Conta.cs` → execute → veja passar.
   - 🔵 Refatore se necessário.
   - Repita para o próximo cenário de teste.

### Exemplo de como começar — Teste do Depositar

Siga o mesmo padrão dos testes do construtor:

```csharp
[Fact]
public void Depositar_ValorValido_AtualizaSaldo()
{
    // Arrange
    var conta = new Conta("Maria", 100);

    // Act
    conta.Depositar(50);

    // Assert
    Assert.Equal(150, conta.Saldo);
}
```

1. Escreva este teste e **execute** → ele vai **falhar** (🔴) porque `Depositar` lança `NotImplementedException`.
2. Vá até `Conta.cs` e implemente o código mínimo de `Depositar` → execute → veja **passar** (🟢).
3. Refatore se necessário (🔵).
4. Escreva o próximo teste (ex: `Depositar_ValorZero_LancaArgumentException`) e repita o ciclo.

### Dicas

**Para testar exceções**, use `Assert.Throws<T>`:

```csharp
[Fact]
public void Depositar_ValorNegativo_LancaArgumentException()
{
    var conta = new Conta("Maria", 100);
    Assert.Throws<ArgumentException>(() => conta.Depositar(-10));
}
```

**Para testar conta inativa**, você precisa primeiro encerrar a conta (o que requer implementar `Encerrar` antes). Planeje a ordem de implementação!

**Para testar `Transferir`**, crie duas contas e verifique os saldos de ambas:

```csharp
[Fact]
public void Transferir_ValorValido_AtualizaSaldoDeAmbasContas()
{
    var origem = new Conta("Maria", 200);
    var destino = new Conta("João", 100);

    origem.Transferir(destino, 50);

    Assert.Equal(150, origem.Saldo);
    Assert.Equal(150, destino.Saldo);
}
```

### Executar testes

```bash
# Todos os testes
dotnet test tests/ContaBancaria.Tests

# Filtrar por método
dotnet test tests/ContaBancaria.Tests --filter "Depositar"
dotnet test tests/ContaBancaria.Tests --filter "Sacar"
```

> ⚠️ **Mínimo exigido:** Crie pelo menos **15 testes** cobrindo todos os métodos da classe `Conta`.

---

## 📘 Referência Rápida — XUnit

### Atributos de teste

| Atributo | Uso |
|---|---|
| `[Fact]` | Teste com valores fixos (sem parâmetros) |
| `[Theory]` | Teste parametrizado (executado N vezes) |
| `[InlineData(...)]` | Fornece dados inline para `[Theory]` |

### Assertions comuns

```csharp
// Igualdade
Assert.Equal(esperado, resultado);

// Booleanos
Assert.True(condicao);
Assert.False(condicao);

// Nulos
Assert.Null(objeto);
Assert.NotNull(objeto);

// Exceções
Assert.Throws<TipoExcecao>(() => metodoQueLanca());

// Strings
Assert.Contains("texto", resultado);
Assert.StartsWith("prefixo", resultado);

// Coleções
Assert.Empty(lista);
Assert.Contains(item, lista);
Assert.Equal(tamanhoEsperado, lista.Count);

// Intervalos numéricos (para doubles)
Assert.InRange(resultado, minimo, maximo);
```

### Executando testes no terminal

```bash
# Todos os testes
dotnet test

# Filtrar por nome
dotnet test --filter "NomeDoTeste"

# Filtrar por classe
dotnet test --filter "FullyQualifiedName~ContaTests"

# Com detalhes
dotnet test --verbosity normal

# Com cobertura (requer coverlet)
dotnet test --collect:"XPlat Code Coverage"
```

---

## 📦 Entregáveis

Para comprovar a realização da atividade, você deve entregar as seguintes evidências no **seu fork** do repositório:

### ✅ Checklist obrigatório

| # | Entregável | Descrição | Arquivo |
|---|---|---|---|
| 1 | **Testes da Conta Bancária** | Mínimo de **15 testes** cobrindo todos os métodos | `tests/ContaBancaria.Tests/ContaTests.cs` |
| 2 | **Código da Conta Bancária** | Classe `Conta.cs` totalmente implementada (sem `NotImplementedException`) | `src/ContaBancaria/Conta.cs` |
| 3 | **Todos os testes passando** | Screenshot ou saída do terminal mostrando `dotnet test` com todos os testes passando | Incluir no commit |
| 4 | **Histórico de commits** | Commits **incrementais** mostrando o ciclo TDD (ex: "red: teste Depositar", "green: implementa Depositar") | Histórico do Git |

### 📸 Screenshot dos testes

Após concluir, execute e capture a saída:

```bash
dotnet test --verbosity normal > resultado-testes.txt 2>&1
```

Faça o commit do arquivo `resultado-testes.txt` junto com seu código.

### 🔀 Padrão de commits (recomendado)

Use prefixos para documentar o ciclo TDD nos commits:

```
red:      teste para Depositar - valor válido
green:    implementa Depositar
refactor: simplifica validação do Depositar

red:      teste para Sacar - saldo insuficiente
green:    implementa Sacar com validação
refactor: extrai validação para método privado
```

### 📤 Como entregar

1. Faça commit de todas as alterações:
   ```bash
   git add .
   git commit -m "Atividade TDD completa"
   git push origin main
   ```
2. Confirme que o código está no **seu fork** no GitHub.
3. Envie o **link do seu repositório (fork)** no ambiente virtual da disciplina.

---

## 📚 Referências

- [XUnit — Documentação Oficial](https://xunit.net/)
- [Testes unitários no .NET — Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/core/testing/unit-testing-with-dotnet-test)
- [TDD — Martin Fowler](https://martinfowler.com/bliki/TestDrivenDevelopment.html)
- [Padrão AAA — Arrange, Act, Assert](https://learn.microsoft.com/pt-br/visualstudio/test/unit-test-basics)

---

> **Bom trabalho!** Lembre-se: no TDD, o teste sempre vem primeiro. 🧪🔴🟢🔵
