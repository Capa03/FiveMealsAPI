
# Five Meals 
## _The easiest way to enjoy great food_


<img src="https://user-images.githubusercontent.com/79425111/166903045-81d3276f-b219-4925-91d7-3f8325a36eb6.png" alt="drawing" width="300"/>


  [![GitHub license](https://img.shields.io/github/license/Capa03/Five-Meals)](https://github.com/Capa03/Five-Meals/blob/main/LICENSE)


# Objetivo
Este projeto é o "cérebro" do ecosistema de aplicações FiveMeals contendo a lógica de negócio da aplicação [FiveMealsMobile](https://github.com/Capa03/Five-Meals) e também controlo para apresentação de dados da [FiveMealWebApp](https://github.com/Capa03/FiveMealsWeb).

Foi totalmente desenvolvido em [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) <img src="https://cdn.cdnlogo.com/logos/c/27/c.svg" alt="" width="30" height="30"/> , na framework [.NET CORE 6](https://dotnet.microsoft.com/en-us/) <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" alt="" width="30" height="30"/> e utiliza ainda as seguintes bibliotecas e tecnologias:


→ [AutoMapper](https://automapper.org) <img src="https://avatars.githubusercontent.com/u/890883?s=280&v=4" alt="" width="30" height="30"/>

→ [JSON Web Tokens](https://jwt.io) <img src="https://marketplace.squiz.net/__data/assets/image/0024/27285/json-web-token-thumbnail.png" alt="" width="30" height="30"/>

→ [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) <img src="https://static.gunnarpeipman.com/wp-content/uploads/2019/12/ef-core-featured.png" alt="" width="60" height="30"/>

→ [Firebase Admin](https://github.com/Firebase/firebase-admin-dotnet) <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/firebase/firebase-plain.svg" alt="" width="30" height="30"/>


## Lista de Tarefas:

TO DO | In Progress | Done | 
-----------|--------|------|
Arquitectura com diferentes camadas de abstração| |X
Utilização do AutoMapper | |x
Implementação de tokens JWT | |X
Base de dados com EFCore e SQLite | |X
Capacidade de notificar terminais de mudanças nos dados (FireBase)| |X
Publicação da API na Azure | |X


# API Definition
## Get token
### Get token request

```js
POST /User/Token
```
```json
{
  "email": "123@gmail.com",
  "password": "123456"
}
```

### Get token response 
```js
200 Ok
```
```json
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwNDA3ZjkxMy1hY2IxLTQ3YzQtODRkMC1hZDg4NjJiMmU1YzQiLCJqdGkiOiI4MjA4YWUyNi1jZDZlLTRkYzktYWUwOC1iZGU5NGI3MmFhZDQiLCJpYXQiOiIxLzE2LzIwMjMgMTI6MDU6NTkgQU0iLCJlbWFpbCI6IjEyM0BnbWFpbC5jb20iLCJuYW1lIjoiZGF2aWQiLCJleHAiOjE2NzM4MzExNTksImlzcyI6ImZpdmVtZWFscy5jb20iLCJhdWQiOiJmaXZlbWVhbHMuY29tIn0.jxJYwoZRUqdzMvTMSIaIwFMoTnq-gxf_m70JPXbOVMk",
    "expiration": "2023-01-16T01:05:59.6242409Z"
}
```

## Create user
### Create user request

```js
POST /User
```

```json
{ 
"username": "david", 
"password": "123456", 
"email": "123@gmail.com"
}
```

### Create user response

```js
201 Created
```


## Get table
### Get table request

```js
GET /Table/{id}
```

### Get table response 


```js
200 Ok
```
```json
{
"id": 1,
"restaurantId": 1
}
```

## Get restaurant
### Get restaurant request

```js
GET /Restaurant/{id}
```

### Get restaurant response 


```js
200 Ok
```
```json
{
"id": 1,
"name": "TestRestaurant"
}
```

## Get category with products
### Get category with products request

```js
GET /CategoryWithProducts/{restaurantId}
```

### Get category with products response
```js
200 Ok
```
```json
[
  {
    "id": 1,
    "restaurantId": 1,
    "categoryName": "Carne",
    "products": [
      {
        "id": 1,
        "name": "Bifana",
        "price": 3.5,
        "imgLink": "https://docs.google.com/uc?id=1_0zXE1wScxdn0DbOXYKE-CgpM7y1BtFI",
        "minTime": 0.5,
        "maxTime": 1,
        "restaurantId": 1,
        "categoryName": "Carne",
        "maxSteps": 5
      },
      {
        "id": 2,
        "name": "Burger",
        "price": 4.5,
        "imgLink": "https://docs.google.com/uc?id=1c-MFHH_qZew23MctTSD5awnbXInElt9S",
        "minTime": 10,
        "maxTime": 20,
        "restaurantId": 1,
        "categoryName": "Carne",
        "maxSteps": 8
      }
    ]
  },
  {
    "id": 2,
    "restaurantId": 1,
    "categoryName": "Peixe",
    "products": [
      ...
    ]
  },
  ...
]
```

## Get open order from tableId
### Get open order from tableId Request

```js
POST /Order
```

```json
{
  "tableId": 1
}
```

### Get open order from tableId Response
```json
{
  "id": 2,
  "tableId": 1,
  "created": "2023-02-06T17:45:51.790Z",
  "open": true
}
```


## Add a new product to order
### Add product to order Request

```js
POST /OrderProduct
```

```json
[
	{
		"orderId": 2,
		"productId": 3,
		"userEmail": "luis@gmail.com"
	},
	{
		"orderId": 2,
		"productId": 5,
		"userEmail": "david@gmail.com"
	},
...
]
```

### Add product to order Response

```js
201 Created
```

## Get Order Products

### Get Order Products Request

```js
GET /OrderProduct?orderId={orderId}
```

### Get Order Products Response

```js
200 Ok
```

```json
[
  {
    "orderProductID": 1,
    "orderId": 2,
    "userEmail": "luis@gmail.com",
    "orderedTime": "2023-02-06T17:38:50.192Z",
    "productID": 3,
    "productName": "Bitoque",
    "productPrice": 6.0,
    "productMinAverageTime": 15,
    "productMaxAverageTime": 0,
    "imgLink": "https://docs.google.com/uc?id=1LQGxf3P06aSjaF1CsdYDb0xPnA2jp5_p",
    "stepsMade": 0,
    "maxSteps": 10,
    "paid": false,
    "delivered": false
  },
  ...
]
```
## Update Order Products

### Update Order Products Request

```js
PATCH /OrderProduct
```

```json
[
	{
    "orderProductID": 7,
    "orderId": 3,
    "stepsMade": 0,
    "paid": true,
    "delivered":true
	},
	{
    "orderProductID": 8,
    "orderId": 3,
    "stepsMade": 0,
    "paid": true,
    "delivered":true
	}
]
```

### Update Order Products Response

```js
200 Ok
```


## Delete Order Products

### Delete Order Products Request

```js
DELETE /OrderProduct
```

```json
[
	2,
	5,
	7
]
```

### Get Order Products Response

```js
200 Ok
```
## Get in queue orderProducts

### Get in queue orderProducts Request

```js
GET /QueueProduct?restaurantId={restaurantId}
```

### Get in queue orderProducts Response

```js
200 Ok
```

```json
[
  {
    "orderProductID": 0,
    "orderId": 0,
    "userEmail": "string",
    "orderedTime": "2023-02-06T18:15:16.353Z",
    "productID": 0,
    "productName": "string",
    "productPrice": 0,
    "productMinAverageTime": 0,
    "productMaxAverageTime": 0,
    "imgLink": "string",
    "stepsMade": 0,
    "maxSteps": 0,
    "paid": true,
    "delivered": true
  }
]
```

## Get in progress orderProducts

### Get in progress orderProducts Request

```js
GET /OnProgressProduct?restaurantId={restaurantId}
```

### Get in progress orderProducts Response

```js
200 Ok
```

```json
[
  {
    "orderProductID": 0,
    "orderId": 0,
    "userEmail": "string",
    "orderedTime": "2023-02-06T18:15:16.353Z",
    "productID": 0,
    "productName": "string",
    "productPrice": 0,
    "productMinAverageTime": 0,
    "productMaxAverageTime": 0,
    "imgLink": "string",
    "stepsMade": 0,
    "maxSteps": 0,
    "paid": true,
    "delivered": true
  }
]
```

## Get for delivery orderProducts

### Get for delivery orderProducts Request

```js
GET /ForDeliveryProduct?restaurantId={restaurantId}
```

### Get for delivery orderProducts Response

```js
200 Ok
```

```json
[
  {
    "orderProductID": 0,
    "orderId": 0,
    "userEmail": "string",
    "orderedTime": "2023-02-06T18:15:16.353Z",
    "productID": 0,
    "productName": "string",
    "productPrice": 0,
    "productMinAverageTime": 0,
    "productMaxAverageTime": 0,
    "imgLink": "string",
    "stepsMade": 0,
    "maxSteps": 0,
    "paid": true,
    "delivered": true
  }
]
```
