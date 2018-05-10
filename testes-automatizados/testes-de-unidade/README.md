# Testes de Unidade (Unit Testing)

São testes pequenos e rápidos que verificam o comportamento de um único método ou um pedaço de lógica.

Invés de testarmos um grupo de classes ou o sistema inteiro (como os testes de integração fazem), testes de unidades dependem de `mocking` ou substituindo objetos que método depende.

Por exemplo, a `ToDoController` tem duas dependências: `ITodoItemService`e `UserManager`. `TodoItemService`, por sua vez, depende de `ApplicationDbContext`.

Dessa forma podemos ter um gráfico de dependência

```bash
ToDoController -> TodoItemService -> ApplicationDbContext
```

Quando o aplicativo é executado normalmente, o sistema de injeção de dependência do ASP.NET Core injeta cada um desses objetos no gráfico de dependência quando o ToDoController ou o ToDoItemService é criado.

Quando você escreve um teste de unidade, por outro lado, você precisa manipular o gráfico de dependência sozinho. É típico fornecer versões somente de teste ou `mock` dessas dependências. Isso significa que você pode isolar apenas a lógica da classe ou método que está testando. (Isso é importante! Se você está testando um serviço, não quer também gravar acidentalmente no banco de dados.)

[Testes Automatizados]({{ '/testes-automatizados'  | relative_url }} )

[Projeto de Testes]({{ '/testes-automatizados/projeto'  | relative_url }} )