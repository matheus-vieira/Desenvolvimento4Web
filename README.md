# Desenvolvimento4Web

Códigos da disciplina

Para adicionar o bash do Ubuntu no VS Code\

Pressione CTRL + , (control + virgula)\

no lado direito do arquivo coloque esse texto\

// Bash on Ubuntu (on Windows)\
"terminal.integrated.shell.windows": "C:\\Windows\\System32\\bash.exe"\

Para abrir o terminal
Pressione CTRL + ' (control + aspa)

Ou botão direito na pasta desejada (no caso pode ser a onde está o projeto mvc)

Comando para iniciar o projeto

```bash
mkdir ToDo
cd ToDo/
```

```bash
dotnet new mvc --auth Individual -o TodoMvc
cd TodoMvc/
dotnet run
dotnet build
```

```bash
git clone https://github.com/matheus-vieira/Desenvolvimento4Web
git add *
git commit-m "Initial commit"

echo --global somente no próprio computador

git config --global user.email "matheus.costa.vieira@gmail.com"
git config --global user.name "Matheus Costa Vieira"

git commit -m "Initial commit"
git push origin master
```
```bash
git add .
git commit -m "<digite seu comentário>"
git push origin master
```


Acesse a pasta do projeto

```bash
cd source/ToDo/TodoMvc/
```

Confirme que está na pasta correta\

Linha de comando ubuntu
```bash
ls -l
```

Linha de comando windows
```bash
dir
```

Após alterar o arquivo de context

```bash
echo pode ser que tenha erro no código
echo o build ainda executa o comando restore
dotnet build
dotnet ef migrations add AddItems
```

SQL Limitations

Comente as linhas

```csharp
protected override void Up(MigrationBuilder migrationBuilder)
{
    // other stuffs

    // migrationBuilder.AddForeignKey(
    //     name: "FK_AspNetUserTokens_AspNetUsers_UserId",
    //     table: "AspNetUserTokens",
    //     column: "UserId",
    //     principalTable: "AspNetUsers",
    //     principalColumn: "Id",
    //     onDelete: ReferentialAction.Cascade);
}


protected override void Down(MigrationBuilder migrationBuilder)
{
    // migrationBuilder.DropForeignKey(
    //     name: "FK_AspNetUserTokens_AspNetUsers_UserId",
    //     table: "AspNetUserTokens");

    // other stuffs
}
```

Atualize a base de dados

```bash
dotnet ef database update
```

Adicionar o bundler para minificar css e js

```bash
dotnet add package BuildBundlerMinifier
dotnet build
dotnet clean
dotnet run
```