# Requerer autenticação

Algumas vezes queremos que o usuário esteja logado para que ele possa ter acesso à recursos do sistema.

Normalmente a página inicial é o ponto que não é necessário login, ou seja, faz sentido qualquer pessoa, logada ou não, visualizá-la.

# Authorize

Para limitarmos o uso da nossa página de lista de tarefas faremos o uso do atributo `Authorize` na classe `ToDoController`. Esse atributo se encontra no name space `Microsoft.AspNetCore.Authorization`.

```csharp
// outros using's
using Microsoft.AspNetCore.Authorization;

namespace TodoMvc.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
      //...
    }
}
``` 