# TitleSearch
Infotrack test project

Domin: https://sleepy-kowalevski-17f8ea.netlify.app/

Api: https://titlesearchapi20210214101148.azurewebsites.net/swagger/index.html

![WeChat Image_20210214174427](https://user-images.githubusercontent.com/51746409/107871390-cb796580-6eec-11eb-8300-2a891881699f.png)

# TitleSearch.Api:
 .Net Core 3.1 Console
 
 Dependencies: 
 
    Packages: swashbuckle.aspnetcore
    Projects: TitleSearch.Application
    
Api:
* Get: /api/SupportedEngines
* Get: /api/Search

For more detail, please go : https://titlesearchapi20210214101148.azurewebsites.net/swagger/index.html

Using API allows application to be compatible to different front-end technologies and integration.

# TitleSearch.Application:
.Net Core 3.1 Dll

  Dependencies: 
  
    Packages:   FluentValidation.AspNetCore
                FluentValidation.DependencyInjectionExtensions
                MediatR
                MediatR.Extensions.Microsoft.DependencyInjection
                Microsoft.Extensions.Logging.Abstractions
                
    Projects: TitleSearch.Engine

Using MediatR and CQRS Pattern, this module is just a series of request / response objects.
  * Separate reads (queries) from writes (commands)
  * Can maximise performance, scalability, and simplicity
  * Easy to add new features, just add a new query or command
  * Easy to maintain, changes only affect one command or query
  * Ability to attach additional behaviour before and / or after each request, e.g. logging, validation, caching, authorisation and so on. In this case, there are server-side validation for input parameters, costumed exception and exception handlers. 


# TitleSearch.Engine:
.Net Core 3.1 Dll

  Dependencies: 
  
  	NULL
  
  Use OOP and Factory pattern and deal with core task, html parsing. It is easy to add more searching engine.

# titlesearch.web:
ReactJS

  Dependencies: 
  
  	react-bootstrap, multiselect-react-dropdown
  
  Cover front-end validation, loading, exception report.
  
 # To build:
 Clone repository in IDV, like vs code. Open terminals.
 
 * For TitleSearch.Api: 
      
       cd titlesearch.Api
      
       dotnet run
     
 * For titlesearch.web: 
 
       cd titlesearch.web
      
       npm install

       npm start
