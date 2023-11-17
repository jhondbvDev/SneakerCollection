# SneakerCollection

This project consists on an API for managment sneakers of different types in which the user would be able to create, edit, view and delete his own sneaker.
The project supports OpenAPI specification so the user would be able to access the API and test it directly from Swagger.


## Used technologies and patterns

* .Net 6.0
* Swagger (OpenAPI)
* Entity Framework Core (ORM)
* Code First Design (EF Core)
* InMemory Storage (EF Core)
* Clean Architecture
* DDD
* DTOs
* Repository Pattern
* Services
* JWT
* Unit Test 
* Moq

## Steps to run the project

As a quick note, this project is running on an InMemory database which improve the testing efforts speed since there is no need for a database engine to test this code. This implies that the data used on each execution of the project (if the API is restarted or shut down) will be erased. 

### Run it from code

1. Clone the project from this [repository](https://github.com/jhondbvDev/SneakerCollection)
2. Make sure you have installed .Net 6
3. Execute the project from Visual Studio 2022 or Visual Studio Code
4. The server will start and you should be able to see the swagger enpoint after the load is finished
5. Start testing
