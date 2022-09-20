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
 - removed request validation part from service ( in that place it is assumed models were validated before), 
	we follow SOLID - single resposiblity, validator could be invoked diffrent way (like middleware in api), thus I removed it from service,
         added dedicated class which is based on fluentvalidation 
		 added another one which could handle it in custom way
- added try catch withh Ilogger to add more light into app

- Tests
 - added test for service with mocked dependency interface by moq 

Future improvements -
- making signature to support working with tasks (helpful later in impl to make whole process async)
- more tests for dedicated services, also validator (now added happy path)
- respect CQS - split data store logic to have either query or command
- more validations needed since it also is based on object retrieved from container (dynamic validation)

