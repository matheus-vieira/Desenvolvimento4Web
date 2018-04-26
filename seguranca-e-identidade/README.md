# Segurança e Identidade

Cada dia mais devemos nos preocupar com a segurança de aplicações, seja ela web, api, desktop ou serviço.

Devemos manter a confidencialidade dos dados de nossos usuários e ao mesmo tempo temos que manter nossos sistemas livres de ataques.

> Itens que devemos nos assegurar
>
> * SQL Injection [Little Bobby Tables](http://bobby-tables.com/)
> * [XSRF (ataque cross-domain)](https://docs.microsoft.com/pt-br/aspnet/core/security/anti-request-forgery)
> * Suporte ao HTTPS
> * Acesso ao sistema de forma segura (login e senha ou login social)
> * Resetar senha ou adicionar fluxos de autenticação de multi-fator

## Implementações no ASP.NET Core

O próprio framework possui, com poucas linhas de código, formas de previnir ataques de injeção de SQL e XSRF.

Vamos focar, neste projeto, sobre Identy e como isso nos ajuda a manter nosso sistema minimamente seguro.

Utilizando Identy vamos:

* Gerenciar contas de usuários (manter e logar)
* Autenticar (logging in)
* Autorizar (Fornecer acessos a recursos específicos)

> Authentication and Authorization
> 
> Os nomes podem causar confusão, mas são coisas distintas
> 
> ### Authentication
>
> Trata de informações do usuário, se está logado, etc.
>
> `Eu conheço esse usuário?`
>
> ### Authorization
>
> Após a autenticação verifica se o usuário tem acesso ào recurso solicitado
>
> `Esse usuário tem permissão para fazer esta ação?`


### MVC + Individual Authentication

Ao criarmos nosso projeto utilizamos o template de projeto MVC com a opção de autenticação individual.

Isso gerou várias classes com código pronto, baseado no ASP.NET Core Identity

```bash
dotnet new mvc --auth Individual
```

## [ASP.NET Core Identity](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/identity?tabs=visual-studio%2Caspnetcore2x)

Sistema incorporado ao framework ASP.NET Core.

É um conjunto de pacotes [Nuget](https://docs.microsoft.com/en-us/nuget/) para ser instalado em qualquer projeto.

Objetivo de utilização:

* Armazenar contas de usuário
* Hash de senha
* Armazenar senhas
* Gerenciar papéis (roles)

Suporte para

* Login com e-mail/senha
* Autenticação multi-fator
* [Login social](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/social/)
  * [Google](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/social/google-logins?tabs=aspnetcore2x)
  * [Facebook](https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/social/facebook-logins?tabs=aspnetcore2x)
  * etc.
* Conectar com outros serviços utilizando
  * [OAuth 2.0](https://oauth.net/2/)
  * [OpenID Connect](http://openid.net/connect/)

O próprio template já implementa login e senha por padrão.

Para criação de senhas já possui políticas de segurança

* De 6-100 caracteres
* Pelo menos um caracter número
* Pelo menos um caracter especial
* Pelo menos uma minúscula ('a'-'z').
* Pelo menos uma maiúscula ('A'-'Z').

> Exemplo:
>
> usuário: teste@test.com
>
> password: !23a456A

[Facebook Login]({{ '/seguranca-e-identidade/facebook-login' | relative_url }})

[Authorize]({{ '/seguranca-e-identidade/authorize'  | relative_url }} )

[Identity]({{ '/seguranca-e-identidade/identity'  | relative_url }} )

[Roles]({{ '/seguranca-e-identidade/roles'  | relative_url }} )