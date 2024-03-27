# Repositorio -> https://github.com/ArthurVitor/TODO.UnidadeTerra.CS

# Desafio - API Lista de Tarefas (To Do List)

A API Lista de Tarefas (To Do List) permite que sejam cadastradas tarefas simples, com um **identificador**, uma **descrição**, uma **data de abertura**, uma **prioridade** (alta, média e baixa) e um **status** (pendente e concluída), sendo possível se concluir uma tarefa posteriormente (atualizando seu status de pendente para concluída). Nessa API, tarefas podem ter sua descrição e prioridade editadas, além de tarefas poderem também ser completamente removidas.

Seu desafio aqui será construir esta API seguindo além da introdução acima, alguns requisitos de interação.

## Requisitos funcionais

- Os endpoints da API devem estar agrupados sob um mesmo prefixo de rota (ex.: `api/tarefas`).
    > - Dica: Utilizar o atributo *Route* para *decorar* a controller.
- Deve ser possível se ter endpoints para criação de uma nova tarefa, listagem de tarefas, detalhamento de uma tarefa, atualização de informações de uma tarefa, conclusão de uma tarefa e deleção de uma tarefa.
    > - Dica: Utilizar os atributos respectivos aos verbos `HTTP` para *decorar* os métodos:
    >     - (`C` - *POST*) Criar uma nova tarefa.
    >     - (`R` - *GET*) Listar tarefas.
    >     - (`R` - *GET*) Obter detalhes de uma tarefa pelo *identificador*.
    >     - (`U` - *PUT*) Atualizar informações de uma tarefa (descrição e prioridade) pelo *identificador*.
    >     - (`U` - *PATCH*) Concluir uma tarefa (atualização *apenas* do status) pelo *identificador*.
    >     - (`D` - *DELETE*) Deletar uma tarefa pelo *identificador*.
- Em requisições que demandam o envio do *identificador*, ele deve ser enviado por *URL/Path parameters* (parâmetros de rota).
- Na lista de tarefas deve ser possível filtrar tarefas por prioridade e/ou status, utilizando *Query/String parameters* (parâmetros de consulta).
- A requisição de listagem de tarefas precisa atender a dois tipos consumidores, web e mobile:
    - Na versão web, os objetos retornados devem conter todas as propriedades.
    - Na versão mobile existe uma preocupação com consumo de dados, então os objetos devem ser retornados em uma versão reduzida, contendo apenas a descrição e o status.
    > Dica: Utilizar um *header* de requisição para indicar ao servidor a plataforma (web ou mobile).
- Deve haver um controle para que qualquer requisição que não atenda às rotas definidas, tenha um retorno `404`.
    > Dica: Implementar uma rota *default*.

## Requisitos não funcionais
- Não há banco de dados, o sistema deve ser todo "in-memory".
- A API deve operar o [CRUD](https://www.youtube.com/watch?v=8jcawcG2veY) o mais próximo possível de [RESTful](https://blog.geekhunter.com.br/sua-api-nao-e-restful-entenda-por-que/), promovendo consistência e facilidade de uso.
    > Nota: Lendo o artigo do link em "RESTful", você perceberá que construir uma *API* 100% em conformidade com a arquitetura *REST* demanda um pouco mais de complexidades do que as que você está trabalhando no momento (ex.: implementação de [HATEOAS](https://www.treinaweb.com.br/blog/o-que-e-hateoas) e cache). Você não precisa disso agora, e está tudo bem! Preocupe-se apenas em atender os objetivos de trabalhar da melhor forma possível com a representação de estado do objeto `Tarefa` e atender as operações de acordo com os verbos *HTTP* adequados.
