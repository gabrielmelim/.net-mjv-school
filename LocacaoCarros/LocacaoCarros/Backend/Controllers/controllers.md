## ClienteController (Back-end)

### Descrição

O `ClienteController` do Back-end é responsável por gerenciar operações relacionadas aos clientes da aplicação, fornecendo endpoints para obter, adicionar, atualizar e excluir clientes.

### Endpoints Disponíveis

1. **Obter todos os clientes**
   - *Descrição:* Retorna uma lista de todos os clientes cadastrados.
   - *Método HTTP:* GET
   - *Endpoint:* `/api/Cliente`
   - *Resposta de Sucesso (200):* Lista de clientes no formato `IEnumerable<ReadClienteDto>`.

2. **Obter um cliente específico**
   - *Descrição:* Retorna informações detalhadas sobre um cliente específico com base no ID.
   - *Método HTTP:* GET
   - *Endpoint:* `/api/Cliente/{id}`
   - *Parâmetros de URL:* id (ID do cliente)
   - *Resposta de Sucesso (200):* Detalhes do cliente no formato `ReadClienteDto`.

3. **Adicionar um novo cliente**
   - *Descrição:* Adiciona um novo cliente à base de dados.
   - *Método HTTP:* POST
   - *Endpoint:* `/api/Cliente`
   - *Corpo da Requisição:* `CreateClienteDto`
   - *Resposta de Sucesso (201):* Retorna os detalhes do cliente recém-adicionado no formato `ReadClienteDto`.

4. **Atualizar informações de um cliente**
   - *Descrição:* Atualiza as informações de um cliente existente com base no ID.
   - *Método HTTP:* PUT
   - *Endpoint:* `/api/Cliente/{id}`
   - *Parâmetros de URL:* id (ID do cliente)
   - *Corpo da Requisição:* `UpdateClienteDto`
   - *Resposta de Sucesso (204):* Nenhuma informação adicional.

5. **Excluir um cliente**
   - *Descrição:* Remove um cliente da base de dados com base no ID.
   - *Método HTTP:* DELETE
   - *Endpoint:* `/api/Cliente/{id}`
   - *Parâmetros de URL:* id (ID do cliente)
   - *Resposta de Sucesso (204):* Nenhuma informação adicional.

## VeiculoController (Back-end)

### Descrição

O `VeiculoController` do Back-end é responsável por gerenciar operações relacionadas aos veículos da aplicação, fornecendo endpoints para obter, adicionar, atualizar e excluir veículos.

### Endpoints Disponíveis

1. **Obter todos os veículos**
   - *Descrição:* Retorna uma lista de todos os veículos cadastrados.
   - *Método HTTP:* GET
   - *Endpoint:* `/api/Veiculo`
   - *Resposta de Sucesso (200):* Lista de veículos no formato `IEnumerable<ReadVeiculoDto>`.

2. **Obter um veículo específico**
   - *Descrição:* Retorna informações detalhadas sobre um veículo específico com base no ID.
   - *Método HTTP:* GET
   - *Endpoint:* `/api/Veiculo/{id}`
   - *Parâmetros de URL:* id (ID do veículo)
   - *Resposta de Sucesso (200):* Detalhes do veículo no formato `ReadVeiculoDto`.

3. **Adicionar um novo veículo**
   - *Descrição:* Adiciona um novo veículo à base de dados.
   - *Método HTTP:* POST
   - *Endpoint:* `/api/Veiculo`
   - *Corpo da Requisição:* `CreateVeiculoDto`
   - *Resposta de Sucesso (201):* Retorna os detalhes do veículo recém-adicionado no formato `ReadVeiculoDto`.

4. **Atualizar informações de um veículo**
   - *Descrição:* Atualiza as informações de um veículo existente com base no ID.
   - *Método HTTP:* PUT
   - *Endpoint:* `/api/Veiculo/{id}`
   - *Parâmetros de URL:* id (ID do veículo)
   - *Corpo da Requisição:* `UpdateVeiculoDto`
   - *Resposta de Sucesso (204):* Nenhuma informação adicional.

5. **Excluir um veículo**
   - *Descrição:* Remove um veículo da base de dados com base no ID.
   - *Método HTTP:* DELETE
   - *Endpoint:* `/api/Veiculo/{id}`
   - *Parâmetros de URL:* id (ID do veículo)
   - *Resposta de Sucesso (204):* Nenhuma informação adicional.
  
## LocacaoController (Back-end)

### Descrição

O `LocacaoController` do Back-end é responsável por gerenciar operações relacionadas às locações de veículos, fornecendo endpoints para obter, adicionar e excluir locações.

### Endpoints Disponíveis

1. **Obter todas as locações**
   - *Descrição:* Retorna uma lista de todas as locações cadastradas.
   - *Método HTTP:* GET
   - *Endpoint:* `/api/Locacao`
   - *Resposta de Sucesso (200):* Lista de locações no formato `IEnumerable<ReadLocacaoDto>`.

2. **Obter uma locação específica**
   - *Descrição:* Retorna informações detalhadas sobre uma locação específica com base no ID.
   - *Método HTTP:* GET
   - *Endpoint:* `/api/Locacao/{id}`
   - *Parâmetros de URL:* id (ID da locação)
   - *Resposta de Sucesso (200):* Detalhes da locação no formato `ReadLocacaoDto`.

3. **Adicionar uma nova locação**
   - *Descrição:* Adiciona uma nova locação à base de dados.
   - *Método HTTP:* POST
   - *Endpoint:* `/api/Locacao`
   - *Corpo da Requisição:* `CreateLocacaoDto`
   - *Resposta de Sucesso (201):* Retorna os detalhes da locação recém-adicionada no formato `ReadLocacaoDto`.

4. **Excluir uma locação**
   - *Descrição:* Remove uma locação da base de dados com base no ID.
   - *Método HTTP:* DELETE
   - *Endpoint:* `/api/Locacao/{id}`
   - *Parâmetros de URL:* id (ID da locação)
   - *Resposta de Sucesso (204):* Nenhuma informação adicional.
  
## AppDbContext (Back-end)

A classe `AppDbContext` do Back-end representa o contexto do banco de dados para a aplicação. Responsável por definir as entidades do modelo e configurar os relacionamentos entre elas.
