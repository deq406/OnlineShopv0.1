# AuthController

Method       |      URL     |     Body    | Description |
------------ | -------------|-------------|-------------|
GET |https://localhost:44356/auth/authorize|JWT model|Authorize the user by JWT.
POST|https://localhost:44356/auth/authentificate|User model|Authentificate the user by creating JWT.
DELETE|https://localhost:44356/auth/delete|User model  |Deletes the user(password and login are required).
PUT|https://localhost:44356/auth/update|	2 users tuple|Update the user by changing property values. Item1 represents OldUser(old login and password are required), and Item2 representes NewUser(all changes are here).
POST|https://localhost:44356/auth/create|	User model|Create a single user. Login(unique, length: [2;20]) and password(length: [5;100]) are required.

# UserController
Method       |      URL     |     Body    | Description |
------------ | -------------|-------------|-------------|
POST|https://localhost:44356/api/user/addItems|JWTWithObject model, where Object is an array of "string" - items|Add items to the user's basket
GET|https://localhost:44356/api/user/goods|JWT model|Get all user's items in basket

# GoodsController

Method       |      URL     |     Body    | Description |
------------ | -------------|-------------|-------------|
GET|https://localhost:44356/api/Goods| |Get all items in the shop
POST|https://localhost:44356/api/Goods/{goods}|Item model|Creates a new item
DELETE|https://localhost:44356/api/Goods/{goods}|Item model|Deletes an item(requires only the name of the item)
PUT|https://localhost:44356/api/Goods/{goods}|Item model|Updates the price of the item(requires the name and new price of the item) 

# Controllers bodies

### JSON User model:
{

  "Login": "yourLogin",
  
  "Password": "yourPassword"
  
}

### JSON 2-users tuple:
{
"Item1": 
{
  
"Login": "oldLogin",

		"Password": "oldPassword"

},
  
"Item2": 
  {
  
"Login": "newLogin",

     "Password": "newPassword"
    }
  }

### JSON JWT model:
  {
  "Value": "yourJWTValue"
  }
  
### JSON JWTWithObject model:
{

  "JwtValue": "yourJWTValue",
  
  "Object": [ "Water", "Bread", "Something" ]
  
}

### JSON Item model:
{

"Name":"YourItemName",

"Price":10,

"Tag":"YourItemTag"

}
