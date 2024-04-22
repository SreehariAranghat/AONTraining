//Code first
#Create Migration
Add-Migration "Name"

#UpdateDataBase
Update-Database

//Db First
#Scaffold
Scaffold-DbContext [-DataAnnotations] "ConStr" ProviderType[Microsoft.EntityFrameworkCore.SqlServer]
 [-Force]