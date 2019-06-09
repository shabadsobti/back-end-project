The table of contents of the API documentation is as follows: 
1. [Authentication](#Authentication)
2. [Trucks](#Trucks)
3. [Dashboard](#Dashboard)



***Trucks***
---
1. [Get all Trucks](#Get-All-Trucks)
2. [Get Truck by ID](#Get-Truck-by-ID)
3. [Create a Truck](#Create-a-Truck)
4. [Update a Truck](#Update-a-Truck)
5. [Delete a Truck](#Delete-a-Truck)

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
*  **URL Params**
    None
* **Data Params**
  None
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
  
  
**Create a Truck**
----
  Returns json/xml data about all the trucks.

* **URL**
  /api/trucks/
* **Method:**
  `POST`
*  **URL Params**
    None
* **Data Params**
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
*  **URL Params**
    None
* **Data Params**
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
*  **URL Params**
    Truck ID to delete
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
  
