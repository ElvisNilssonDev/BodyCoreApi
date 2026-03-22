# TrainingTrackerApi
A training app for my own goal of becoming a bodybuilder for asthetic purposes. All apps for training is pay to use so I wil lcreate my own!<br/>
* The app will contain a way for Nutrition entries to be added for steady calorie count.
* The app will give you the resources to logg your weeks, days and specific lifts.

# Installation requirements
Install these first:<br/>
<br/>
Visual Studio 2022 or newer
During install, include:
ASP.NET and web development
Data storage and processing if available
.NET 10 SDK
Your API project targets net10.0, so an older SDK will fail to build. Microsoft’s current .NET download page shows .NET 10 as an LTS release.<br/>
<br/>
SQL Server Express
Microsoft currently offers SQL Server 2025 Express as the free edition.<br/>
<br/>
SSMS
Microsoft’s current generally available SSMS release is SSMS 22, and Microsoft says SSMS 22 is the latest GA version.<br/>
<br/>
VS Code
With these extensions:
Live Server
JavaScript and HTML/CSS support
optional: REST Client<br/>
<br/>
# Installation part 1
Step 1

Clone the API repo:

git clone https://github.com/ElvisNilssonDev/BodyCoreApi.git <br/>

Step 2

Open the folder in Visual Studio.

Open either:

the solution file if Visual Studio sees it, or
the TrainingTrackerApi project folder directly <br/>

Step 3

Wait for NuGet packages to restore.

Your project uses:

Entity Framework Core
SQL Server provider
EF tools
Swagger
AutoMapper

If restore fails, run this in the Package Manager Console or terminal: dotnet restore<br/>
# Installation part 2
Set up SQL Server Express and SSMS

Your current API connection string in appsettings.json is:

"DefaultConnection": "Server=.\\SQLEXPRESS;Database=TrainingTrackerDb;Trusted_Connection=True;TrustServerCertificate=True"

That means the API expects a local SQL Server Express instance named SQLEXPRESS and a database called TrainingTrackerDb.

Step 1

Install SQL Server Express.

During install, make sure the instance name is:

SQLEXPRESS

If you pick a different name, you must update appsettings.json.

Step 2

Install SSMS and open it.

In SSMS, connect using:

Server type: Database Engine
Server name: .\SQLEXPRESS
Authentication: Windows Authentication

If that connects, SQL Server Express is working.

<br/> Current progress in the BodyCore frontend:
![Concept:](https://github.com/ElvisNilssonDev/TrainingTrackerApi/blob/3455b83d480574440885e372bc4d402e31fa5334/Images/image_2026-03-18_173546277.png)<br/>

