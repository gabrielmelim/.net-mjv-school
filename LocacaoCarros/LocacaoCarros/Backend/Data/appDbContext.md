# AppDbContext Class

A classe `AppDbContext` representa o contexto do banco de dados para a aplicação.

## Construtor

- **AppDbContext(DbContextOptions<AppDbContext> options)**: Construtor que recebe as opções de configuração do DbContext.

## Métodos

- **OnModelCreating(ModelBuilder modelBuilder)**: Sobrescreve o método `OnModelCreating` para configurar o modelo do banco de dados.

    - **Configuração da Relação Cliente-Locacao:**
        - Estabelece a relação entre a entidade `Locacao` e a entidade `Cliente`.
        - A propriedade `IdCliente` na entidade `Locacao` é configurada como chave estrangeira, referenciando a chave primária `Id` na entidade `Cliente`.

    - **Configuração da Relação Veiculo-Locacao:**
        - Estabelece a relação entre a entidade `Locacao` e a entidade `Veiculo`.
        - A propriedade `IdVeiculo` na entidade `Locacao` é configurada como chave estrangeira, referenciando a chave primária `Id` na entidade `Veiculo`.

## Propriedades

- **Clientes** (DbSet<Cliente>): Representa a tabela no banco de dados correspondente à entidade `Cliente`.
- **Veiculos** (DbSet<Veiculo>): Representa a tabela no banco de dados correspondente à entidade `Veiculo`.
- **Locacoes** (DbSet<Locacao>): Representa a tabela no banco de dados correspondente à entidade `Locacao`.
