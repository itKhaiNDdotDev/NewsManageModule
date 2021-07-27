# News Manage Module by C#/.NET Core 2.1 - Backend
## Technologies
- C# 7.3
- ASP.NET Core 2.1
- SQL Server 2019 (v18.9.1)
- Entity Framwork Core

## Packages and Libraries
### Nuget Packages for ./..Data:
- Microsoft.EntityFrameworkCore.SqlServer  (v2.1.14)
- Microsoft.EntityFrameworkCore.Design  (v2.1.14)
- Microsoft.EntityFrameworkCore.Tools  (v2.1.14)
- Microsoft.Extensions.Configuration.FileExtensions (v2.1.1)
- Microsoft.Extensions.Configuration.Json (v2.1.1)
- Microsoft.AspNetCore.Identity.EntityFrameworkCore (v2.1.6)
### For ./..Services:
**Nuget Packages:**
- Microsoft.AspNetCore.Http.Features (v2.1.1)

**Other Libraties:**
- *using* System.Threading.Tasks;
- *using* System.Linq;
- *using* Microsoft.EntityFrameworkCore;

**References:**  
- NewsManageModule.Data
- NewsManageModule.Helpers
- NewsManageModule.ViewModels

**Add Framework (Edit file .csproj):**  
Add the following:  

*<ItemGroup>
		<!-- <PackageReference Include="Microsoft.AspNetCore.Hosting" Version="2.2.7" /> -->
		<!-- <PackageReference Include="Microsoft.AspNetCore.Hosting.Abstractions" Version="2.2.0" /> -->
		<!-- <PackageReference Include="Microsoft.Extensions.Hosting" Version="3.1.17" /> -->
		<FrameworkReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>*
## More Info
- Dev: Nguyễn Duy Khai (itKhaiND.Dev)
-- Contact: [Facebook](https://www.facebook.com/itKhaiND.Dev)
- Version: 0 (Draft)
- Jul-2021

