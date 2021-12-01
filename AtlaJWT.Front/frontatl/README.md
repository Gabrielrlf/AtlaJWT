# Para rodar o front-end, há duas maneiras:


<h1>Docker </h1>
Caso tenha o comando instalado, abra seu CMD e digite: <br> cd ./{caminho_para_qual_você_clonou_o_repositorio}</br>
Dentro da pasta, você vai observar que há um arquivo Dockerfile e um docker-compose.yml, para subir o container, rode o comando: docker-compose up -d --build, ele vai buildar e subir a imagem.
Após subir o container, você conseguirá acessar através da porta 3000.

<h1>Baixando as dependências </h1>
 Abra seu projeto ou siga o mesmo caminho do CMD e digite npm install no seu terminal, ele irá baixar as dependências do front, logo após, utilize o npm start e ele irá rodar o front direto na sua máquina.
