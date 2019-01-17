# Back End Project

## Overview
Create an application to provide food truck information for the Charlotte area. Please find the requirements outlined below. These are just basic guidelines and extra features are always encouraged. Please use your best judgement for how to design and implement it.

## Requirements
### Language
Choose either Java Spring or .NET to build this project. Finish one of the below courses or any other courses you find relevant before attempting the project.
- [Java Spring Course](https://www.udemy.com/spring-hibernate-tutorial/) 
- [.NET Course](https://www.udemy.com/aspnet-core-20-e-commerce-web-site-based-on-microservices-and-docker/) 

### Basics 
Create a RESTful API to retrieve food truck information from a DB in JSON and XML formats instead of using the API.

<i>Framework</i>
- Use Hibernate as an ORM in conjunction with JPA for Java Spring
- Use Entity Framework ORM for .NET

<i>Create</i> 
- Add a food truck with the following specifications:
  - ID: non-empty unique alpha-numeric characters
  - Name: 1-50 characters
  - Price: a choice between `$`, `$$`, `$$$`, `$$$$`
  - Rating: from `1.0` to `5.0`
  - Open hours: an array of daily hours
  - Phone number: a string of digits
  - Categories: one or more cuisine types
  - Coordinates: latitude and longitude
  - Location: an object with street address, city, state, country and zipcode properties
  
<i>Read</i>
- Get all 50 food trucks 
- Get specific food truck 
- Get all food truck based on price, rating and category parameters

<i>Update</i> 
- Update the hours of a food truck 
- Update the address details of a food truck

<i>Delete</i>
- Delete a food truck from the database

<i>Database</i>
- Must use postgres as the data store

<i>Auditing</i>
- Create an audit/change log to store all the updates that have been made to the food trucks (updates, adds, deletes) 

<i>Favorites</i>
- Allow a user to add favorites and then retrieve those favorites 

<i>Deployment</i>
- Deploy it to one of the following platforms - AWS, Azure or GCP
- Setup security so that only your IP and Levvel office IPs (we can provide this list when you are ready) can access the website

## Things We Do Not Expect
- We do not expect to have multiple environments working, and pushing code through