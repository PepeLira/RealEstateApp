# RealEstateApp - Grupo 7 - Sofware Verificable 
### Universidad de los Andes

# Objetivo

Este Repositorio contiene el proyecto para 
el curso Software Verificable de la Universidad de los Andes. 
El objetivo del proyecto es crear un sistema de inscripciones de propiedades del 
registro civil utilizando Visual Studio 2022. 

Se eligi� como herramienta de desarrollo web [ASP.NET](http://asp.net/) junto a la dependencia
Entity Framework Core para administrar el modelo de datos conectado a una base de 
datos en Microsoft SQL Server.  

# Build del Proyecto  

Para comenzar a ejecutar este proyecto es necesario instalar las siguientes dependencias 
usando la consola de paquetes de Visual Studio disponible en `Tools>NuGet Package Manager> Package Manager Console`.  

## Paso 1: Dependencias
```
Install-Package Microsoft.EntityFramerwokCore  
Install-Package Microsoft.EntityFrameworkCore.SqlServer  
Install-Package Microsoft.EntityFrameworkCore.Tools  
Install-Package Microsoft.EntityFrameworkCore.Design  
Install-Package Microsoft.EntityFrameworkCore.Proxies  
```

## Paso 2: Configuraci�n Servidor SQL

Para conectar Microsoft SQL Server simplemente debemos agregar el nombre de nuestro servidor en el archivo `appsettings.json`, como se indica a continuaci�n:

```
...

"AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=NOMBRE_DE_SERVIDOR;
    Database=RealEstateAppGrupo7Db;
    Trusted_Connection=True;TrustServerCertificate=True;"
  }

```

## Paso 3: Correr Migraciones

Para correr las migraciones simplemente ejecutamos la siguiente instrucci�n en la `Consola del administrador de packetes`:

```
update-database
```

�Y listo!, ya podemos correr la aplicaci�n desde la UI de Visual Studio. Al momento de correr la aplicaci�n se agregar�n datos de prueba disponibles en `Data/SeedData.cs`.


# Utilidades

Ac� recopilamos algunos comandos �tiles para trabajar con `EntityFrameworkCore.Tools`

Migration commands:

- `add-migration AddInscriptionToDatabase` Para crear una nueva migraci�n.
- `update-database` Para lanzar los cambios al servidor.
- `drop-database` Para borrar la base de datos. 
- `remove-migration` Para borrar la ultima migraci�n.