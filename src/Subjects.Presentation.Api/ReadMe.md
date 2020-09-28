Create Project (MVC or WebApi)
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Scaffold-DbContext "Server=tcp:goodtocodestack.database.windows.net,1433;Initial Catalog=StackData;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeStack;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
Right-click Controllers folder, Add Controller, MVC/WebAPI with EF Actions