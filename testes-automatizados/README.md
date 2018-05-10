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

Quando o aplicativo é executado normalmente, o sistema de injeção de dependência do ASP.NET Core injeta cada um desses objetos no gráfico de dependência quando o ToDoController ou o ToDoItemService é criado.

Quando você escreve um teste de unidade, por outro lado, você precisa manipular o gráfico de dependência sozinho. É típico fornecer versões somente de teste ou `mock` dessas dependências. Isso significa que você pode isolar apenas a lógica da classe ou método que está testando. (Isso é importante! Se você está testando um serviço, não quer também gravar acidentalmente no banco de dados.)

[Projeto de Testes]({{ '/testes-automatizados/projeto'  | relative_url }} )

Na minha pós-graduação em Engenharia de Software e Arquitetura de Sistemas fiz uma apresentação sobre [Testes automatizados de software - Testes com Selenium, Node e TheIntern](https://www.slideshare.net/macovieira/testes-automatizados-de-software-54527759?qid=9b506f25-233d-47fa-9316-1997f86c418d&v=&b=&from_search=1)