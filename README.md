# SmartBankProject

## Folder Structure

```
SmartBankProject/
├── .gitignore
├── ER Diagram/
│   └── Entity Relationship Diagram.jpg
├── README.md
└── SmartBank/
    ├── SmartBank.API/
    │   ├── Controllers/
    │   │   └── AuthController.cs
    │   ├── Data/
    │   │   └── AppDbContext.cs
    │   ├── Migrations/
    │   │   ├── 20260427092026_InitialCreate.Designer.cs
    │   │   ├── 20260427092026_InitialCreate.cs
    │   │   └── AppDbContextModelSnapshot.cs
    │   ├── Program.cs
    │   ├── Properties/
    │   │   └── launchSettings.json
    │   ├── Services/
    │   │   └── AuthService.cs
    │   ├── SmartBank.API.csproj
    │   ├── SmartBank.API.http
    │   ├── appsettings.Development.json
    │   └── appsettings.json
    ├── SmartBank.Core/
    │   ├── DTOs/
    │   │   └── Auth/
    │   │       ├── AuthResponseDto.cs
    │   │       ├── LoginDto.cs
    │   │       └── RegisterDto.cs
    │   ├── Interfaces/
    │   │   └── IAuthService.cs
    │   ├── Models/
    │   │   ├── Role.cs
    │   │   └── User.cs
    │   └── SmartBank.Core.csproj
    ├── SmartBank.MVC/
    │   ├── Controllers/
    │   │   └── HomeController.cs
    │   ├── Models/
    │   │   └── ErrorViewModel.cs
    │   ├── Program.cs
    │   ├── Properties/
    │   │   └── launchSettings.json
    │   ├── SmartBank.MVC.csproj
    │   ├── Views/
    │   │   ├── Home/
    │   │   │   ├── Index.cshtml
    │   │   │   └── Privacy.cshtml
    │   │   ├── Shared/
    │   │   │   ├── Error.cshtml
    │   │   │   ├── _Layout.cshtml
    │   │   │   ├── _Layout.cshtml.css
    │   │   │   └── _ValidationScriptsPartial.cshtml
    │   │   ├── _ViewImports.cshtml
    │   │   └── _ViewStart.cshtml
    │   ├── appsettings.Development.json
    │   ├── appsettings.json
    │   └── wwwroot/
    │       ├── css/
    │       │   └── site.css
    │       ├── favicon.ico
    │       ├── js/
    │       │   └── site.js
    │       └── lib/
    │           ├── bootstrap/
    │           │   ├── LICENSE
    │           │   └── dist/
    │           │       ├── css/
    │           │       │   ├── bootstrap-grid.css
    │           │       │   ├── bootstrap-grid.css.map
    │           │       │   ├── bootstrap-grid.min.css
    │           │       │   ├── bootstrap-grid.min.css.map
    │           │       │   ├── bootstrap-grid.rtl.css
    │           │       │   ├── bootstrap-grid.rtl.css.map
    │           │       │   ├── bootstrap-grid.rtl.min.css
    │           │       │   ├── bootstrap-grid.rtl.min.css.map
    │           │       │   ├── bootstrap-reboot.css
    │           │       │   ├── bootstrap-reboot.css.map
    │           │       │   ├── bootstrap-reboot.min.css
    │           │       │   ├── bootstrap-reboot.min.css.map
    │           │       │   ├── bootstrap-reboot.rtl.css
    │           │       │   ├── bootstrap-reboot.rtl.css.map
    │           │       │   ├── bootstrap-reboot.rtl.min.css
    │           │       │   ├── bootstrap-reboot.rtl.min.css.map
    │           │       │   ├── bootstrap-utilities.css
    │           │       │   ├── bootstrap-utilities.css.map
    │           │       │   ├── bootstrap-utilities.min.css
    │           │       │   ├── bootstrap-utilities.min.css.map
    │           │       │   ├── bootstrap-utilities.rtl.css
    │           │       │   ├── bootstrap-utilities.rtl.css.map
    │           │       │   ├── bootstrap-utilities.rtl.min.css
    │           │       │   ├── bootstrap-utilities.rtl.min.css.map
    │           │       │   ├── bootstrap.css
    │           │       │   ├── bootstrap.css.map
    │           │       │   ├── bootstrap.min.css
    │           │       │   ├── bootstrap.min.css.map
    │           │       │   ├── bootstrap.rtl.css
    │           │       │   ├── bootstrap.rtl.css.map
    │           │       │   ├── bootstrap.rtl.min.css
    │           │       │   └── bootstrap.rtl.min.css.map
    │           │       └── js/
    │           │           ├── bootstrap.bundle.js
    │           │           ├── bootstrap.bundle.js.map
    │           │           ├── bootstrap.bundle.min.js
    │           │           ├── bootstrap.bundle.min.js.map
    │           │           ├── bootstrap.esm.js
    │           │           ├── bootstrap.esm.js.map
    │           │           ├── bootstrap.esm.min.js
    │           │           ├── bootstrap.esm.min.js.map
    │           │           ├── bootstrap.js
    │           │           ├── bootstrap.js.map
    │           │           ├── bootstrap.min.js
    │           │           └── bootstrap.min.js.map
    │           ├── jquery-validation-unobtrusive/
    │           │   ├── LICENSE.txt
    │           │   └── dist/
    │           │       ├── jquery.validate.unobtrusive.js
    │           │       └── jquery.validate.unobtrusive.min.js
    │           ├── jquery-validation/
    │           │   ├── LICENSE.md
    │           │   └── dist/
    │           │       ├── additional-methods.js
    │           │       ├── additional-methods.min.js
    │           │       ├── jquery.validate.js
    │           │       └── jquery.validate.min.js
    │           └── jquery/
    │               ├── LICENSE.txt
    │               └── dist/
    │                   ├── jquery.js
    │                   ├── jquery.min.js
    │                   ├── jquery.min.map
    │                   ├── jquery.slim.js
    │                   ├── jquery.slim.min.js
    │                   └── jquery.slim.min.map
    └── SmartBank.slnx
```
