# _Hair Salon_

#### _This web app was created to test C# methods with an MVC routing structure. CRUD and Restful conventions are observed. All of this is done in the .Net environment. Data is handled using Entity which is linked to a local SQL server._

#### By _Joel Stockamp_

## Description

_A salon owner can manage their employees and the clients they are associated with by using this interface. Clients may only have one stylist, but a stylist can have many clients. This project is setup to update a database from the code._

## Setup/Installation Requirements

* download this package from github: https://github.com/stockampj/Stylist.git
* open a terminal and navigate to the project folder
* enter the command "dotnet restore"
* you will need a SQL database to hold the data tables for this project. You may need to download the necessary software to run it. Once you've set up a local server on Port 3306, continue to the next step
* if you want the database to be built by the code, run the command "dotnet ef database update". Enter the command "dotnet run" and open a browser to http://localhost:5000/.
* if you need to manually build the database, use MySQL Workbench. You will need to use Workbench to create a new schema with the title joel_stockamp. (This can be changed if you want to alter the name in the appsettings.json folder)
* create a Stylists table with the following columns.
StylistID (INT11) with PrimaryKey, NN and AI checked. A Name (LONGTEXT), a Specialty(LONGTEXT), and a ProfilePictureID(INT11) column (note that this is currently not in use).
* create Clients table with the following columns.
* ClientID (INT11) with PrimaryKey, NN and AI checked. A Name_First (LONGTEXT), a Name_Last (LONGTEXT), a Phone (LONGTEXT), and a StylistID(INT11) column
* At this point run the command "dotnet run" from a terminal and open a browser to http://localhost:5000/.

## Known Bugs

_There is no formatting/data validation of input fields so empty name fields may result in navigation/format errors._

## Support and contact details

_Please let me know if you want to chat: stockampj@gmail.com_

## Technologies Used

_C#, VSCode NuGet, MVC, Entity, InkScape, BootStrap, Font Awesome_

### License

*MIT License*

Copyright (c) 2019 **_Joel Stockamp_**
