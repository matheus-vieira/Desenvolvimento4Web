# Utilizando `Authorize` na View

Quando precisamos verificar se um usuário terá permissão a acessar uma tela então utilizamos o atributo `Authorize` na controladora.

E quando precisamos mostrar algo na View que seja de um papel específico.

> [Partial View](https://docs.microsoft.com/pt-br/aspnet/core/mvc/views/partial)
> 
> Uma view parcial é incorporada uma view existente
> 
> A utilização do `_` é opcional. Serve para indicar que esta view não serã chamada diretamente

Utilizaremos injeção de dependênia dentro da nossa partia view.

Utilizamos o `SignInManager` para determinar se o usuário está logado na aplicação. Porém como utilizamos o atributo `Authorize` na nossa controladore não obrigatório na nossa partial 

### `Views/Shared/_AdminActionsPartial.cshtml`

```csharp
@using Microsoft.AspNetCore.Identity
@using TodoMvc.Models

@inject SignInManager<ApplicationUser> SignInManager
@inject UserManager<ApplicationUser> UserManager

@if (SignInManager.IsSignedIn(User))
{
    var currentuser = await UserManager.GetUserAsync(User);
    var isAdmin = currentuser != null &&
        await UserManager.IsInRoleAsync(currentuser, Constants.AdministratorRole);

    if (isAdmin)
    {
        <ul class="nav navbar-nav navbar-right">
            <li>
                <a asp-controller="ManageUsers"
                   asp-action="Index">
                    Manage Users
                </a>
            </li>
        </ul>
    }
}
```

Sem o `SignInManager`

```csharp
@using Microsoft.AspNetCore.Identity
@using TodoMvc.Models

@inject UserManager<ApplicationUser> UserManager

@{
    var currentuser = await UserManager.GetUserAsync(User);
    var isAdmin = currentuser != null &&
        await UserManager.IsInRoleAsync(currentuser, Constants.AdministratorRole);
}

@if (isAdmin)
{
    <ul class="nav navbar-nav navbar-right">
        <li>
            <a asp-controller="ManageUsers"
               asp-action="Index">
                Manage Users
            </a>
        </li>
    </ul>
}
```

Agora alteramos o nosso layout para adicionar nossa nova partial view

### `Views/Shared/_Layout.cshtml`

```csharp
/* Código Existente*/
@await Html.PartialAsync("_LoginPartial")
@await Html.PartialAsync("_AdminActionsPartial")
/* Código Existente*/
```

## Resumo

O [ASP.NET Core Identity](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/identity) é um poderoso sistema de segurança e identidade que ajuda você a adicionar verificações de autenticação e autorização, além de facilitar a integração com provedores de identidade externos.

Os templates do `dotnet new` oferecem views e controllers prontas que lidam com cenários comuns, como login e registro, para que você possa começar a trabalhar rapidamente.

Há muito mais que o ASP.NET Core Identity pode fazer.

Você pode aprender mais na documentação e nos exemplos disponíveis em [https://docs.asp.net](https://docs.asp.net).