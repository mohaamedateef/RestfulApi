# Restful API
RESTful API for CRUD operations, developed with ASP.NET Core Web API.

# Function
Nine RESTful APIs for the web application.

API                          | Description              | URL
-----------------------------|--------------------------|--------------
GET  /api/Product            | Get all products         | GET [http://localhost:5255/api/Product](http://localhost:5255/api/Product)
GET /api/Product/id/1        | Get a product by ID      | GET [http://localhost:5255/api/Product/id/1](http://localhost:5255/api/Product/id/1)
POST /api/Product            | Add a new product        | POST [http://localhost:5255/api/Product](http://localhost:5255/api/Product)
PUT /api/Product/{id}        | Update a product         | PUT [http://localhost:5255/api/Product/id/1](http://localhost:5255/api/Product/id/1)
DELETE /api/Product/{id}     | Delete a product         | DELETE [http://localhost:5255/api/Product/id/1](http://localhost:5255/api/Product/id/1)
Get /api/Product/Category    | Get product, category    | GET [http://localhost:5255/api/Product/Category](http://localhost:5255/api/Product/Category)
Get /api/Product/name/{name} | Get product by Name      | GET [http://localhost:5255/api/Product/name/p](http://localhost:5255/api/Product/name/p)
Get /api/Category            | Get all categories       | GET [http://localhost:5255/api/Category](http://localhost:5255/api/Category)
Get /api/Category/{id}       | Get a category by ID     | GET [http://localhost:5255/api/Category/1](http://localhost:5255/api/Category/1)




# Setup Locally
```bash
git clone https://github.com/mohaamedateef/RestfulApi
```
Open the solution file with Microsoft Visual Studio, compile and run. Access http://localhost:5255/api/Product in web browser or PostMan, you should get the following json as response.
```json
[
  {
    "id": 1,
    "name": "IPhone",
    "price": 20000,
    "description": "New 2022/7",
    "categoryId": 1,
    "category": null
  },
  {
    "id": 2,
    "name": "Samsung",
    "price": 25000,
    "description": "New Samsung 2022/7",
    "categoryId": 1,
    "category": null
  },
  {
    "id": 3,
    "name": "Dell",
    "price": 35000,
    "description": "New Phone 2022/7",
    "categoryId": 2,
    "category": null
  }
]
```
