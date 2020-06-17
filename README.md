## Projeto da disciplina desenvolvimento web com tecnologias Microsoft

#### Diretório /back-end

###### Todas as API's estão dentro do endpoint https://comerciolocal-fatec-backend.herokuapp.com/v1/

**- Criando um usuario**

- URL: `/usuario` 
- Exige Autenticação: `Não`
- Método: `Post`
- Body: 
```json
{
	"Nome":"Alan Echer",
	"DataNascimento":"",
	"Email":"alan.echer@gmail.com",
	"Senha":"123teste",
	"TelefoneMovel":"17996272671",
	"TelefoneFixo":""
}
```

- Response Code: `200`
- Response Body: 
```
vazio
```

**- Realizando Login (O token possui duração de 5 horas)**

- URL: `/login` 
- Exige Autenticação: `Não`
- Método: `Post`
- Body: 
```json
{
	"Email":"teste@email.com",
	"Senha":"123"
}
```

- Response Code: `200`
- Response Body: 

```json
{
    "usuario": {
        "nome": "Alan Echer",
        "dataNascimento": "",
        "email": "alan.echer@gmail.com",
        "senha": "",
        "telefoneMovel": "17996272671",
        "telefoneFixo": "",
        "id": "c66476f5-40c6-4904-b4d9-18784a59d842"
    },
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImM2NjQ3NmY1LTQwYzYtNDkwNC1iNGQ5LTE4Nzg0YTU5ZDg0MiIsInJvbGUiOiJDb250YVBlc3NvYWwiLCJuYmYiOjE1OTE5MDg2NzksImV4cCI6MTU5MTkyNjY3OSwiaWF0IjoxNTkxOTA4Njc5fQ.N7Bls7jILsc3aKfl4d3W9macqwB2LwBSA0drXVpz8vg"
}
```

**- Criando um perfil**

- URL: `/perfil` 
- Exige Autenticação: `Sim Bearer Token`
- Método: `Post`
- Body: 
```json
{
	"Razao":"Teste",
	"Fantasia":"teste",
	"DataAbertura":"",
	"CNPJ":"",
	"Site":"",
	"Descricao":"",
	"CEP":"",
	"Logradouro":"",
	"Numero":"",
	"Complemento":"",
	"UF":"",
	"Pais":""
}
```

- Response Code: `200`
- Response Body: 
```
vazio
```

**- Obtendo dados do usuario**

- URL: `/usuario` 
- Exige Autenticação: `Sim Bearer Token`
- Método: `Get`
- Body: 
```
vazio
```

- Response Code: `200`
- Response Body: 

```json
{
    "nome": "Alan Echer",
    "dataNascimento": "",
    "email": "alan.echer@gmail.com",
    "senha": "",
    "telefoneMovel": "17996272671",
    "telefoneFixo": "",
    "id": "8c01bf6f-e767-4eda-8766-6bfb1cc4f890"
}
```

**- Obtendo dados do perfil**

- URL: `/perfil` 
- Exige Autenticação: `Sim Bearer Token`
- Método: `Get`
- Body: 
```
vazio
```

- Response Code: `200`
- Response Body: 

```json
{
    "usuarioId": "a1652afe-5b31-4a77-b29e-f902dc68e80c",
    "usuario": {
        "nome": "Alan Echer 2",
        "dataNascimento": "",
        "email": "alan.echer2@gmail.com",
        "senha": "",
        "telefoneMovel": "17996272671",
        "telefoneFixo": "",
        "id": "a1652afe-5b31-4a77-b29e-f902dc68e80c"
    },
    "cpf": "03763831193",
    "razao": "Teste",
    "fantasia": "teste",
    "dataAbertura": "",
    "cnpj": "",
    "site": "",
    "descricao": "",
    "cep": "",
    "logradouro": "",
    "numero": "",
    "complemento": "",
    "uf": "",
    "pais": "",
    "id": "eb52cc2a-3e8d-482b-93cd-eafb168750d9"
}
```

**- Atualizando perfil**

- URL: `/perfil` 
- Exige Autenticação: `Sim Bearer Token`
- Método: `Put`
- Body: 
```json
{
	"Razao":"Teste",
	"Fantasia":"teste",
	"DataAbertura":"",
	"CNPJ":"",
	"Site":"",
	"Descricao":"",
	"CEP":"",
	"Logradouro":"",
	"Numero":"",
	"Complemento":"",
	"UF":"",
	"Pais":""
}
```

- Response Code: `200`
- Response Body: 
```
vazio
```

**- Atualizando usuario**

- URL: `/usuario` 
- Exige Autenticação: `Sim Bearer Token`
- Método: `Put`
- Body: 
```json
{
	"Nome":"Alan Echer 2",
	"DataNascimento":"",
	"TelefoneMovel":"17996272671",
	"TelefoneFixo":""
}
```

- Response Code: `200`
- Response Body: 
```
vazio
```

**- Excluindo perfil**

- URL: `/perfil` 
- Exige Autenticação: `Sim Bearer Token`
- Método: `Delete`
- Body: 
```
vazio
```

- Response Code: `200`
- Response Body: 
```
vazio
```

**- Criando uma promoção**

- URL: `/promocao` 
- Exige Autenticação: `Sim Bearer Token`
- Método: `Post`
- Body: 
```json
{
	"DataInicio":"",
	"DataFim":"",
	"Descricao":"Teste Promoção",
	"MidiaPromocao":"",
	"CupomPromocao":""
}
```

- Response Code: `200`
- Response Body: 
```
vazio
```

**- Lista promoções**

- URL: `/promocao` 
- Exige Autenticação: `Sim Bearer Token`
- Método: `Get`
- Body: 
```
vazio
```

- Response Code: `200`
- Response Body: 

```json
[
    {
        "perfilId": "04fce55e-e147-44f1-8de5-05f60d219c17",
        "perfil": null,
        "dataInicio": "",
        "dataFim": "",
        "descricao": "Teste Promoção",
        "midiaPromocao": "",
        "cupomPromocao": "",
        "id": "fc2a5eb4-f2be-43a1-a15e-5613e56fd3e8"
    },
    {
        "perfilId": "04fce55e-e147-44f1-8de5-05f60d219c17",
        "perfil": null,
        "dataInicio": "",
        "dataFim": "",
        "descricao": "Teste Promoção",
        "midiaPromocao": "",
        "cupomPromocao": "",
        "id": "5c5be092-614e-4dc1-90fa-c72ae54ff4e9"
    }
]
```

**- Excluindo uma promoção**

- URL: `/promocao?guidPromocao=a146ebdd-6913-4b95-8b58-310893997e4a` 
- Exige Autenticação: `Sim Bearer Token`
- Método: `Delete`
- Body: 
```
vazio
```

- Response Code: `200`
- Response Body: 
```
vazio
```

#### Diretório /fron-end


#### Diretório /docs

Contém a documentação do projeto

##### /docs/BD

Diagrama do banco de dados