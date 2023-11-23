# Cliente Model

A classe `Cliente` representa a entidade de Cliente na aplicação.

## Propriedades

- **Id** (int, chave primária): Identificador único do cliente.
- **Nome** (string, máximo 200 caracteres): Nome do cliente.
- **Email** (string, máximo 200 caracteres): Endereço de e-mail do cliente.
- **Locacoes** (ICollection<Locacao>): Coleção de locações associadas ao cliente.

## Atributos

- Atributo **Key**: Indica que a propriedade `Id` é a chave primária da entidade.
- Atributo **StringLength(200)**: Limita as propriedades `Nome` e `Email` a um máximo de 200 caracteres.

# Locacao Model

A classe `Locacao` representa a entidade de Locação na aplicação.

## Propriedades

- **Id** (int, chave primária): Identificador único da locação.
- **DataColeta** (DateTime): Data em que o veículo foi retirado para locação.
- **DataEntrega** (DateTime): Data prevista para a devolução do veículo.
- **ValorTotalLocacao** (double): Valor total da locação.
- **Cliente** (Cliente): Representa o cliente associado à locação.
- **Veiculo** (Veiculo): Representa o veículo associado à locação.
- **IdCliente** (int): ID do cliente associado à locação.
- **IdVeiculo** (int): ID do veículo associado à locação.

## Atributos

- Atributo **Key**: Indica que a propriedade `Id` é a chave primária da entidade.
- Atributos **ForeignKey("IdCliente")** e **ForeignKey("IdVeiculo")**: Indicam as chaves estrangeiras nas propriedades `Cliente` e `Veiculo`, respectivamente.

# Veiculo Model

A classe `Veiculo` representa a entidade de Veículo na aplicação.

## Propriedades

- **Id** (int, chave primária): Identificador único do veículo.
- **TipoVeiculo** (string, máximo 100 caracteres): Tipo do veículo (por exemplo, sedan, SUV, etc.).
- **Marca** (string, máximo 200 caracteres): Marca do veículo.
- **Modelo** (string, máximo 200 caracteres): Modelo do veículo.
- **Placa** (string, máximo 50 caracteres): Placa do veículo.
- **ValorDiaria** (double): Valor da diária de locação do veículo.
- **Locacoes** (ICollection<Locacao>): Coleção de locações associadas ao veículo.

## Atributos

- Atributo **Key**: Indica que a propriedade `Id` é a chave primária da entidade.
- Atributo **StringLength(100)**: Limita a propriedade `TipoVeiculo` a um máximo de 100 caracteres.
- Atributo **StringLength(200)**: Limita as propriedades `Marca` e `Modelo` a um máximo de 200 caracteres.
- Atributo **StringLength(50)**: Limita a propriedade `Placa` a um máximo de 50 caracteres.
- Atributo **Range(0, 999999.99)**: Define um intervalo permitido para o valor da diária.
