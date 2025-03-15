# ATM Operations with Database

## Description

This console application simulates an ATM operation system where users can interact with their accounts. It is designed to demonstrate basic database operations such as user authentication, balance checks, and transactions. The project uses **Entity Framework Core** for database interaction and is connected to a **SQL Server** database.

The purpose of this project is to showcase programming skills, database interactions, and object-oriented design. It is **not intended for production use** and does not implement advanced security practices such as password hashing or encryption, which are critical in real-world applications.

## Features

- **User Authentication**: Users can log in using their card number. The program checks if the card number exists, then prompts for the PIN associated with that card number.
- **Account Operations**: After logging in, users can check their current balance, change their PIN and withdraw or deposit money.
- **Database Seeding**: The database is seeded with a few example users to demonstrate functionality.

## How to Set Up the Connection String

1. Clone the repository to your local machine.

2. Open the project in your preferred IDE (e.g., Visual Studio).

3. Inside the project folder, locate the `appsettings.json.example` file.

4. Rename `appsettings.json.example` to `appsettings.json`.

5. Open the `appsettings.json` file and set your **SQL Server** connection string. For example:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your-server-name\\SQLEXPRESS;Database=AtmDB;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }

## Restore NuGet Packages

1.Open the project in Visual Studio.

2.Right-click on the solution in Solution Explorer and click Restore NuGet Packages.

3.Alternatively, you can run this in the Package Manager Console:
dotnet restore

## Apply migrations and Update the Database

If the migrations haven’t been applied yet, you can update the database schema:

1. Open the **Package Manager Console** in Visual Studio and run:
Update-Database

2.Alternatively, use the .NET CLI:
dotnet ef database update



