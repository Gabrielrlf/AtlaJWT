# AtlaJWT

# # Como startar

BACK-END
Vamos lá, para iniciarmos a nossa aplicação, precisaremos primeiro startar o backend.
O banco de dados escolhido foi o SQLITE, não será necessário efetuar nenhum comando para subir o banco, pois o mesmo já está existente na aplicação.
Para rodar a API, dê o start nela normalmente (caso VS CODE, dê o dotnet run, já pelo Visual Studio, dê o start e inicie a aplicação).

# Vamos aos testes
- Utilizei o Postman para simular os testes.

## [Authorize(Roles="Admin")]
### 1.0 - Login
No postman, cole a URL https://localhost:44382/api/User/Login e passe o seguinte json no body
```Json
{
    "UserName": "Administrador",
    "Password": "senha123"
}
```
Se o retorno for similar a imagem abaixo, ele será ok.
<h1> *** ATENÇÃO!!! </h1>
Letras minúsculas e maiúsculas contam, portanto, o usuário <b>Administrador</b> é exatamente conforme o descrito acima, tanto usuário quanto senha. 


![imagem_2021-12-01_131609](https://user-images.githubusercontent.com/49160989/144271721-a653c9ac-9529-406f-bfe9-58249c1dcef1.png)
Copie o Token (após as aspas e até o final antes das aspas).


  ### 1.1 - Create
  Antes de testarmos, vamos passar o token para termos a autorização de acessar os métodos de um usuário administrador
  vá na aba authorization e selecione o tipo <b>Bearer Token</b> e passe o token no input ao lado. 
  Depois, utilize esse endereço: https://localhost:44382/api/User/Create

![imagem_2021-12-01_132553](https://user-images.githubusercontent.com/49160989/144273434-1a966cc4-0372-4596-a990-d9fd0ee8cacc.png)


```JSON
{
  "password": "teste",
  "UserName": "Moto",
  "age": 25
}
```
Utilize como base o JSON acima e então, alterando as propriedades para o seu desejado, efetue a criação. O retorno deve ser similar:

```JSON
{
    "idUserInfo": 13,
    "age": 25,
    "id": 7,
    "userName": "Moto",
    "password": ""
}
```

### 1.2 GetAll
Esse método é independente de estar ou não autenticado. Então, você pode efetuar testes com o token ou não.
Para utiliza-lo, passe o endereço: https://localhost:44382/api/User/GetAll
O retorno deve ser uma lista similar ao json acima.

### 1.3 Update
Para o update, faça o mesmo esquema do token e utilize o seguinte endereço: https://localhost:44382/api/User/Update, 
utilize como base o usuário criado na etapa 1.1, retirando o campo da senha.

```JSON
{
    "idUserInfo": 13,
    "age": 10,
    "id": 7,
    "userName": "Carro"
}
```

<h2> Detalhe, não sabia dizer se era ou não para haver a alteração também da senha então, eu não implementei essa edição </h2>
O retorno deverá ser similar: 
```JSON
{
    "idUserInfo": 13,
    "age": 10,
    "id": 7,
    "userName": "Carro",
    "password": "dGVzdGU="
}
```

### 1.4 Delete
Para fazer a deleção, utilize: https://localhost:44382/api/User/Remove/{id}
Troque o ID pelo ID gerado no json acima, efetue a deleção e o retorno deverá ser similar:
```JSON
{
    "contentType": null,
    "serializerSettings": null,
    "statusCode": 200,
    "value": "Usuário excluído com sucesso!"
}
```
![imagem_2021-12-01_141201](https://user-images.githubusercontent.com/49160989/144281461-2698cfcb-4731-4ca6-9806-d2c3d45aa600.png)


FRONT-END
Para startar o frontend, tem um README melhor resumido na pasta do front, <a href="https://github.com/Gabrielrlf/AtlaJWT/tree/master/AtlaJWT.Front/frontatl#readme"> clique aqui</a> qualquer coisa.
Acesse a página através do seu localhost, a porta será a 3000, independente do meio de startar.

### 2.0 Login
![imagem_2021-12-01_150804](https://user-images.githubusercontent.com/49160989/144289833-1020a3f6-7a56-4efa-be60-48ab5f88761a.png)

Essa é a página de login, efetue o primeiro login colocando o usuário Administrador e a senha: senha123


### 2.1 Inserir
![imagem_2021-12-01_151853](https://user-images.githubusercontent.com/49160989/144291336-58bc2d9b-3af1-445c-8cf9-746017daae68.png)

Para inserir, clique no botão com o respectivo nome e preencha os campos.

![imagem_2021-12-01_151949](https://user-images.githubusercontent.com/49160989/144291465-c2828f08-c84e-4949-8b77-749e101615eb.png)
Após clicar em salvar, ele irá inserir e dar reload na lista dos usuários.

### 2.2 Detalhes | 2.3 Edição | 2.4 Deleção
Ao clicar na linha do usuário desejado, vai abrir um modal de detalhes com botões de edição 

![imagem_2021-12-01_152302](https://user-images.githubusercontent.com/49160989/144291994-6db8e78f-863c-4620-b8bd-ab2f41cd3f77.png)

Para editar, siga os mesmos passos do 2.1, vale lembrar quê <b> Usuário/Idade não pode ser nulo/em branco, o usuário não pode ter menos de 3 caracteres </b>

### Alguns pontos ###
 
Clique em sair e logue com algum usuário que você cadastrou, você irá perceber que somente conseguirá ver os detalhes na hora que clicar sobre o teu usuário, também vale ressaltar que só conseguirá ver nome e idade.

Para finalizar, deslogue e clique em list, irá aparecer todos os nomes dos usuários cadastrados

###

## Testes Unitários 
Foi utilizado o xUnit para desenvolver os testes unitários, todas as explicações de cada teste estão no summary.


## Pattern
O pattern que eu escolhi utilizar foi o Factory Method, pois além de desacoplar a instância do UserInfo, consigo criar o meu usuário sem tê-lo que ficar instânciando toda hora.
Além também de aderir ao OCP e ao SRP.


## Tecnologias utilizadas

<table>
  <tr>
    # # BACKEND
    <td>.NET 5.0 | ASP NET WEB API </td>
    <td>C#</td>
    <td>EF CORE</td>
    <td>xUnit para testes unitários</td>
    <td>SQLite</td>
    <td>Factory Method</td>
    <td>Repository Patterns</td>
    <td>IUnitOfWork</td>
    <td> D.I </td>
</table>


<table>
  <tr>
    <br>
    # # FRONTEND
    <td>ReactJS</td>
    <td>Axios</td>
    <td>Reactstrap & React-Bootstrap</td>
    <td>Swal</td>
  </tr>
</table>


<table>
  <tr>
    <br>
    # # APLICAÇÃO
    <td>Docker</td>
    <td>Cliente-Servidor</td>
  </tr>
</table>
