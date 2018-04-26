# Usuário de Teste

Obviamente não é interessante ter um checkbox  marcando o usuário como Admnistrador na tela de registro de usuário.

É possível criamos um pouco de código na class `Startup` que irá criar uma conta de administrador na primeira vez que a aplicação iniciar.

Os métodos criados necessitas acesso aos serviços `RoleManager` e `UserManager`. Eles podem ser injetados no método `Configure`, assim como é feito nos controladores.

### Startup.cs

```csharp
public void Configure(IApplicationBuilder app,
                      IHostingEnvironment env,
                      UserManager<ApplicationUser> userManager,
                      RoleManager<IdentityRole> roleManager)
    if (env.IsDevelopment())
    {
        // ...
        // código existente

        EnsureRoleAsync(roleManager).Wait();
        EnsureTestAdminAsync(userManager).Wait();
    }
    // ...
    // código existente
}
```

Os métodos adicionado dentro do método `Configure` serão adicionados dentro da classe `Startup`.

Primeiro temos o `EnsureRoleAsync`:

```csharp
public void Configure(/* parameters */)
{
    // ...
    // código existente
}

private static async Task EnsureRoleAsync(RoleManager<IdentityRole> roleManager)
{
    var alreadyExists = await roleManager.RoleExistsAsync(Constants.AdministratorRole);

    if (alreadyExists)
        return;

    await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
}
```

Para evitar erros de digitação vamos criar uma classe `Constants`.

```csharp
namespace TodoMvc
{
    public static class Constants
    {
        public static string AdministratorRole = "Administrator";
    }
}
```

> Aqui podemos atualizar a controladore `ManageUsersController` para utilizar essa constante.

Agora o método `EnsureTestAdminAsync`:

```csharp
private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager)
{
    var testAdmin = await userManager.Users
        .Where(x => x.UserName == "admin@todo.local")
        .SingleOrDefaultAsync();

    if (testAdmin != null)
        return;

    testAdmin = new ApplicationUser
    {
        UserName = "admin@todo.local",
        Email = "admin@todo.local"
    };

    await userManager.CreateAsync(testAdmin, "NotSecure123!!");

    await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);
}
```

Após logar trocar a senha do usuário administrador

> ## Método `Wait`
> 
> O método `Configure` não é assíncrono.
> 
> Os métodos `EnsureRoleAsync` e `EnsureTestAdminAsync`, como o nome diz são assíncronos.
>
> Esse é um caso raro para a utilização do método `Wait`
>
> **Preferencialmente utilize `await`**

Ao executar a aplicação será criado o usuário `admin@todo.local` atrelado ao role `Administrator`

Adicione outras funcionalidades como deletar um usuário!