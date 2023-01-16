
# Five Meals 
## _The easiest way to enjoy great food_


<img src="https://user-images.githubusercontent.com/79425111/166903045-81d3276f-b219-4925-91d7-3f8325a36eb6.png" alt="drawing" width="300"/>


  [![GitHub license](https://img.shields.io/github/license/Capa03/Five-Meals)](https://github.com/Capa03/Five-Meals/blob/main/LICENSE)



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


## Get user
### Get user request

```js
GET /User
```

### Get user response 
```js
200 Ok
```
```json
{ 
"username": "david", 
"password": "123456", 
"email": "123@gmail.com"
}
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
        "categoryName": "Carne"
      },
      {
        "id": 2,
        "name": "Burger",
        "price": 4.5,
        "imgLink": "https://docs.google.com/uc?id=1c-MFHH_qZew23MctTSD5awnbXInElt9S",
        "minTime": 10,
        "maxTime": 20,
        "restaurantId": 1,
        "categoryName": "Carne"
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

## Add a new product to order
### Add product to order Request

```js
POST /OrderProduct
```

```json
[
	{
		"tableId": 2,
		"productId": 3,
		"username": "luis"
	},
	{
		"tableId": 2,
		"productId": 5,
		"username": "david"
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
GET /OrderProduct/{tableId}?username={username}
```

### Get Order Products Response

```js
200 Ok
```

```json
[
	{
		"productId": 3,
		"username": "luis",
		"stepsDone": 3,
		"totalSteps": 5
	},
	{
		"productId": 5,
		"username": "david",
		"stepsDone": 2,
		"totalSteps": 8
	},
	...
]
```
