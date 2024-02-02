## Model Configuration

### Encryption and decryption
- https://github.com/Eastrall/EntityFrameworkCore.DataEncryption (Did not work. Changed to hashing)

### [Running migrations in a class library](https://stackoverflow.com/a/68173928)
Run migrations from api folder
```
$ dotnet ef migrations add <MIGRATION_NAME> --project src/TeamSync.Infrastructure/ --startup-project src/TeamSync.Api/
```

### Naming Convetion
- Use the [EFCore.NamingConventions](https://www.nuget.org/packages/EFCore.NamingConventions/) nuget package for naming convetions in database.