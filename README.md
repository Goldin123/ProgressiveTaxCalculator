# Progressive Tax Calculator

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#process">Process</a></li>
    <li><a href="#database">Database Entities</a></li>
    <li><a href="#api">Api Calls</a></li>
    <li><a href="#website">Website</a></li>
    <li><a href="#FAQ">FAQ</a></li>

  </ol>
</details>

## About The Project
This a ASP.NET 7 application that calculates annual tax given a postal code and a gross amount. The appliacation consists of a website user interface, an api as back-end and uses an in-memory database for data storage. The application is separed using modules which can be easily extended for maintance and a clean coding parten. All activies within the application are logged and can be view on the ouput window.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

* The application uses ASP.NET 7 overall.
* The website is an ASP.NET 7 MVC with razor pages.
* The API is an ASP.NET 7 Web Api.
* ORM used is Entity Framework.
* Unit Test are done using NUint.
* The Data store is EntityFrameworkCore in-memory.

 ## Getting Started

 * This application uses ASP.Net 7, make sure the correct SDK is installed.
 * Be sure to have the latest visual studio installed.
 * Check the output window for any logs that application does.

 <p align="right">(<a href="#readme-top">back to top</a>)</p>

 ### Prerequisites

  <p align="right">(<a href="#readme-top">back to top</a>)</p>

  * Make sure the correct SDK is installed.
  * Make sure the Website and Api are both set as start-up projects
  * The seeding of the database happaens automatically. 

 ### Installation

  <p align="right">(<a href="#readme-top">back to top</a>)</p>

  1. Clone the repository.
  2. Check if the correct framework SDK is installed.
  3. Re-build the application.
  4. On start-up, 2 browser windows will open, make sure you are of website window.
  5. The Api uses a swagger UI, feel free to play around the different endpoints. 

 ## Process

 ![image](https://github.com/Goldin123/ProgressiveTaxCalculator/assets/17449653/d50075da-4cd4-409a-a6fd-0573187f05d6)

* On page load, the database is intialised and automatically seeded with sample data.
* The process begins with a user selecting a postal code.
* The user then enters a gross amount.
* The website will do validations on those user inputs, should things go wrong, the website displays the error message.
* The website will then generate and sends an api request.
* The api receives the request and do extra validations, shoild things go wrong an error response is generated and sent back to the website to display the message.
* The api then will choose which calculator module to use based on pre-set conditions.
* The calculator modules have their own calculate tax functionality that calculates tax in varous ways.
* Once the tax is calculated, the results are sent back via an api response and displayed on the website.

  <p align="right">(<a href="#readme-top">back to top</a>)</p>

 ## Database

 ![image](https://github.com/Goldin123/ProgressiveTaxCalculator/assets/17449653/2eaf7044-82cf-4748-9fe5-8c3b53a94022)

The system uses in total 4 core tables but can be expanded to cater for more processes.
* Tax Type : Progressive, Flat Value, Flat Rate, etc.
* Tax Term : Annual, Monthly, Bi-weekly or Weekly.
* Postal Codes : These are postal code linked to specific tax types.
* Tax Table : This store the core data needed to perfom tax calculations.
* Tax Calculated : This stores the history of all previiolsy calculated tax.

  <p align="right">(<a href="#readme-top">back to top</a>)</p>

 ## Api
![image](https://github.com/Goldin123/ProgressiveTaxCalculator/assets/17449653/97c84e1a-714d-4f48-8848-d053e99cb3c9)

The API currently has 2 endpoints
* GetPostalCode - This returns a collection of postal code used to populate the dropdown inputbox.
* CalculateIncomeTax - This is used to do the actual tax calculations.
   
  <p align="right">(<a href="#readme-top">back to top</a>)</p>

 ## Website

 ![image](https://github.com/Goldin123/ProgressiveTaxCalculator/assets/17449653/13c1991e-1a3d-4f39-91aa-c4dac40d75ce)

 The application website has the above user interface. Input are valideted on the page first before they can be submitted for processing.

  <p align="right">(<a href="#readme-top">back to top</a>)</p>

 ## FAQ

* Where are the unit tests? A: The project currenly lacks unit tests, but the idea is to use NUint, of which the structure is there.
* What about security? A: The idea was to use JWT tokens for api auth.
  
  <p align="right">(<a href="#readme-top">back to top</a>)</p>
 
