# Objektumelvű Programozás 2023

## .NET projekt léterhozása CLI használatával

```sh
# Legyél egy olyan mappában ahová a solution-t szeretnéd tenni
$ mkdir <PROJECTNAME> && dotnet new console -n <PROJECTNAME> -o <PROJECTNAME>/
$ mkdir <UNITTESTPROJECTNAME> && dotnet new mstest -n <UNITTESTPROJECTNAME> -o <UNITTESTPROJECTNAME>/ # Ha szeretnél egységtesztet írni
$ dotnet new sln -n <SOLUTIONNAME>
$ dotnet sln add <PROJECTNAME>
$ dotnet sln add <UNITTESTPROJECTNAME>
$ dotnet add <UNITTESTPROJECTNAME>/<UNITTESTPROJECTNAME>.csproj reference <PROJECTNAME>/<PROJECTNAME>.csproj
```

## Ezután futtatás CLI-on

```sh
# Legyél a solution mappájában
$ dotnet run --project <PROJECTNAME>
$ dotnet test
```
