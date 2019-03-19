# Ride A Bike

Project that modelates a solution to a bike store that only rent bikes.

## Getting Started

The project was made on C# using Microsoft Visual Studio Community 2017

### Installing

There is no installation since there is no application. Is only a project solution that should be opened with Visual Studio.

## Design

The project consist of a main class, Store, that handles the money income, the rents of the bikes, and the bikes availability.

The Bike class contain only their availability and an Id, not being used currently in the solution, but the idea of it is to allow make the project scalable
and enable a future function to return the bikes, and to do this an Id would be necessary.

The rent consist in a request of a Service Type, which could be Hour, Day or Week, and the quantity of that service.

An automatic discount over the price would be applied if the quantity of services requested is between the minimum and maximum quantity configured over the discount.
In this case it would be between 3 and 5, and the discount applied is a 30% of the total price.

If the number of services request exceeds the quantity of available bikes, the rental will not be done.

## Running the tests

The tests can be run from Visual Studio throw the Test Explorer or from the Menu:
```
Test -> Run -> All Tests
```

All tests were made over the main class Store, no test where made over the availability of the bikes due to it was out the scope and out of the idea of this project.

## Authors

* **Vaghi Agustin**
