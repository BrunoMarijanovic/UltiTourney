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
 8. AutoMapper v13.0.1

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

### Create Controller
To create an EndPont to manipulate the domain models is necesary have a Controller. It contains all the domain's EndPoints.  
  1. Go to "./Controllers" folder and add an API Controller empty.
  2. The name allways contains the sufix "Controller". Example name: CountriesController.cs
  3. The controller contains the IMapper and the model interface property.  
Info: The controller allways contains an interface from the folder "./Repositories".

### Mapper
To don't send the DB structure to the user, is necesary map the domain model to a DTO model with only the necesary information.  
  1. In the folder "./Models/DTO/{Domain_name}" create your class with the only the necesary information for the user.
  2. The file "./Mappings/AutoMapperProfiles.cs" contains all the mapping configuration.

### Repositories folder  
This folder contains two types of files:  
 1. An interface were exist all the header's functions.
 2. The SQL Repository contains the intererface and have all the logic from the functions.

### Create EndPoint
Once the controller is created, create your function doing your necesary actions using the interface and mapper.  
Info: Go to "./Program.cs" and add the scoped service "builder.Services.AddScoped({interface}, {sql_repository})".  
