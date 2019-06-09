The table of contents of the API documentation is as follows: 
1. [Authentication](#Authentication)
2. [Trucks](#Trucks)
3. [Dashboard](#Dashboard)



***Trucks***
---
1. [Get all Trucks](#Get-All-Trucks)
2. [Get Truck by ID](#Get-Truck-by-Id)

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
  
  
**Get All Trucks**
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
