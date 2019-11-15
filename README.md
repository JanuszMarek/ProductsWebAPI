# ProductsWebAPI
> WebAPI to manage products in database. Application created for recruitment job. 

## Table of contents
* [Tech Stack](#tech-stack)
* [Features](#features)
* [To do](#to-do)
* [Startup](#startup)
* [Status](#status)
* [Contact](#contact)

## Tech Stack
* ASP.NET Core - version 2.2
* EntityFramework - version 6.3.0
* AutoMapper - version 9.0.0
* AutoMapper.DependecyInjection - version 7.0.0

## Features
List of ready features:
* HTTP GET api/product returns all available products and status 200 OK
* HTTP GET api/product/{id} return product with parameter id and status 200 OK
* HTTP POST api/product create new product and return his id and status 200 OK
* HTTP PUT api/product/{id} update existed product and return status 204 NoContent
* HTTP DELETE api/product/{id} delete product and return status 204 NoContent
* Global exception handler
* ValidationActionFilters to validate input data

## To do
List of features to do in next release:
* logging using Nlog
* pagination, sorting, filtration
* HATEOAS

## Startup
If you already have existing database you can change connection string in ProductsWebAPI/appsettings.json
```
{
  ...
  "ConnectionString": "Server=(localdb)\\MSSQLLocalDB;Database=ProductsWebAPI;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```
or you can create new one be write down command in <i>Package Manager Console</i>
```
update-database
```
After application started (e.g by create IIS website) you can use application like Postman to request API
```
http://{binding}/api/product 
```
Product entity contain fields
```
Guid Id

string Name

decimal Price
```

## Status
Project is _in progres_.

## Contact
Created by [Janusz Marek](https://www.linkedin.com/in/janusz-marek/) - feel free to contact me!
