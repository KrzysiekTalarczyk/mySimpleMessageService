# mySimpleMessageService
is a simple tool that will allow to exchange messages between users in the system. 

Architecture.

Architecture
This app is base on the clean architecture + CQRS approach. 

I separate responsibility for the few layers:

	-Core 
	Domain Layer- the centermost part of the project. This layer is not dependent on any other parts, nothing in it has any knowledge of anything outside.
		There will be described as business logic, all domain classes, rules, etc. 
		Application Layer - This layer is dependent only on Domain. It responsible for binds the Domain Layer to the outer layers.
		This layer declares interfaces and other abstractions that stand for infrastructure, persistence, and presentation components.
		Also in this layer, I will define all necessary stuff to work with CQRS.
	-Infrastructure 
		Persistence- this will be a place to add any services, a framework from the outside application. 
		I this case I will add a new project for cover connection to the DB. I will use the Entity Framework ORM.
	-Presentation - this layer will be responsible for entering into the app. 
		In this case, it will be only one project mySimpleMessageService.API and 
		it will be a Web app that exposes REST full API.
		This API layer brings together all the Application layer components and injects them with the proper implementations  (using an IOC container).  		

The mySimpleMessageService is, for now, a very simple tool.  The real production system should have some additional features. 
-user authentication (the system should manage access to the data, using e.g JWT facilitates management of user message and contacts) 
- real-time notification, using e.g SingnalR allows user updates with the new messages sent to him. 
- currently, the message contains only the text content. It can be expanded to send some files, images, etc.  (this can impact the DB type or using third-part service ( store files).

The app is available on:
 http://kristal-001-site1.itempurl.com/swagger/index.html


use cases example:
Add new contact:

POST


http://kristal-001-site1.itempurl.com/api/Contacts


body:
{
"name": "new_Contact6"
}

Get Contacts:


http://kristal-001-site1.itempurl.com/api/Contacts 

You can filter, sort contacts by Name

http://kristal-001-site1.itempurl.com/api/Contacts?Filters=name@=cont&Sorts=-name

You can configure the pagination of results. 

http://kristal-001-site1.itempurl.com/api/Contacts?Page=1&PageSize=2

Send a few Messages 
post:

http://kristal-001-site1.itempurl.com/api/Messages

body:
{
  "senderId": 1,
  "messageText": "Message text",
  "recipientId": 2
}

Get Messages 
http://kristal-001-site1.itempurl.com/api/Messages?SenderId=1&ReceiverId=2

You can filter, sort the messages by body, or post date.

http://kristal-001-site1.itempurl.com/api/Messages?SenderId=1&ReceiverId=2&Filters=messageBody@=new&Sorts=-postDateTime

You can configure the pagination of results. 

http://kristal-001-site1.itempurl.com/api/Messages?SenderId=1&ReceiverId=2&Page=1&PageSize=2


 
