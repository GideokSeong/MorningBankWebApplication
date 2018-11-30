# MorningBankWebApplication

-----------------------------
[//]: # (Image References)

[image1]: 8.PNG 
[image2]: 10.PNG 
[image3]: 11.PNG 
[image4]: 13.PNG 
[image5]: 14.PNG 
[image6]: 15.png
[image7]: 16.png
[image8]: 17.png
[image9]: 18.png

### 1. Major components ( DataLayer, BusinessLayer, and Cache )
This application uses MVC model which is based on C# in Jsp.net in visual studio 2017.
Overally, there are total three major components in this project such as business layer, data layer, and cache.
Through interacting each component, first I can directly access into database server which is Microsoft SQL server. 
I implemented business layer to access data layer which has a repository class. Business layer is used for calling repository class
by its function user wants to call, for example, in controller class, to interact between server and browser, HttpPost Action result 
function is used for each function. What it does is it defines business class to call the repository class which allows people to access the
database. In repository class, I can access to database directly using query. While I access the data, the information client retrieved on
web brower is stored in cache memory. There are two types of cache structure here such as HttpContextCacheAdapter and MemCachedAdapter. 
Cache is really efficient to retrieve data recently used. 

### 2. Functions
I implemented login function, loan apply, pay phone bill, transfer money from checking to saving, and from saving to checking function.
When user uses each function, its information is recorded in Transaction History. 
In terms of applying loan, the user applied loan can check the loan status and depending on user type it is possible to approve the loan
application. When people try to login, cookie and session function are applied to this application. First when user try to login on web browser, 
encrypted information is delivered to the server. If it is turned out to be valid such that user name and user password
are matched, then again it is decrypted. By using cookie function, this application can be more secure.
For paying phone bill, when user tries to pay the phone bill, the amount of money user used are taken out from the checking account.
Following images are showing how each function work as a visualization on web browser.
![alt text][image1]
![alt text][image2]
![alt text][image3]
![alt text][image4]
![alt text][image5]
![alt text][image6]
![alt text][image7]
![alt text][image8]
![alt text][image9]
