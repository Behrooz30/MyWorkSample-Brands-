**A short description a bout this project :**

In Brands project, an user can register in it then he/she can add , remove and edit brands features in addition their images ,and if that user again logins to project with the same user name and password, he will see his changes that he have done last time.

Also this project has a test layer that is written by Unit Test and XUnit.

The test used in this project is the same repository layer test.

**Important**: This is an ASP.Net Core  (2.1) project with three layers architecture plus one test layer and MSSQL (2017) database, that is Dockerized on Linux (Alpine) very well. This is exist on *Dockerized-Version* branch.

Attention: The branch with name "From-Insecure-File-Upload-attacks-is-avoided",
is the optimized branch that on that is avoided from "Insecure-File-Upload"
attacks.
The used technologies in this project are :

C# , ASP.Net Core 2.1 , MVC , Repository Pattern , EF , EF Core , Ajax , Dependency Injection , XUnit , Javascript , TDD , Unit Test , XUnit , JWT , Web API , Identity , SQL Server 2017 (SSMS 17.4) , MOQ , Docker , Docker Compose , Linux.

**Important** : As much as possible ,I selected meaningful names for variables , functions ,classes and other members of project ,therefor ,this project is approximately *self document*.

**First of all:**
For running Docker image of this project you should at first download the main custom image file of this project from this address:
https://www.mediafire.com/file/qvnwpq5kbun0zgs/brands-web.zip/file
then transform it to Docker Contents folder in project (write next to Compose.yaml file).
Now open CMD and set Docker Contents folder as current folder in CMD.
Now use this command in CMD:
*docker image load -i brands-web.zip*
And then use this command:
*docker-compose up*
And wait for download dependencies, and this is end.


**Features and abilities :**
In Dockerized-Version, database files will be attached automatically.
This is because Dockerfile.database  file will be launched via docker-compose. Then run-initialization.sh will be launched and after that entrypoint.sh file will be launched.
And in this file database will be attached.
This project has three layers moreover a test layer :

Web layer

Data layer

Core layer

Test layer

One of the features of this project is that, in test layer is used from Moq tool, also the mock data and test are distincted from eachother.

This is meaning we have two class, anyone for mock data and other for Xunit statements.

The data in mock data class is used in Xunit class by dependency injection, therefore data in mock class is not necessary to be repeat and is written only one time (for every repository).

Notice that all of add, update and deleting the brands work by Ajax.

For more security of Ajax statements, it is used JWT.

**Detected problems and its solutions :**

- One of the problems was using run-initialization.sh and entrypoint.sh files in Windows. Pay attention these files belonged to Linux, we can not create and edit these files simply in windows. We should use Notepad++ and after creating and editing these file, we should clear its characters have conflicted in windows. For solving this problem in Notepad++ go to 
    Edit => EOL Conversion => Unix (LF)
    menu and select that.
- As I said one of the problems was that maybe we wanted create mock data  for every XUnit test method distinctly, this is causes to rework. For solving this problem, the mock data was distict from XUnit statements, and they corelate by Dependency Injection, also this is better about SOLID rules, because now we have two separate class that every one work with a different mode.	
- Another problem is that for repository layer test we should have two auxiliary class that named AuxiliaryClassForTest and CreateDbSetMocks. For all cases about repository layer test, the content of these classes is constant and they are used in same form.
- Another problem was that in mock data file of Brands (BrandsMoqData) we had a foreign key field that should had value. Therefore we determined virtual relation between two mocked table by two for loop :

//Create relation between User and Brands

`           	 `foreach (User user in users)

`          	  `{

user.Brands = brands.Where(p => p.UserId == user.UserId).ToList();

`              `}


`            `foreach (Brands.DataLayer.Entities.Brands brand in brands)

`              `{

`        `brand.Users = users.SingleOrDefault(p =>   p.UserId == brand.UserId);

`           	  `}

- Another challenge also was an error that program gave when we used *FindAsync()* method in repository methods. For solve this problem I used this code on mock data files:

mockSetUser.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync((object[] r) =>

`            `{

`                `var id = (int)r[0];

`                `return users.FirstOrDefault(x => x.UserId == id);

`            `});

The above block is mocking *FindAsync()* method of a DbSet object.

- And about another challenge is that when we were creating mock data in UserMoqData  file, since the these data were mocked data on disk, the passwords (that are a field of user table) should be in hashed mode.

- Other challenge is avoiding from "Insecure File Upload" attacks.
  This problem is when we save the data in wwwroot folder and it leads to access all
  users to our data(in normal state).
  For avoiding from this problem I use middlewares,in startup file and in the first of Configure method, my code is meaning :if anyone wants to access to data in wwwroot (Brands Images folder) as a unauthorized user then they navigate to Login page.

**Authorization on this project :**

There are used a Combination maner to authorization in this project (Multi-Factor Authentication).
As you see in startup file, I used both of JwtBearer and Cookie based authentication.
But when the project used JwtBearer authentication and when used Cookie authentication?
The answer is that if the authorization header starts with "Bearer", it is used JwtBearer authentication,
else it is used Cookie authentication.

**How project works**

For the first time that an user signs up, AuthClientSideController and within it, Login method will be run, that it gets user name and password and in line 51, it registers the user in server controller (by posting user name and password to AuthServerSideController and within it, Post method) and in continue, it sends built token from AuthServerSideController to AuthClientSideController and signs in user in client controller.

Notice that we had a client side controller (AuthClientSideController) and a server side controller (AuthServerSideController), that is meaning if we had a really and remote API (Instead of these APIs that are created only for Ajax), we should had a server side controller and a client side, by these contents.

**How this project has been Dockerized**

I used Visual Studio 2017 for this flow.
I describe  the totally flow for all three layer projects that have an MSSQL database.
Also these project are developed on ASP.Net Core (2.1), and Dockerized on Linux (Alpine).
First of all right click on Web layer in your project and then click on *Add* and from its subset click on *Docker Support*. Then select *Linux* option.
Visual Studio will create dockerfile but we will use ourselves dockerfile and not in this place, I create my dockerfile in one folder above write next to solution file. Also I created a Dockerfile.database in same place for creating and attaching database, and I create compose file in parent folder of solution file.
you can see these files and its contents in *Docker Contents* folder in project. We have .mdf and .ldf files also in this folder specifically in the place you see.
Also I described about two other files with *sh* extension before (in this article). 
We should change the contents of startup file and Domain name file Also, as you see in project.
At end we should build the image file by this command (the current folder in CMD should be *Docker Contents* folder in project):

*docker-compose –f compose.yaml build*

Only important point is that, use 
    build:
      context: ./Brands
      dockerfile: Dockerfile
instead of *image* part in compose file.
And the image will be created.
Please be sure from being Docker as default web server (not IIS and not other options). Even default web server should not be as Self Server option.


**Dependencies of project**

## Dependencies (All of these are about NuGet)

### Brands.Core Layer :


- Microsoft.EntityFrameworkCore : Version 2.1.2
- Microsoft.EntityFrameworkCore.SqlServer : Version 2.1.2

### Brands.DataLayer :


- Microsoft.EntityFrameworkCore : Version 2.1.2
- Microsoft.EntityFrameworkCore.SqlServer : Version 2.1.2

### Brands.Web :


- Microsoft.AspNetCore.App : Version 2.1.1
- Microsoft.AspNetCore.Razor.Design : Version 2.1.2
- Microsoft.EntityFrameworkCore : Version 2.1.2
- Microsoft.EntityFrameworkCore.Design : Version 2.1.2
- Microsoft.EntityFrameworkCore.SqlServer : Version 2.1.2
- Microsoft.VisualStudio.Web.CodeGeneration.Design : Version 2.1.9
- Moq : Version 4.18.1

### TestLayer :


- Microsoft.EntityFrameworkCore : Version 2.1.2
- Microsoft.EntityFrameworkCore.Design : Version 2.1.2
- Microsoft.EntityFrameworkCore.SqlServer : Version 2.1.2
- Microsoft.NET.Test.Sdk : Version 15.9.0
- Moq : Version 4.18.1
- Xunit : Version 2.4.0
- xunit.runner.visualstudio : Version 2.4.0

**Contact with developer**

E-Mail : <Behrooz0372@gmail.com>

**License**

The license of this project is in *License* file.


