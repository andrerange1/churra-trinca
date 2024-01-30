Olá,

Na [wiki](https://github.com/trinca137/trinca-challenge/wiki/Comece-por-aqui) estão as informações relevantes para realizar o desafio. 

Boa sorte!


------------------------------------------------------------



Adicionei um servico de Lookup e de Pessoas

Agora podemos criar o nosso proprio Lookup com nossas proprias pessoas.


Para testar precisamos criar pessoas, criar um lookup e adicionar pessoas a esse lookup. 
Depois disso precisamos criar e moderar churrascos a partir de lookups.

O caminho feliz para testar é 

1 - Criar pessoa  
RunCreateNewPerson: [POST] http://localhost:7296/api/person
Aqui nao precisamos de autorização. Vamos supor que ja pegamos ela em outra base de dados.
Dizemos seu nome e se ela é vista como CoOwner

2 - Criar Lookup 
RunCreateNewLookup: [POST] http://localhost:7296/api/lookups
Vamos logar com a pessoa criada anteriormente e criar o lookup passando um nome para ele.
O interessante é que a pessoa logada já seja um CoOwner.
Ela vai ser adicionada na lista de CoOwner e na lista de Pessoas do lookup.

3 - Criar outras pessoas - Isso pode ser feito antes de criar o lookup.

4 - Adicionar pessoa ao lookup   
RunAddPersonToLookup: [PUT] http://localhost:7296/api/lookups/{id}/addperson
Precisa estar logado para fazer. Esse metodo adiciona uma unica pessoa por vez ao lookup. 
Se a pessoa for CoOwner ela ja vai ser considerada CoOwner pelo lookup.

5 - Criar churrasco
RunCreateNewBbq: [POST] http://localhost:7296/api/churras
Qualquer pessoa logada pode criar. Agora adicionei um parametro a requisicao: LookupId
Agora ao criar o churrasco é preciso dizer para qual lookup vamos enviar os convites.

6 - Moderar churrasco
RunModerateBbq: [PUT] http://localhost:7296/api/churras/{id}/moderar
Apenas moderador pode fazer isso. Esse também precisamos mencionar qual lookup vamos convidar. LookupId

7 - Ver lista de compras
RunGetProposedFood: [GET] http://localhost:7296/api/{bbqId}/food
Implementei duas variaveis: quantidade de carne e quantidade de vegetais
A lista pode ser vista passando como parametro na uri o id do churrasco.


------------------------------------------------------------

Implementei uma divisão por camadas onde cada camada tem a sua propria responsabilidade.

Functions - Controller 
 Recebe as requesicoes e valida para ver se os paramentros necessarios vieram. Se sim os transforma em um Dto de requisicao
para poder enviar para a camada de aplicacao.
Valida se o usuario existe e se tem permissões necessarias.
Só podem acessar a camada de aplicação e os contratos.

AppService
 Recebe as requisições do Controller através de dtos e verifica se consegue os converter em entidades.
 Envia a entidade para o service.
 Só podem acessar o dominio(service) e os contratos.
 Ele só pode acesar o seu proprio service.

Contratos
 Responsavel por todos os Dtos e seus mapeamentos.
 É visto pelo controller e pelo service no dominio.

Dominio
 O ❤ da aplicação. 
 Onde temos as entidades e seus serviços.
 Onde definimos as interfaces de serviço e repositorio.
 Cada entidade tem o seu service e eles podem se acessar para ver o sistema como um todo.
 Cada service acessa somente o seu proprio repositorio

Infra
 Aqui temos a definicao dos repositorios.
 Sao acessados somente por seu service.






