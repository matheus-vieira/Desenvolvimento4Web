# Autorização e Papéis

Papéis (roles) é uma abordagem comum no gerenciamento de autorização e permissões  numa aplicação web.

> ## Exemplo:
>
> Um sistema pode ter um papel de Administrador para gerenciar os usuários registrados numa aplicação
> enquanto usuários comuns só podem visualizar suas próprias informações.

## Gerenciando usuários

Iremos adicionar uma página para gerenciar usuários.

### `Controllers/ManageUsersController.cs`

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoMvc.Models;
using TodoMvc.Models.View;

namespace TodoMvc.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var admins = await _userManager
                .GetUsersInRoleAsync("Administrator");

            var everyone = await _userManager.Users
                .ToArrayAsync();

            var model = new ManageUsersViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };

            return View(model);
        }
    }
}
```

Adicionando a propriedade `Roles` no atributo `[Authorize]` garantirá que apenas usuários logados e com papel de `Administrador` conseguirá visualizar essa página.

Adicionando uma ViewModel

### `Models/View/ManageUsersViewModel.cs`

```csharp
using System.Collections.Generic;
using TodoMvc.Models;

namespace TodoMvc.Models.View
{
    public class ManageUsersViewModel
    {
        public IEnumerable<ApplicationUser> Administrators { get; set; }
        public IEnumerable<ApplicationUser> Everyone { get; set; }
    }
}
```

Finalmente temos a View para a nossa ação.

### `Views/ManageUsers/Index.cshtml`

```csharp
@model TodoMvc.Models.View.ManageUsersViewModel

@{
    ViewData["Title"] = "Manage users";
}

<h2>@ViewData["Title"]</h2>

<h3>Administrators</h3>

<table class="table">
    <thead>
        <tr>
            <th>Id</th>
            <th>Email</th>
        </tr>
    </thead>
    <tbody>
    @foreach (var user in Model.Administrators)
    {
        <tr>
            <td>@user.Id</td>
            <td>@user.Email</td>
        </tr>
    }
    </tbody>
</table>

<h3>Everyone</h3>

<table class="table">
    <thead>
        <tr>
            <th>Id</th>
            <th>Email</th>
        </tr>
    </thead>
    <tbody>
    @foreach (var user in Model.Everyone)
    {
        <tr>
            <td>@user.Id</td>
            <td>@user.Email</td>
        </tr>
    }
    </tbody>
</table>
```

Inicie a aplicação e tente acessar a rota `/ManageUsers` logado com um usuário comum. Isso irá mostrar uma página de "Acesso Negado". Isso aconte pois não temos nenhum usuário associado ao papel de `Administrador`.

![Acesso Negado](/Desenvolvimento4Web/seguranca-e-identidade/roles/images/access-denied.png)