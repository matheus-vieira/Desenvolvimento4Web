## Login social

Como visto, a funcionalidade de login e senha já está incluída no template de autenticação individual (--auth Individual).

Podemos extender adicionando providers de identidade como o Facebook, LinkedIn, Google, Twitter, etc.

> Providers externos
> 
> Para a utilização de login com terceiros normalmente se necessita de duas coisas
> 
> 1. Criar um aplicativo (normalmente chamado de cliente)
> 2. Copiar as informações de ID e senha gerada pelo provedor e inserir no seu código
> 

# [Login com o Facebook](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/social/facebook-logins?tabs=aspnetcore2x)

Para criarmos nosso login com o facebook devemos utilizar o [Facebook Developer Console](https://developers.facebook.com/?locale=pt_BR) e criar um [novo aplicativo](https://developers.facebook.com/apps/?locale=pt_BR) (isso exigirá o login do facebook)

> Não tenho Facebook (e nem quero!)
> 
> Não tem problema! :bowtie:
>
> Apenas utilize outro provider como o Google ou Twitter.
> 
> Os passos para conseguir o ID e Senha serão diferentes
> 
> Porém o código no nosso projeto será bem parecido :metal:

Para criar um aplicativo acesse o [link](https://developers.facebook.com/apps/)

Clique em Criar um novo aplicativo

![Criar um novo aplicativo](/Desenvolvimento4Web/seguranca-e-identidade/facebook-login/images/create.png)

Informe um nome ao seu novo aplicativo

![Nomear um novo aplicativo](/Desenvolvimento4Web/seguranca-e-identidade/facebook-login/images/nomear.png)

Informe um nome ao seu novo aplicativo e clique em Crie um número de identificação do aplicativo, informe o captcha se necessário.

![Nomear um novo aplicativo](/Desenvolvimento4Web/seguranca-e-identidade/facebook-login/images/nomear.png)

Na sequência clique em Configurar no Facebook Login

![Configurar Facebook login](/Desenvolvimento4Web/seguranca-e-identidade/facebook-login/images/configurar-login.png)

Utilizando o Início rápido, selecione Web

![Início Rápido](/Desenvolvimento4Web/seguranca-e-identidade/facebook-login/images/inicio-rapido.png)

Informe a Url `http://localhost:5000/signin-facebook` e clique em Save

![Informe a URL](/Desenvolvimento4Web/seguranca-e-identidade/facebook-login/images/informe-url.png)

> Porta da execução
>
> Pode ser que a URL a ser informada esteja com uma porta diferente
> Rode sua aplicação (Se for com o Visual Studio ele provavelmente irá mostar uma porta diferente)

Vá clicando em Avançar para finalizar a configuração.

Em Configurações / Básico no menu lateral pegue as informações de ID do Aplicativo e a Chave Secreta

![ID e Chave secreta](/Desenvolvimento4Web/seguranca-e-identidade/facebook-login/images/id-secret.png)

Agora editaremos o arquivo `Startup.cs` adicionando o código abaixo dentro do método configure service.

```csharp
services
    .AddAuthentication()
    .AddFacebook(options => 
    {
        options.AppId = Configuration["Authentication:Facebook:AppId"];
        options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
    });
```

Não armazenaremos as informações do aplicativo em nosso arquivo `appsetting.js`, pois não é o tipo de informações que queremos deixar a mostra em um github por exemplo.

### [Gerenciador de segredo](https://docs.microsoft.com/pt-br/aspnet/core/security/app-secrets?tabs=visual-studio#secret-manager)

Para armazenar informações sensíveis como senhas devemos utilizar o comando [`dotnet user-secrets`](https://docs.microsoft.com/pt-br/aspnet/core/security/app-secrets?tabs=visual-studio)

O comando `dotnet user-secrets` deve ser executado dentro da pasta do projeto

```bash
dotnet user-secrets -- help
```

Para armazernar as informações utilizamos os seguintes comandos:

```bash
dotnet user-secrets set Authentication:Facebook:AppId <id do aplicativo>
```

```bash
dotnet user-secrets set Authentication:Facebook:AppSecret <chave secreta do aplicativo>
```

Via Visual Studio, no menu do contexto selecione a opção de Manage User Secrets

![Manage user secrets](/Desenvolvimento4Web/seguranca-e-identidade/facebook-login/images/manage-user-secrets.png)

No arquivo `secrets.json` informe as informações e salve o arquivo.

```json
{
  "Authentication:Facebook:AppId": "<id do app>",
  "Authentication:Facebook:AppSecret": "<app secret>"
}
```

Os valores salvos são carregados através da propriedade `Configuration`

[Segurança e Identidade]({{ '/seguranca-e-identidade' | relative_url }})
