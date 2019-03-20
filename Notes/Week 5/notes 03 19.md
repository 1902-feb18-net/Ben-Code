# 03/19/2019 Notes

## Service-oriented architecture
- Next level for separated concerns/loose coupling
- Split application into web services
    - Instead of linking our layers at build-time as DLLs, they will communicate at runtime over the web
    - Lots of websites have services that expose data to be used (API)
    - API (and in specific) Web API are synonyms for web services
    - Expose and comsume services
        - Expose is when we expose our app for other clients to be able to use
        - Consume is being able to use the services from our app
- Browser can skip MVC and communicate directly with the web service
- SOAP
    - Simple Object Access Protocol (former, no longer applies)
    - Used to be the standard for web services
    - SOAP communicates with XML over a variety of protocols
    - Rigorously define all the needed information about service in WSDL document
        - Web services description language
    - Not locked down to HTTP request -> response
    - Every SOAP message is in XML and has an envelope, an optional header, a required body, and a closing to the envelope

- REST
    - Will be used for project
- XML supports xml schema
    - Schema can be a namespace
    - Can be the structure of the database
    - XML must follow structure to be read and interpreted
    - Adds required structure to XML including datatypes
    - xmlns stands for xml name space
- Address is what URL are we going to find our service at?
- Contract: what are all operations/messages you support?
## Visual Studios stuff
- WCF: windows communication framework
    - Hosting SOAP services has not been ported to .NET Core
    - WCF binding is asking: what protocol will be use and what port?


## JavaScript