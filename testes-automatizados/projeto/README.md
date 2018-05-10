# Criando um projeto de testes

É uma prática recomendada criar um projeto separado para seus testes, para que eles sejam mantidos separados do código do aplicativo.

O novo projeto de teste deve estar em um diretório próximo (não dentro) do diretório do seu projeto principal.

Se você está atualmente no diretório do seu projeto, clique em um nível acima.(Esse diretório raiz também será chamado AspNetCoreTodo). Em seguida, use este comando para criar um novo projeto de teste:

```bash
dotnet new xunit -o AspNetCoreTodo.UnitTests
```

O xUnit.NET é um framework de teste popular para o código .NET que pode ser usado para escrever testes de unidade e de integração.

Como tudo mais, é um conjunto de pacotes do NuGet que podem ser instalados em qualquer projeto.

O novo modelo de xunit dotnet já inclui tudo o que você precisa.

Sua estrutura de diretórios deve estar assim:

```bash
AspNetCoreTodo/
    AspNetCoreTodo/
        AspNetCoreTodo.csproj
        Controllers/
        (etc...)

    AspNetCoreTodo.UnitTests/
        AspNetCoreTodo.UnitTests.csproj
```

Como o projeto de teste usará as classes definidas em seu projeto principal, você precisará adicionar uma referência ao projeto `AspNetCoreTodo`:

```bash
dotnet add reference ../AspNetCoreTodo/AspNetCoreTodo.csproj
```

Exclua o arquivo `UnitTest1.cs` criado automaticamente.

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


> Pode parecer improvável agora que você possa
> introduzir uma mudança na lógica de negócios sem perceber,
> mas fica muito mais difícil acompanhar as decisões e suposições
> em um projeto grande e complexo.
> 
> Quanto maior o seu projeto, mais importante é ter verificações
> automatizadas que garantem que nada mudou!

Para escrever um teste de unidade que verificará a lógica no `TodoItemService`, crie uma nova classe em seu projeto de teste:

`AspNetCoreTodo.UnitTests/TodoItemServiceShould.cs`

```csharp
using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AspNetCoreTodo.UnitTests
{
    public class TodoItemServiceShould
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
    var service = new TodoItemService(context);

    var fakeUser = new ApplicationUser
    {
        Id = "fake-000",
        UserName = "fake@example.com"
    };

    await service.AddItemAsync(new TodoItem
    {
        Title = "Testing?"
    }, fakeUser);
}
```

A última linha cria um novo item de tarefa chamado Testando? E informa ao serviço para salvá-lo no banco de dados (na memória).

Para verificar se a lógica de negócios foi executada corretamente, escreva mais alguns códigos abaixo do bloco `using` existente:

```chsarp
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

