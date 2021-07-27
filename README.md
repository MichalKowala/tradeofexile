# Table of Contents
1. [About Path of Exile and its trading system](#about-path-of-exile-and-its-trading-system)
2. [Developers trade API](#developers-trade-API)
3. [Trade of Exile and its features](#trade-of-exile-and-its-features)
4. [Tech choices and design solutions](#tech-choices-and-design-solutions)


## About path of exile and its trading system
What is Path Of Exile?  
https://en.wikipedia.org/wiki/Path_of_Exile

Trading in Path Of Exile (PoE)  
What’s unique for PoE among similar games of this genre is its trading system. 
Two major differences are:
1.	There is no ingame system allowing players to trade indirectly (for similar games that would be an auction house or mail system).
2.	There is no single unified currency (like gold).

This forces players to bargain and haggle. From a practical point of view, the only 2 ways of communication for trading are:
1.	Dedicated ingame trade channel
2.  Using dedicated trading API (which is what this app does)

## Developers trade API
How does it work? 
Each player has an access to their personal stash. Inside the stash players can put items they desire to sell with a price of a given currency.  

<p align="center">
  <img width="460" height="400" src="https://i.imgur.com/WoC1RSZ.png"><br>
</p>
After the price is set the item becomes ‘exposed’ to the API, allowing 3rd parties software (like Trade Of Exile) to register its price with a possibility of allowing interested players (buyers and sellers) to contact with each other.
This is how the endpoint looks like:  
https://www.pathofexile.com/api/public-stash-tabs <br>
Each batch starts with a “next_change_id” property, which can be passed as a parameter during next call, so you get another batch of items without ‘reading’ through the same item twice.  
Looping through these calls quickly enough will eventually give you a batch with “next-change_id” equal to ‘0’, meaning that there are no ‘new’ items to be ‘scanned’.

## Trade of Exile and its features
Trade of Exile constantly loops through the API and aggregates the prices for each item, so the end user can then know what is the average price of a given item they’re willing to buy or sell.
Besides that Trade Of Exile calculates what is the price change of a given item (if its increasing or decresing) and also how many occurances
of a given item were found so the user can have a better understanding of whether their item is more rare or common.  
<b>disclaimer: Most of the images below have "no data" placeholder where '7days change' value should be. This is because I had to create a new database for the purpose of this readme (I lost the old db during system reinstallation). <br>

<div align="center">
  <img src="https://i.imgur.com/g0E6DTJ.png"><br>
  Landing page <br><br>
  <img src="https://s6.gifyu.com/images/cycling.gif"><br>
  Items are sorted by categories which can be navigated via panel on the left <br><br>
  <img src="https://s6.gifyu.com/images/league_selection.gif"><br>
  Changing currently selected league will immediately update query results accordingly <br><br>
  <img src="https://s6.gifyu.com/images/load_more.gif"><br>
  Each category has a 'Load More' button to smoothen the browsing experience<br><br>
  <img src="https://i.imgur.com/5v1wLuR.png"><br>
  Currencies page allows you to compare exchange rates of diffrent currencies<br><br>
</div>

## Tech choices and design solutions  
The application is divided into 4 layers in a way characteristic for a clean architecture approach.
These layers are:
 
  <h3>Persistance Layer</h3>  
This is where I've put configuration files for database entitities. These files contain rules for relationships between database tables, which are used by Entity Framework in a Code First approach. Besides that it also contains Migrations history and BaseRepository class - a generic implementation of the Repository Pattern. To find more about repository pattern visit https://codewithshadman.com/repository-pattern-csharp/. My database choice for this app was MySql.
  
<h3>Models Layer  </h3>  
This is where I've decided to put some no-logic, not DTO classes - mostly entities used in the persistance layer and some classes used to help with mapping response recieved from game developer's API (mentioned in section 2) into ingame items.

<h3>Application Layer  </h3>  
This is where most of the logic happens. This is where game developer's API gets called and the response is then processed into ingame items which then are stored in a database.
Entitites are mapped into actual DTO's (Data Transfer Objects) using AutoMapper (https://automapper.org/). <br>
Query results (data) requested by users are in-memory cached using CacheProvider class to greatly improve the performance. <br>  
Queries and Commands are separated as recommended in the CQRS pattern, using MediatR package (https://github.com/jbogard/MediatR). <br>  
I've been trying to make it work so that items the from the API are harvested simultaneously while users are browsing the page using Hangfire (https://www.hangfire.io/).
There are still a lot of bugs with this approach, so currently the recommended way is to either have the app 'open' for users to browse or 'closed' so it can quickly feed for items. Leftovers after unsuccessful experiments can be found within 'Jobs' folder of this layer.
  
<h3>Presentation Layer (named just 'tradeofexile')  </h3>  
This layer is used as a UI used by user to communicate with the app. All data requested in controllers is passed to this layer from the Application Layer as a response to MediatR 'send' methods. This layer uses .NET Core MVC template with Razor syntax. CSS files stored in this layer were generated/compiled using Sass.<br><br>

Each layer has its own container storing implementations of interfaces used for DI (one can look at these as kind of 'installers' for each layer). These containers are then passed to the Startup class which happens to be within the Presentation layer.
