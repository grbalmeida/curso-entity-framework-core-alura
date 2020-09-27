### Comando para instalação do Entity Framework Core

```
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 1.1
```

### Comando para instalação do pacote de Migrations

```
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 1.1.1
```

### Comando para adicionar a migration Unidade

```
Add-Migration Unidade
```

### Comando para atualizar o banco de dados de acordo com as migrações

```
Update-Database -Verbose
```