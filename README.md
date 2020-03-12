capitec-assessment-api

Requirements
 . .Net Core 3.1
 . Visual studio 2019
 . Language C#
 
 IF the above requirements are meet, this api can be test locally by cloning the project and run the project from visual studio or navigate to the directory with CapitecStock.Api.dll the run the command <dotnet CapitecStock.Api.dll>.
  
 Application Components
 
 1) Authentication
    . Used AuthO api as a delegated authentication model with client credintials flows, so that applications with client Id and secrete can be able to request for a token which will be used to authenticate on the api
 2) Logging/ application visibility
    . used Nlog to log to a file.
 
 3) Exception Handling
   . added a middleware to do global error handling
 4) Could have added some unit testing
 
 5) The application has three layers, the Api, service layer and a model layer. This is to allow for separation of concerns and programming to abstraction, so that we can easily swap the implementation incase I need to use another service or api to get the share prices then can use dependence injection.

I have deployed the Api on google cloudy ubuntu instance, using nginx on  as my server. the Api can be accessed via this IP address 35.184.57.11. navigating to http://35.184.57.11/ will display a swagger Ui page with the name of the endpoint to test the API.

I have included a postman collection capitec_asses.postman_collection.json on this repo for testing also
