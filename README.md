# Product Service

A simple POC for a web api that gathers product information from an external rest api and NoSql data store. 

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

Running the project requires docker and docker compose.  

```
https://www.docker.com/products/docker-desktop
https://docs.docker.com/compose/install/
```

Executing the tests requires the .NET SDK and cli 

```
https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/install
```

### Installing

A step by step series of examples that tell you how to get a development env running.

Navigate to the root of the product-services project

```
cd ${HOME}/product-services
```

Execute docker-compose

```
docker-compose up
```

The application is ready when the console logs show the following:
```
app_1      | Now listening on: http://[::]:5000
app_1      | Application started. Press Ctrl+C to shut down

```
The api can now be accessed via your REST client of choice. 

There is pre-seeded price for productId=13860428, so the following curl command will return a full response:

```
curl http://localhost:5000/products/13860428
```

## Running the tests

Unit Tests live in the ProductService.Tests project. They can be run by executing `dotnet test` from the root of the Test project. 

The System Tests live in the ProductService.SystemTests project. They require a running instance of the application to point to. Open a terminal and run the application via the docker-compose from the root of the product-service project. When it is ready, open a different terminal and navigate to the root of the ProductService.SystemTest project and execute `dotnet test`.


## Built With

* [Docker](www.docker.com) - The container framework to run the application
* [.NET Core](https://github.com/dotnet/core) - Development Framework
* [MongoDb](https://www.mongodb.com/) - NoSql datastore

## Notes

* Of all the example product ids provided, I was only able to receive a valid response from one (13860428).
I decided to use the "title" field to populate the name as it most closely fit the sample response given in the prompt. 
I'm not sure if the structure of the json differs for different products that are not movies, but I have a feeling I would have to get creative in determining how to derive the "name".
* I chose to return a 404 if I did not get a valid "name" from the redsky api. If the database did not have a price stored for a given productId I chose to not include the current_price field on the response. Those choices were kind of arbitrary - Ideally I'd ask for more direction from a product owner on how to handle those cases
* I chose not to map the mongodb data to a volume outside of the container just to keep this neat. As such all stored data will be lost when the container is brought down. This could be changed by adding a volume mapping to the docker-compose file. 
* A few of the many things I would add to this project before every deploying to production:
  - Many more unit, integration, and system tests (ran out of time to add more)
  - Better documentation on public methods and fields
  - Proper logging (probably with serilog)
  - More thorough exception handling
  - Test validation to the build process
  - Secrets management so the database credentials aren't stored in a connection string in a settings file 
  

