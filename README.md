# EntityFrameworkExample
Entity Framework Example with Unity Dependencies Injection


## Set up the solution  ##
  1. Bajar el código. 
  2. Restaurar paquetes de nuget 
  3. Abrir Propiedades del proyecto Service/Servicio. En la pestaña Web, crear un Directorio Virtual que corra con IIS Express, con URL http://localhost:4598/Example
  4. Guardar cambios
  5. Compilar

## Set up the database  ##
  1. En SQL Server Management Studio, conectarse al server local y correr el script de la solución que se encuentra en Documents/DBScript/EntityFrameworkExampleDB
  2. En el caso de que el server donde se corra el script precise de algun usuario con seteo de seguridad, configurarlo en el Connection String "ExampleConnection" que está en el archivo Web.Config del Proyecto Service/Servicio. Actualmente, el connection string está configurado para hacer referencia a la base "EntityFrameworkExample", que corre en el server local "usuario-pc", y se loguea con credenciales de Windows.

## Set up the Postman Collection  ##
  1. Importar el ambiente local, que se encuentra en Documents/Postman/LocalhostEnvironment
  2. Importar la colección de Postman, que se encuentra en Documents/Postman/ExampleServiceCollection.json 
  3. Corriendo la solución, probar los 2 endpoints (Get y Update), apuntando al ambiente "Localhost" importado en el punto 1
