# Identidade

No nosso exemple desejamos ver tarefas nossas e apenas nossas.

Não queremos outras pessoas acessando informações que dizem respeito ao nosso usuário.

# Injetando o gerenciador de usuário

Para que seja utilizado o `Identity` do .NET Core devemos fazer uma injeção de dependência na controladora `ToDoController` da classe genérica `UserManager<Entity>`, onde `Entity` é a classe do usuário na nossa aplicação, no nosso caso utilizamos a classe `ApplicationUser`.

```csharp
//...
using Microsoft.AspNetCore.Identity;
//...
[Authorize]
public class ToDoController : Controller
{
    private readonly ITodoItemService _todoItemsService;
    private readonly UserManager<ApplicationUser> _userManager;

    public ToDoController(ITodoItemService todoItemsService,
                          UserManager<ApplicationUser> userManager)
    {
        _todoItemsService = todoItemsService;
        _userManager = userManager;
    }
    //...
}
//...
```

## Adicionando referência à usuários na tarefa

Para que nossas tarefas sejam atreladas a um usuários precisamos de uma propriedade que indique isso.

Iremos alterar a classe `TodoMvc.Models.ToDoItem` adicionando a propriedade `OwnerId`

```csharp
public string OwnerId { get; set; }
```

> ### Atualizando o Banco de Dados
> 
> Como alteramos nosso modelo agora precisamos criar uma migração
> 
> ```bash
> dotnet ef migrations add AddItemOwnerId
> ```
> 
> Agora informamos as alteração ao banco de dados
> 
> ```bash
> dotnet ef database update
> ```
> ### Utilizando o Visual Studio
> 
> ![Console do Gerenciador de Pacotes](/Desenvolvimento4Web/seguranca-e-identidade/identity/images/console.png)
> 
> Utilize este comando para criar uma migração
>
> ```bash
> Add-Migration AddItemOwnerId
> ```
> 
> Utilize este comando para atualizar o banco de dados
>
> ```bash
> Update-Database
> ```

Agora na hora de salvar precisamos informar o novo campo nas alterações.

Para isso recebemos o usuário através da nossa interface

```csharp
public interface ITodoItemService
{
    Task<IEnumerable<ToDoItem>> GetIncompleteItemsAsync(ApplicationUser currentUser);
    Task<bool> AddItemAsync(NewToDoItem newToDoItem, ApplicationUser currentUser);
    Task<bool> MarkDoneAsync(Guid id, ApplicationUser currentUser);
}
```

Para identificar um usuários utilizando o objeto `userManager` utilize o método `GetUserAsync(User)`

```csharp
var currentUser = await _userManager.GetUserAsync(User);
```

Caso o usuário não esteja logado esse método retorna `null`.

Na ação `Index`, caso o usuário não exista, ou há dúvidas sobre sua identidade retorne o método [`Challenge`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.challenge?view=aspnetcore-2.0) que força a verificação da identidade ou indo para a tela de login e senha ou redirecionando para um login de terceiro.

Na outras ações retorne o método [`Unauthorized`](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.unauthorized?view=aspnetcore-2.0)

[Segurança e Identidade]({{ '/seguranca-e-identidade' | relative_url }})