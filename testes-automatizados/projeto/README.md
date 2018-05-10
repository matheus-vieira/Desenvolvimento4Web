# Criando um projeto de testes

É uma prática recomendada criar um projeto separado para seus testes, para que eles sejam mantidos separados do código do aplicativo.

O novo projeto de teste deve estar em um diretório próximo (não dentro) do diretório do seu projeto principal.

Utilizando o Visual Studio para criar o projeto de testes.

Clique com o botão direto na Solution:

![Criando projeto de testes com o VS2017]({{ '/testes-automatizados/assets/images/vs-create.png' || relative_url}})

Na janela que aparece selecione o projeto `ToDo.UnitTests`.

![Nomeando o projeto]({{ 'testes-automatizados/assets/images/vs-nomear' | relative_url }})

Se você está atualmente no diretório do seu projeto, clique em um nível acima.(Esse diretório raiz também será chamado ToDo). Em seguida, use este comando para criar um novo projeto de teste:

```bash
dotnet new xunit -o ToDo.UnitTests
```

Saída

```bash
Getting ready...
The template "xUnit Test Project" was created successfully.

Processing post-creation actions...
Running 'dotnet restore' on ToDo.UnitTests/ToDo.UnitTests.csproj...
  Restoring packages for /mnt/c/Users/opet/Documents/github/Desenvolvimento4Web/testes-automatizados/source/ToDo/ToDo.UnitTests/ToDo.UnitTests.csproj...  Restoring packages for /mnt/c/Users/opet/Documents/github/Desenvolvimento4Web/testes-automatizados/source/ToDo/ToDo.UnitTests/ToDo.UnitTests.csproj...  Installing System.Collections.Specialized 4.0.1.
  Installing System.ComponentModel.Primitives 4.1.0.
  Installing System.ComponentModel 4.0.1.
  Installing System.ComponentModel.TypeConverter 4.1.0.
  Installing System.Diagnostics.TextWriterTraceListener 4.0.0.
  Installing System.ComponentModel.EventBasedAsync 4.0.11.
  Installing Microsoft.DotNet.PlatformAbstractions 1.0.3.
  Installing xunit.abstractions 2.0.1.
  Installing Microsoft.TestPlatform.ObjectModel 15.5.0.
  Installing Microsoft.Extensions.DependencyModel 1.0.3.
  Installing xunit.extensibility.core 2.3.1.
  Installing xunit.extensibility.execution 2.3.1.
  Installing Microsoft.TestPlatform.TestHost 15.5.0.
  Installing Microsoft.CodeCoverage 1.0.3.
  Installing xunit.core 2.3.1.
  Installing xunit.runner.visualstudio 2.3.1.
  Installing xunit.assert 2.3.1.
  Installing xunit 2.3.1.
  Installing Microsoft.NET.Test.Sdk 15.5.0.
  Installing xunit.analyzers 0.7.0.
  Installing System.Xml.XPath.XDocument 4.0.1.
  Installing System.Diagnostics.StackTrace 4.0.1.
  Installing Microsoft.NETCore.DotNetHost 1.0.1.
  Installing Microsoft.CodeAnalysis.Common 1.3.0.
  Installing System.Security.Principal.Windows 4.0.0.
  Installing System.Security.Claims 4.0.1.
  Installing runtime.native.System.Net.Security 4.0.1.
  Installing Microsoft.NETCore.DotNetHostResolver 1.0.1.
  Installing Microsoft.NETCore.Jit 1.0.2.
  Installing Microsoft.NETCore.Windows.ApiSets 1.0.1.
  Installing Microsoft.CodeAnalysis.VisualBasic 1.3.0.
  Installing Microsoft.CodeAnalysis.CSharp 1.3.0.
  Installing dotnet-xunit 2.3.1.
  Installing Microsoft.NETCore.App 1.0.0.
  Installing Libuv 1.9.0.
  Installing Microsoft.VisualBasic 10.0.1.
  Installing System.Net.NameResolution 4.0.0.
  Installing System.Net.Security 4.0.0.
  Installing System.ComponentModel.Annotations 4.1.0.
  Installing System.Net.Requests 4.0.11.
  Installing Microsoft.NETCore.Runtime.CoreCLR 1.0.2.
  Installing System.Numerics.Vectors 4.1.1.
  Installing System.IO.FileSystem.Watcher 4.0.0.
  Installing System.Reflection.DispatchProxy 4.0.1.
  Installing System.IO.UnmanagedMemoryStream 4.0.1.
  Installing System.IO.MemoryMappedFiles 4.0.0.
  Installing Microsoft.NETCore.DotNetHostPolicy 1.0.1.
  Installing System.Net.WebHeaderCollection 4.0.1.
  Installing System.Threading.Tasks.Parallel 4.0.1.
  Restore completed in 30.07 sec for /mnt/c/Users/opet/Documents/github/Desenvolvimento4Web/testes-automatizados/source/ToDo/ToDo.UnitTests/ToDo.UnitTests.csproj.
  Generating MSBuild file /mnt/c/Users/opet/Documents/github/Desenvolvimento4Web/testes-automatizados/source/ToDo/ToDo.UnitTests/obj/ToDo.UnitTests.csproj.nuget.g.props.
  Generating MSBuild file /mnt/c/Users/opet/Documents/github/Desenvolvimento4Web/testes-automatizados/source/ToDo/ToDo.UnitTests/obj/ToDo.UnitTests.csproj.nuget.g.targets.
  Restore completed in 30.19 sec for /mnt/c/Users/opet/Documents/github/Desenvolvimento4Web/testes-automatizados/source/ToDo/ToDo.UnitTests/ToDo.UnitTests.csproj.


Restore succeeded.
```

O xUnit.NET é um framework de teste popular para o código .NET que pode ser usado para escrever testes de unidade e de integração.

Como tudo mais, é um conjunto de pacotes do NuGet que podem ser instalados em qualquer projeto.

O novo modelo de xunit dotnet já inclui tudo o que você precisa.

Sua estrutura de diretórios deve estar assim:

```bash
ToDo/
    ToDoMvc/
        ToDoMvc.csproj
        Controllers/
        (etc...)

    ToDo.UnitTests/
        ToDo.UnitTests.csproj
```

Adicione o projeto à solution

```bash
dotnet sln ToDo.sln add ToDo.UnitTests/ToDo.UnitTests.csproj
Project `ToDo.UnitTests/ToDo.UnitTests.csproj` added to the solution.
```

Como o projeto de teste usará as classes definidas em seu projeto principal, você precisará adicionar uma referência ao projeto `ToDo`:

Com o VS2017 clique com o botão direito em `Dependências` e selecione `Adicionar Referência`.

![Adicionar referência]({{ 'testes-automatizados/assets/images/vs-add-referência' | relative_url }})

Na Janela que se segue selecione o projeto `TodoMvc`

![Selecionar o projeto]({{ 'testes-automatizados/assets/images/vs-sel-referência' | relative_url }})

```bashz
dotnet add reference ../TodoMvc/TodoMvc.csproj
Reference `..\TodoMvc\TodoMvc.csproj` added to the project.r
```

Exclua o arquivo `UnitTest1.cs` criado automaticamente.

```bash
rm UnitTest1.cs
```

Você está pronto para escrever seu primeiro teste.

> Se você estiver usando o Visual Studio Code,
> talvez seja necessário fechar e reabrir a janela
> do Visual Studio Code para obter a conclusão
> do código trabalhando no novo projeto.

## Escreva um teste de serviço

Dê uma olhada na lógica no método `AddItemAsync()` do `TodoItemService`:

```csharp
public async Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user)
{
    newItem.Id = Guid.NewGuid();
    newItem.IsDone = false;
    newItem.DueAt = DateTimeOffset.Now.AddDays(3);
    newItem.UserId = user.Id;

    _context.Items.Add(newItem);

    var saveResult = await _context.SaveChangesAsync();
    return saveResult == 1;
}
```

Esse método faz uma série de decisões ou suposições sobre o novo item (em outras palavras, executa a lógica de negócios no novo item) antes de realmente salvá-lo no banco de dados:

* A propriedade `UserId` deve ser configurada para o ID do usuário
* Novos itens devem estar sempre incompletos (`IsDone = false`)
* O título do novo item deve ser copiado de `newItem.Title`
* Novos itens devem sempre ser pagos daqui a 3 dias

Imagine se você ou outra pessoa refatorou o método `AddItemAsync()` e esqueceu de parte dessa lógica de negócios.

O comportamento do seu aplicativo pode mudar sem você perceber!

Você pode evitar isso escrevendo um teste que verifique duas vezes se essa lógica de negócios não foi alterada (mesmo que a implementação interna do método seja alterada).

> Pode parecer improvável agora que você possa
> introduzir uma mudança na lógica de negócios sem perceber,
> mas fica muito mais difícil acompanhar as decisões e suposições
> em um projeto grande e complexo.
> 
> Quanto maior o seu projeto, mais importante é ter verificações
> automatizadas que garantem que nada mudou!

Para escrever um teste de unidade que verificará a lógica no `TodoItemService`, crie uma nova classe em seu projeto de teste:

`ToDo.UnitTests/ToDoItemServiceShould.cs`

```csharp
using System;
using System.Threading.Tasks;
using ToDoMvc.Data;
using TodoMvc.Models;
using ToDoMvc.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ToDo.UnitTests
{
    public class ToDoItemServiceShould
    {
        [Fact]
        public async Task AddNewItemAsIncompleteWithDueDate()
        {
            // ...
        }
    }
}
```

> Existem muitas maneiras diferentes de nomear
> e organizar testes, todos com diferentes prós e contras.
>
> Adicionar o sufixo `Should` ajuda a inciar como deve funcionar.
>
> mas fique à vontade para usar seu próprio estilo!

O atributo `[Fact]` vem do pacote xUnit.NET e marca esse método como um método de teste.

O `TodoItemService` requer um `ApplicationDbContext`, que normalmente está conectado ao seu banco de dados. Você não vai querer usar isso para testes. Em vez disso, você pode usar o provider `in-memory database` do `Entity Framework Core` em seu código de teste. Como todo o banco de dados existe na memória, ele é apagado toda vez que o teste é reiniciado. E, como é um provider do `Entity Framework Core`, o TodoItemService não saberá a diferença!

Use um `DbContextOptionsBuilder` para configurar o provider `in-memory database` e, em seguida, faça uma chamada para `AddItemAsync()`:

```csharp
var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    .UseInMemoryDatabase(databaseName: "Test_AddNewItem").Options;

// Set up a context (connection to the "DB") for writing
using (var context = new ApplicationDbContext(options))
{
    var service = new ToDoItemService(context);

    var fakeUser = new ApplicationUser
    {
        Id = "fake-000",
        UserName = "fake@example.com"
    };

    await service.AddItemAsync(new NewToDoItem
    {
        Title = "Testing?",
        DueAt = DateTimeOffset.Now.AddDays(3)
    }, fakeUser);
}
```

A última linha cria um novo item de tarefa chamado `Testando?` e informa ao serviço para salvá-lo no banco de dados (na memória).

Para verificar se a lógica de negócios foi executada corretamente, escreva mais alguns códigos abaixo do bloco `using` existente:

```csharp
// Use a separate context to read data back from the "DB"
using (var context = new ApplicationDbContext(options))
{
    var itemsInDatabase = await context
        .Items.CountAsync();
    Assert.Equal(1, itemsInDatabase);

    var item = await context.Items.FirstAsync();
    Assert.Equal("Testing?", item.Title);
    Assert.Equal(false, item.IsDone);

    // Item should be due 3 days from now (give or take a second)
    var difference = DateTimeOffset.Now.AddDays(3) - item.DueAt;
    Assert.True(difference < TimeSpan.FromSeconds(1));
}
```

A primeira afirmação é uma verificação de integridade:

>  nunca deve haver mais de um item salvo no banco de dados na memória

Supondo que isso seja verdade, o teste recupera o item salvo com o `FirstAsync` e, em seguida, afirma que as propriedades estão definidas para os valores esperados.

> Os testes unitários e de integração geralmente seguem o padrão AAA (Arrange-Act-Assert):
>
> objetos e dados são configurados primeiro,
> 
> depois alguma ação é executada
>
> e, finalmente, o teste verifica (afirma) que o comportamento esperado ocorreu.

Assertar um valor de data e hora é um pouco complicado, uma vez que comparar duas datas para igualdade falhará se mesmo os componentes de milissegundos forem diferentes.

Em vez disso, o teste verifica se o valor de DueAt está a menos de um segundo do valor esperado.

## Execute o teste

No VS2017 vá no menu Testar > Executar > Todos os Testes

![Executando testes]({{ 'testes-automatizados/assets/images/vs-executar' | relative_url }})

Após será apresentada a janela `Gerenciador de Testes`

![Gerenciador de Testes]({{ 'testes-automatizados/assets/images/vs-executado' | relative_url }})

No terminal rode esse commando, estando na mesma pasta do projeto de teste

```bash
dotnet test
```

O comando `test` examina o projeto atual buscando testes (marcado com atributos `[Fact]` neste caso) e executa todos os testes que encontrar.

Você verá uma saída semelhante a:

```bash

Build started, please wait...
TodoItemServiceShould.cs(46,17): warning xUnit2004: Do not use Assert.Equal() to check for boolean conditions. [/mnt/c/Users/opet/Documents/github/Desenvolvimento4Web/testes-automatizados/source/ToDo/ToDo.UnitTests/ToDo.UnitTests.csproj]Build completed.

Test run for /mnt/c/Users/opet/Documents/github/Desenvolvimento4Web/testes-automatizados/source/ToDo/ToDo.UnitTests/bin/Debug/netcoreapp2.0/ToDo.UnitTests.dll(.NETCoreApp,Version=v2.0)
Microsoft (R) Test Execution Command Line Tool Version 15.5.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
[xUnit.net 00:00:01.4118510]   Discovering: ToDo.UnitTests
[xUnit.net 00:00:01.4930100]   Discovered:  ToDo.UnitTests
[xUnit.net 00:00:01.5009130]   Starting:    ToDo.UnitTests
[xUnit.net 00:00:02.0574600]   Finished:    ToDo.UnitTests

Total tests: 1. Passed: 1. Failed: 0. Skipped: 0.
Test Run Successful.
Test execution time: 3.1173 Seconds
```

Agora você tem um teste fornecendo cobertura de teste do `TodoItemService`.

Como um desafio extra, tente escrever testes de unidade que garantam:

* O método `MarkDoneAsync()` retorna `false` se é passado um` ID` que não existe
* O método `MarkDoneAsync()` retorna `true` quando faz um item válido como completo
* O método `GetIncompleteItemsAsync()` retorna apenas os itens pertencentes a um usuário em particular

