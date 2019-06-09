The table of contents of the API documentation is as follows: 
1. [Authentication](#Authentication)
    1. [Register](#Register)
    2. [Login](#Login)
2. [Trucks](#Trucks)
    1. [Get all Trucks](#Get-All-Trucks)
    2. [Get Truck by ID](#Get-Truck-by-ID)
    3. [Search Trucks](#Search-Trucks)
    4. [Create a Truck](#Create-a-Truck)
    5. [Update a Truck](#Update-a-Truck)
    6. [Delete a Truck](#Delete-a-Truck)
3. [Dashboard](#Dashboard)
    1. [Get all Favorites](#Get-All-Favorites)
    2. [Add Favorite](#Add-Favorite)
    3. [Get your Trucks](#Get-your-Trucks)


***Authentication***
---
1. [Register](#Register)
2. [Login](#Login)


**Register**
----
  Register as a user on the application

* **URL**
  /api/accounts/{ID}
* **Method:**
  `POST`
*  **URL Params**
    None
* **Data Params**
    * **Request Body**
        ```json
       {
          "email": "shabadsobti@gmail.com",
          "password": "Shabad@97",
          "firstName": "Shabad",
          "lastName": "Sobti"
      }
         ```

* **Authentication Required**
  No
* **Success Response:**
     *  **Code: 200**
     *  **Content:**
          ```json
        Account created
          ```


* **Error Response:**
* **Code: 500 Internal Server Error**

* **Sample Call:**

  ```shell
    curl -X POST \
      http://levvel.azurewebsites.net/api/accounts \
      -H 'Content-Type: application/json' \
      -d '{
    	"email": "shabadsobti@gmail.com",
    	"password": "Shabad@97",
    	"firstName": "Shabad",
    	"lastName": "Sobti"
    }'
  ```
  
 
**Login**
----
  Login to get Auth Token

* **URL**
  /api/auth/login
* **Method:**
  `POST`
*  **URL Params**
    None
* **Data Params**
    * **Request Body**
        ```json
       {
          "userName": "shabadsobti@gmail.com",
          "password": "Shabad@97",
      }
         ```

* **Authentication Required**
  No
* **Success Response:**
     *  **Code: 200 OK**
     *  **Content:**
          ```json
        {
              "id": "b604f163-456e-4c51-b891-2cfa8f0a1d71",
              "auth_token": "{Your Token}",
              "expires_in": 7200
        }
          ```
* **Error Response:**
**Code: 500 Internal Server Error**

* **Sample Call:**

  ```shell
    curl -X POST \
      http://levvel.azurewebsites.net/api/auth/login \
      -H 'Content-Type: application/json' \
      -d '{
    	"userName": "shabadsobti96@gmail.com",
    	"password": "Shabad@97",
    }'
  ```
  
***Trucks***
---
1. [Get all Trucks](#Get-All-Trucks)
2. [Get Truck by ID](#Get-Truck-by-ID)
3. [Search Trucks](#Search-Trucks)
4. [Create a Truck](#Create-a-Truck)
5. [Update a Truck](#Update-a-Truck)
6. [Delete a Truck](#Delete-a-Truck)

**Get All Trucks**
----
  Returns json/xml data about all the trucks.

* **URL**
  /api/trucks
* **Method:**
  `GET`
*  **URL Params**
    None
* **Data Params**
  None
* **Success Response:**
  * **Code:** 200 
  *  **Content:**
      ```json
        [
        {
            "truckId": 1,
            "title": "Gyro Truck",
            "price": "$$",
            "rating": 2.3,
            "hours": "1;00",
            "phone": "4344664943",
            "coordinates": {
                "latitude": 123,
                "longitude": 34
            },
            "location": {
                "street": "101 N Tryon St",
                "city": "Charlotte",
                "state": "NC",
                "country": "USA",
                "zip": "22903"
            },
            "categories": [
                {
                    "categoryName": "Afghan"
                },
                {
                    "categoryName": "Indian"
                }
            ]
        },
        {
            "truckId": 2,
            "title": "Bagels Truck",
            "price": "$$$",
            "rating": 3.4,
            "hours": "1;00",
            "phone": "4344664943",
            "coordinates": {
                "latitude": 123,
                "longitude": 34
            },
            "location": {
                "street": "109, Asiad Village",
                "city": "Delhi",
                "state": "DE",
                "country": "India",
                "zip": "110049"
            },
            "categories": [
                {
                    "categoryName": "American"
                }
            ]
        }
        ]
      ```



* **Sample Call:**

  ```shell
    curl -X GET http://levvel.azurewebsites.net/api/trucks 
  ```
  
  
**Get Truck by ID**
----
  Returns json/xml data about all the trucks.

* **URL**
  /api/trucks/{ID}
* **Method:**
  `GET`

* **Data Params**
    *  **URL Params**
    
        | Parameter | Value   | Description |
        |-----------|---------|-------------|
        | ID        | Integer | Truck ID    |
* **Success Response:**
  * **Code:** 200 
  *  **Content:**
      ```json
        {
            "truckId": 1,
            "title": "Gyro Truck",
            "price": "$$",
            "rating": 2.3,
            "hours": "1;00",
            "phone": "4344664943",
            "coordinates": {
                "latitude": 123,
                "longitude": 34
            },
            "location": {
                "street": "101 N Tryon St",
                "city": "Charlotte",
                "state": "NC",
                "country": "USA",
                "zip": "22903"
            },
            "categories": [
                {
                    "categoryName": "Afghan"
                },
                {
                    "categoryName": "Indian"
                }
            ]
        }
      ```



* **Sample Call:**

  ```shell
    curl -X GET http://levvel.azurewebsites.net/api/trucks/1
  ```
  
**Search Trucks**
----
  Returns json/xml data about all the trucks matching the search criteria.

* **URL**
  /api/trucks/search
* **Method:**
  `GET`

* **Data Params**
    *  **Query string parameters**
    
        | Parameter | Value   | Description |
        |-----------|---------|-------------|
        | Price     | String   | The price category. ie. \$\$\$\$,\$\$\$,\$\$,\$    |
        | Rating    | Decimal | The minimum rating. ie. Find all trucks above this rating  |
        | Category | String  | The category of food the truck serves    |
* **Success Response:**
  * **Code:** 200 
  *  **Content:**
      ```json
        [
            {
            "truckId": 1,
            "title": "Gyro Truck",
            "price": "$$",
            "rating": 2.3,
            "hours": "1;00",
            "phone": "4344664943",
            "coordinates": {
                "latitude": 123,
                "longitude": 34
            },
            "location": {
                "street": "101 N Tryon St",
                "city": "Charlotte",
                "state": "NC",
                "country": "USA",
                "zip": "22903"
            },
            "categories": [
                {
                    "categoryName": "Afghan"
                },
                {
                    "categoryName": "Indian"
                }
                ]
            }
        ]
      ```



* **Sample Call:**

  ```shell
    curl -X GET \
  'http://levvel.azurewebsites.net/api/trucks/search?rating=2.0&price=$$&category=Indian' 
  ```
  
  


**Create a Truck**
----
  Create a Truck Resource.

* **URL**
  /api/trucks/
* **Method:**
  `POST`
* **Data Params**
    * **Request Body**
        ```json
        {
            "title": "Pizza Truck",
            "price": "$$$",
            "rating":3.4,
            "hours": "1;00",
            "phone": "4344664943",
            "coordinates": {
            	"latitude": 123.0,
            	"longitude": 34.0
            },
            "location":{
            	"street": "109, Asiad Village",
            	"city": "Delhi",
            	"state": "DE",
            	"country": "India",
            	"zip": "110049"
            },
            "categories":[
            	{
            	"categoryName": "American"
            	}
            	]
            
        }
         ```


* **Authentication Required**
  Yes
* **Success Response:**
  * **Code:** 200 
  *  **Content:**
      ```json
        {
            "truckId": 1,
            "title": "Gyro Truck",
            "price": "$$",
            "rating": 2.3,
            "hours": "1;00",
            "phone": "4344664943",
            "coordinates": {
                "latitude": 123,
                "longitude": 34
            },
            "location": {
                "street": "101 N Tryon St",
                "city": "Charlotte",
                "state": "NC",
                "country": "USA",
                "zip": "22903"
            },
            "categories": [
                {
                    "categoryName": "Afghan"
                },
                {
                    "categoryName": "Indian"
                }
            ]
        }
      ```



* **Sample Call:**

  ```shell
        curl -X POST \
      http://levvel.azurewebsites.net/api/trucks \
      -H 'Authorization: Bearer {Auth Token goes here}' \
      -H 'Content-Type: application/json' \
      -d '{
    "title": "Pizza Truck",
    "price": "$$$",
    "rating":3.4,
    "hours": "1;00",
    "phone": "4344664943",
    "coordinates": {
    	"latitude": 123.0,
    	"longitude": 34.0
    },
    "location":{
    	"street": "109, Asiad Village",
    	"city": "Delhi",
    	"state": "DE",
    	"country": "India",
    	"zip": "110049"
    },
    "categories":[
    	{
    	"categoryName": "American"
    	}
    	]
    }'
  ```
  
  
**Update a Truck**
----
  Update the hours and location of a given truck.

* **URL**
  /api/trucks/{ID}
* **Method:**
  `PUT`
* **Data Params**
    *  **URL Params**
    
        | Parameter | Value   | Description |
        |-----------|---------|-------------|
        | ID        | Integer | Truck ID    |
    * **Request Body**
        ```json
        {
        "hours": "13:00,15:00",
        "location":{
        	"street": "7th St NW",
        	"city": "Charlotte",
        	"state": "VA",
        	"country": "USA",
        	"zip": "28205"
        	}
        }
         ```


* **Authentication Required**
  Yes
* **Success Response:**
**Code: 200**

* **Error Response:**
**Code: 401 Unauthorized**
* **Sample Call:**

  ```shell
    curl -X PUT \
      http://levvel.azurewebsites.net/api/truck/1 \
      -H 'Authorization: Bearer {Your auth token goes here}' \
      -H 'Content-Type: application/json' \
      -d '{
    "hours": "13:00,15:00",
    "location":{
        "street": "7th St NW",
        "city": "Charlotte",
        "state": "VA",
        "country": "USA",
        "zip": "28205"
        }
    }'
  ```
  
  
**Delete a Truck**
----
  Deletes a Truck with the given ID.

* **URL**
  /api/trucks/{ID}
* **Method:**
  `DELETE`
*  **Data Params**
    *  **URL Params**
    
        | Parameter | Value   | Description |
        |-----------|---------|-------------|
        | ID        | Integer | ID of Truck to delete    |

* **Authentication Required**
  Yes
* **Success Response:**
**Code: 200**

* **Error Response:**
**Code: 401 Unauthorized**
* **Sample Call:**

  ```shell
    curl -X DELETE \
      http://levvel.azurewebsites.net/api/truck/1 \
      -H 'Authorization: Bearer {Your Auth Token goes here}' \
      -H 'Content-Type: application/json' 
  ```
  
  
***Dashboard***
---
1. [Get all Favorites](#Get-All-Favorites)
2. [Add Favorite](#Add-Favorite)
3. [Get your Trucks](#Get-your-Trucks)


**Get All Favorites**
----
  A list of all the trucks marked as favorite by the logged in user.
  
* **URL**
  /api/dashboard/favorites
* **Method:**
  `GET`
* **Data Params**
  None

* **Authentication Required**
  Yes
* **Success Response:**
     *  **Code: 200**
     *  **Content:**
          ```json
        [
            {
                "truckId": 1,
                "title": "Gyro Truck",
                "price": "$$",
                "rating": 2.3,
                "hours": "1;00",
                "phone": "4344664943",
                "coordinates": {
                    "latitude": 123,
                    "longitude": 34
                },
                "location": {
                    "street": "101 N Tryon St",
                    "city": "Charlotte",
                    "state": "NC",
                    "country": "USA",
                    "zip": "22903"
                },
                "categories": [
                    {
                        "categoryName": "Afghan"
                    },
                    {
                        "categoryName": "Indian"
                    }
                ]
            }
        ]
          ```


* **Error Response:**
    * **Code: 401 Unauthorized**

* **Sample Call:**

  ```shell
    curl -X GET \
      http://levvel.azurewebsites.net/api/dashboard/favorites \
      -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJzaGFiYWQuc29idGlAZ21haWwuY29tIiwianRpIjoiN2JhNzNjZGUtY2YwZS00YzQ0LWI5ZjItN2UxN2RhOGQxMTJhIiwiaWF0IjoxNTYwMTE2ODI4LCJyb2wiOiJhcGlfYWNjZXNzIiwiaWQiOiIzZTg4MmY4Yy02OTY2LTQzMTctYjcxZi1hOWFjMjNhZjkyYTIiLCJuYmYiOjE1NjAxMTY4MjcsImV4cCI6MTU2MDEyNDAyNywiaXNzIjoid2ViQXBpIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxLyJ9.bcJ3JfsB3iiH_JCNLHxNbiE44UvyqWXgWjxDd5IVFWE' 
  ```
  
 
**Add Favorite**
----
  Mark a Truck as a Favorite

* **URL**
  /api/dashboard/favorites
* **Method:**
  `POST`
* **Data Params**
    * **Request Body**
        ```json
       {
          "truckId": 1
      }
         ```

* **Authentication Required**
  Yes
* **Success Response:**
     *  **Code: 200 OK**

* **Error Response:**
**Code: 401 Unauthorized**

* **Sample Call:**

  ```shell
    curl -X POST \
      http://levvel.azurewebsites.net/api/dashboard/favorites \
      -H 'Authorization: Bearer {Your Auth token goes here}' \
      -H 'Content-Type: application/json' \
      -d '{
    	"truckId" : 1
    }'
  ```
  
  
**Get your Trucks**
----
  Get all trucks created by the logged in user

* **URL**
  /api/dashboard/trucks
* **Method:**
  `GET`
* **Data Params**
  None

* **Authentication Required**
  Yes
* **Success Response:**
     *  **Code: 200 OK**
     *  **Content:**
          ```json
        [
            {
                "truckId": 1,
                "title": "Gyro Truck",
                "price": "$$",
                "rating": 2.3,
                "hours": "1;00",
                "phone": "4344664943",
                "coordinates": {
                    "latitude": 123,
                    "longitude": 34
                },
                "location": {
                    "street": "101 N Tryon St",
                    "city": "Charlotte",
                    "state": "NC",
                    "country": "USA",
                    "zip": "22903"
                },
                "categories": [
                    {
                        "categoryName": "Afghan"
                    },
                    {
                        "categoryName": "Indian"
                    }
                ]
            },
            {
                "truckId": 2,
                "title": "Bagels Truck",
                "price": "$$$",
                "rating": 3.4,
                "hours": "1;00",
                "phone": "4344664943",
                "coordinates": {
                    "latitude": 123,
                    "longitude": 34
                },
                "location": {
                    "street": "109, Asiad Village",
                    "city": "Delhi",
                    "state": "DE",
                    "country": "India",
                    "zip": "110049"
                },
                "categories": [
                    {
                        "categoryName": "American"
                    }
                ]
            },
            {
                "truckId": 3,
                "title": "Pizza Truck",
                "price": "$$$",
                "rating": 3.4,
                "hours": "1;00",
                "phone": "4344664943",
                "coordinates": {
                    "latitude": 123,
                    "longitude": 34
                },
                "location": {
                    "street": "109, Asiad Village",
                    "city": "Delhi",
                    "state": "DE",
                    "country": "India",
                    "zip": "110049"
                },
                "categories": [
                    {
                        "categoryName": "American"
                    }
                ]
            }
        ]
          ```
* **Error Response:**
**Code: 401 Unauthorized**

* **Sample Call:**

  ```shell
    curl -X GET \
  http://levvel.azurewebsites.net/api/dashboard/trucks \
  -H 'Authorization: Bearer {Your Auth Token goes here}'
  ```
  
