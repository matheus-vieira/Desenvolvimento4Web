# Testes Automatizados

Testes são importantes em toda e qualquer aplicação desenvolvida.

Testar seu código ajuda:

> Encontrar e evitar bugs.
>
> Refatorar seu código

Veremos uma introdução à `testes de unidade` e `testes de integração`.

Testes de unidades avaliam uma função ou algumas linhas de código garantindo sua funcionalidade. Testes de integração, ou testes funcionais, são testes mais amplos que simulam cenários do mundo real.

## Testes de Unidade (Unit Testing)

São testes pequenos e rápidos que verificam o comportamento de um único método ou um pedaço de lógica.

Invés de testarmos um grupo de classes ou o sistema inteiro (como os testes de integração fazem), testes de unidades dependem de `mocking` ou substituindo objetos que método depende.

Por exemplo, a `ToDoController` tem duas dependências: `ITodoItemService`e `UserManager`. `TodoItemService`, por sua vez, depende de `ApplicationDbContext`.

Dessa forma podemos ter um gráfico de dependência

```bash
ToDoController -> TodoItemService -> ApplicationDbContext
```

