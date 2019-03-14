# Notes 03/07/2019

## EF stuff
- Database-first EF:
    - we define out model in SQL, and use tool to generate C# classes
- Code-first
    - define C# classes, use tool to generate SQL database

## Razor markup
- *Razor expressions:*
    - eg. @Model.Name, @(new Data{Name = <"A">}.Name)
    - the result of the C# expression is converted to string HTML-encoded and inserted onto the HTML page -> &al, A&gt
- *Razor blocks*
    - eg. @{var data = 5;}
    - runs code during view render
    - doesn't inherently insert anything to HTML
- *Razor control statements*
    - eg. @if @while @foreach @switch, etc.
    - HTML inside these will be coditionally/repetitively inserted
- *Razor directives*
    - eg. @model <type-name> makes the view strongly-typed
        - As opposed to weakly-typed
- *Razor comments*
    - comments @* this is a razor comment *@
- *Tag helpers*
    - HTML helpers to know
        - DisplayFor, DisplayNameFor, EditorFor, TextBoxFor, ActionLink, DropDowwnListFor
        - Can be tricky to use, have to use anonymous functions/methods
    - Tag helpers: a (anchor), asp-action, asp-controller, asp-route, asp-route-(paramname) -- gives value for route paramname --
    - Input: asp-for, asp-items
    - Select: asp-for
    - (span): asp-validation-for
    - form: asp-action
- **XSRF**: cross site request forgery
    - [my server] <--Sends request -- (POST form)[client]
    - [my server] --Sends response--> [client]
        - possible counterfeit
    - solved by using tokens, and forms will reject post requests without a token
    - the fileter [ValidateAntiForgeryToken] counters XSRF

- DataAnnotations:
    - attributes both EF and ASP.NET use for validation checks and other metadata
    - Required
    - MaxLength
    - Range
    - Regular Expression
    - DataType (zipcode, emailaddress, phone, password)
    - Display (Names = )
- **DI (Dependency injection)**
    - In StartupConfigureServices
    - services.AddSingleton
        - one instance of the service for app's lifetime
    - services
        - .AddScope
        - .AddDbContext
        - one instance for each HTTP request
    - .AddTransient
        - one instance per ask
    if  (Configuration["useDb"]) {
        ...AddDbContect;
        ...AddScoped<IRepo, DbRepo>() }
    else {...AddScoped<IRepo, DbRepo> }
- ModelState.AddModeError( , )
