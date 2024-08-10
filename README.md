# UltiTourney  

 ## API  
 ### Get Started  
 With Visual Studio 2022 install the following extensions (Dependencies > Admin NuGet):  
 1. Microsoft.AspNetCore.Authentication.JwtBearer v8.0.7
 2. Microsoft.IdentityModel.Tokens v8.0.1
 3. System.IdentityModel.Tokens.Jwt v8.0.1
 4. Microsoft.AspNetCore.Identity.EntityFrameworkCore v8.0.7
 5. Swashbuckle.AspNetCore v6.7.0
 6. Microsoft.EntityFrameworkCore.SqlServer v8.0.7
 7. Microsoft.EntityFrameworkCore.Tools v8.0.7

 ### Create Domain Model  
 Follow the project structure and create the domain model and also do the migration to DB to create the tables.
 1. Create your class in the path "./Models/Domain/".
 2. In the created class, add all the necessary parameters and navigation properties. Example of parameter: "public Guid Id { get; set; }".
 3. Go to "./Data/UltiTourneyDbContext.cs" and create the necessary properties. If contains default data, create it in the class "OnModelCreating".
 4. Open the "Pakage Manager Console" and run the following commands:
   - Add-Migration "Name migration"
   - Update-Database
 5. Once the command is done, enjoy your new tables from the DB.

### DB connection  
To connect at your DB go to "./appsettings.json" and add the following data and make sure to inject the correct DB context in "./Program.cs":  
  "ConnectionStrings": {  
    "UltiTourneyConnectionString": "Server={serverName};Database=UltiTourneyDb;Trusted_Connection=True;TrustServerCertificate=True"  
  }  

### Create a GET EndPoint
