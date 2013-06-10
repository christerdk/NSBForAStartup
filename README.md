NSBForAStartup
==============
I created this project as a response to the many talks I've had with a lot of people about my positive experiences with NServiceBus. 

Although NServiceBus was created with advanced service oriented architecture in mind for big enterprises, there is a lot to take away for small projects too. I strongly recommend anyone starting up a new project to at least consider using both the architectural style and NServiceBus as enabling technology. 

The use of isolated services which communicate through via messages will mean, if implemented properly, that your rapidly growing and feature-pivoting startup will be able to respond fast without too much regression in your software. 
And early, most likely surprisingly early, your marketing efforts will need to be embedded into the software too: Follow up mails, marking customers preferred, implementing bonus policies (on 3rd sale, issue voucher), some statistics etc. are easily implemented through the use of Sagas, NServicesBus' process managing entity.

This POC project shows how the architectural style can be initiated in a simple way, supporting a MVP without too much hazzle, but also open for future expansion once those users start coming in :)

This POC projectproject includes one use case example, user creation. This is what happens once a user is created on [hostname]/user 

* A command is sent to the Accounts service.
* The Accounts service publishes a UserCreatedEvent.
* Two services are subscribing to the UserCreatedEvent:
  * MarketingService, which has the responsibility to send a follow up mail to the user. In this example this happens after 1 minute.
  * SomeOtherService, illustrating the force of having one service publishing an event, and two (and possibly more) services reacting on it.

What you need to run this project:

* Make sure you have MSMQ installed.
* Download and install NServiceBus (this will ensure that you have all prerequisites).
* Clone the project.
* Build - first might take up to a couple of minutes - the referenced nuget packages will be downloaded on first build.
* Go into solution properties and select multiple projecta startup: The NSBForAStartup and NSBForAStartup.Worker must be selected to start.
* Run :)

This is a project for demonstration purposes only and does not contain production ready code - many "de facto" best practices have actively been ignored, such as IoC, contracts, unit tests and what have you of other "best practices" that [gets in the way of writing code](https://medium.com/i-m-h-o/eef96ea6f4cb)... 
