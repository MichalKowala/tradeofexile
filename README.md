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
  Items are sorted by categories which can be navigated through via panel on the left <br><br>
  <img src="https://s6.gifyu.com/images/league_selection.gif"><br>
  Changing currently selected league will immediately update query results accordingly <br><br>
  <img src="https://s6.gifyu.com/images/load_more.gif"><br>
  Each category has a 'Load More' button to smoothen the browsing experience<br><br>
  <img src="https://i.imgur.com/5v1wLuR.png"><br>
  Currencies page allows you to compare exchange rates of diffrent currencies<br><br>
</div>

## Tech choices and design solutions  
Coming soon
