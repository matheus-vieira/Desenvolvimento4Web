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

```
mkdir ToDo
cd ToDo/
```

```
dotnet new mvc --auth Individual -o TodoMvc
cd TodoMvc/
dotnet run
dotnet build
```

```
git clone https://github.com/matheus-vieira/Desenvolvimento4Web
git add *
git commit-m "Initial commit"

echo --global somente no próprio computador

git config --global user.email "matheus.costa.vieira@gmail.com"
git config --global user.name "Matheus Costa Vieira"

git commit -m "Initial commit"
git push origin master
```
```
git add .
git commit -m "<digite seu comentário>"
git push origin master
```