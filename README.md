**A short description a bout this project :**

In Brands project  ,an user register in it then he/she can add , remove and edit brands features in addition their images ,and if that user refer to project with the same user name , he will see his changes that he have done last time.

Also this project has a test layer that is written by Unit Test and XUnit.

The test used in this project is the repository layer test.

The used technologies in this project are :

C# , ASP.Net Core 2.1 , MVC , Repository Design Pattern , EF , EF Core , Ajax , Dependency Injection , XUnit , Javascript , TDD , Unit Test , XUnit , JWT , Web API , Identity , SQL Server 2017 (SSMS 17.4).

**Important** : As much as possible ,I selected meaningful names for variables , functions ,classes and other members of project ,therefor ,this project is approximately *self document*.


**Features and abilities :**

This project has three layers moreover a test layer :

Web layer

Data layer

Core layer

Test layer

One of the features of this project is that , in test layer is used from Moq tool , also the mock data and test are distincted from eachother.

This is meaning we have two class , anyone for mock data and other for Xunit statements.

The data in mock data class is used in Xunit class by dependency injection , therefore data in mock class is not necessary to be repeat and is written only one time (for every repository).

Notice that all of add , remove and deleting the brands work by Ajax.

For more security of Ajax statements , it is used JWT.

**Detected problems and its solutions :**

- As I said one of the problems was that maybe we wanted create mock data  for every XUnit test method distinctly , this is causes to rework. For solving this problem , the mock data was distict from XUnit statements , and they corelate by Dependency Injection , also this is better about SOLID rules , because now we have two separate class that every one work with a different mode.	
- Another problem is that for repository layer test we should have two auxiliary class that named AuxiliaryClassForTest and CreateDbSetMocks. For all cases about repository layer test , the content of these classes is constant and they are used in same form.
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

- And about another challenge is that when we were creating mock data in UserMoqData  file , since the these data were mocked data on disk, the passwords (that are a field of user table) should be in hashed mode.

**Authorization on this project :**

There are used a Combination maner to authorization in this project.
As you see in startup file ,I used both of JwtBearer and Cookie based authentication.
But when the project used JwtBearer authentication and when used Cookie authentication?
The answer is that if the authorization header starts with "Bearer" ,it is used JwtBearer authentication,
else it is used Cookie authentication.

**How project works**

For the first time that an user signs up , AuthClientSideController and within it , Login method will be run , that it gets user name and password and in line 51 ,it registers the user in server controller (by posting user name and password to AuthServerSideController and within it ,Post method) and in continue ,it sends built token from AuthServerSideController to AuthClientSideController and signs in user in client controller.

Notice that we had a client side controller (AuthClientSideController) and a server side controller (AuthServerSideController) , that is meaning if we had a really and remote API (Instead of these APIs that are created only for Ajax) , we should had a server side controller and a client side , by these contents.

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

E-Mail : <behrooz0372@gmail.com>

**License**

The license of this project is in *License* file.


