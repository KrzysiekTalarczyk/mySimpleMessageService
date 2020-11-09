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
