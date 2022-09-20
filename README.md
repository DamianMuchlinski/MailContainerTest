### My comments
- removed IConfiguration from library - should be handled in application layer, to be resolved by DI container, 
    based on that, proper class should gets injected to service, 
	added TransferServiceConfiguration transferServiceConfiguration - as an example what could be used by DI (or purely by config.Bind)
- added Abstract folder to keep interface - readability (some abtsractions could be even propagated 
- extracted IContainerDataStore in order to respect that one by dedicated data stores implementation
- renamed Types to Models since it collides a bit with conventions, enums kept in dedicated folder
- moved all services to one subfolder - readability (to avoid confusion when logic resides)
- mark some models props with null! to mark which reference nullable types are nullable or not
- MailTransferService 
 - service should operate based on abstrations, DI should be smart enough to inject implementation based on configuration, SOLID - dep. inject prinicple
 - removed validation part from service ( in that place it is assumed models were validated before), 
	we follow SOLID - single resposiblity, validator could be invoked diffrent way (like middleware in api), thus I removed it from service,
         added dedicated class which is based on fluentvalidation 
		 added another one which could handle it in custom way
- added try catch withh Ilogger to add more light into app

- Tests
 - added test for service with mocked dependency interface by moq 

Future improvements -
- making signature to support working with tasks (helpful later in impl to make whole process async)
- more tests for dedicated services, also validator
- respect CQS - split data store logic to have either query or command

#### Process for transferring mail

- Lookup the container the mail is being transferred from.
- Check the containers are in a valid state for the transfer to take place.
- Reduce the container capacity on the source container and increase the destination container capacity by the same amount.

#### Restrictions

- A container can only hold one type of mail.


### The exercise brief

The exercise is to take the code in the solution and refactor it into a more suitable approach with the following things in mind:

- Testability
- Readability
- SOLID principles
- Architectural design of the code

You should not change the method signature of the MakeMailTransfer method.

You should add suitable tests into the MailContainerTest.Test project.

There are no additional constraints, use the packages and approach you feel appropriate, aim to spend no more than 2 hours. Please update the readme with specific comments on any areas that are unfinished and what you would cover given more time.

