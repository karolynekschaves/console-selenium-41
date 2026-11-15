# ConsoleSelenium41

Testes automatizados de interface com **Selenium WebDriver**, **MSTest** e **.NET 10**, aplicados ao formulário de práticas do Selenium:

https://www.selenium.dev/selenium/web/web-form.html

## Tecnologias

- C# / .NET 10
- MSTest
- Selenium.WebDriver
- Selenium.Support
- Google Chrome (o driver é baixado automaticamente pelo Selenium Manager)

## Estrutura do projeto

```
ConsoleSelenium41/
├── ConsoleSelenium41.sln
├── ConsoleSelenium/                          # Projeto console principal
│   └── ConsoleSelenium.csproj
└── ConsoleSelenium.Tests/                    # Projeto de testes
    ├── ConsoleSelenium.Tests.csproj
    ├── WebFormularioCadastroTest.cs          # Exercício 1
    ├── WebFormularioSelectDatalistTest.cs    # Exercício 2
    └── WebFormularioEstadosTest.cs           # Exercício 3
```

## Cenários de teste

| Exercício | Classe | O que valida |
|---|---|---|
| 1. Cadastro completo | `WebFormularioCadastroTest` | Preenchimento de text, password e textarea; valor padrão do input readonly; mensagem "Received!" após o envio |
| 2. Select e Datalist | `WebFormularioSelectDatalistTest` | Seleção da opção "Two" com `SelectElement` (value = 2); envio de "Seattle" no datalist; envio do formulário |
| 3. Checkboxes, radios e color picker | `WebFormularioEstadosTest` | Checkbox 1 marcado por padrão; marcação do checkbox 2; seleção do radio 2; alteração da cor via JavaScript; envio com sucesso |

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Google Chrome instalado
- Acesso à internet (o formulário é acessado online)

## Como executar

Clone o repositório e, na pasta da solution, rode:

```bash
dotnet restore
dotnet build
dotnet test
```

Para executar apenas uma classe de teste:

```bash
dotnet test --filter "FullyQualifiedName~WebFormularioCadastroTest"
dotnet test --filter "FullyQualifiedName~WebFormularioSelectDatalistTest"
dotnet test --filter "FullyQualifiedName~WebFormularioEstadosTest"
```

## Observações técnicas

- Cada teste abre e fecha seu próprio navegador (`[TestInitialize]` e `[TestCleanup]`), mantendo os testes independentes.
- O input de cor (`type="color"`) abre um seletor nativo do navegador que o Selenium não controla. Por isso o valor é definido com `IJavaScriptExecutor`, disparando os eventos `input` e `change`.
- O datalist é um `<input>` com sugestões, então basta usar `SendKeys`.

## Padrão de commits

O projeto segue [Conventional Commits](https://www.conventionalcommits.org/pt-br/):

- `test:` criação ou alteração de testes
- `chore:` configuração, dependências e `.gitignore`
- `refactor:` melhoria de código sem mudar comportamento
- `docs:` documentação
- `fix:` correção de erros

## Autora

Karolyne S