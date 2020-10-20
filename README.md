# IGSMarketPlace
Code Test API for Intelligent Growth Solutions

This is a VS2019 project implemented using .Net Core 3.1 for the API which performs the operations defined in the spec and tested with the Postman scripts. 

Tha datastore is a Sqlite database which is contained within the project in the IGS.db file. As implemented the file exists within the project and the database is seeded. To start completely from scratch delete the IGS.db file and (re)start the app. This will recreate and reseed the IGS.db file.
Note that running the Postman tests a second time without restarting the app will cause some Postman tests to fail as the next id is maintained within the DbContext and so the IDs used in the http calls become out of sync.
