# 03/08/2019

## More MVC stuff
- ways to get data from the controller to the view
    1. strongly typed view the model
        - often will be a view model
        - view can only take one model, so if you need several, either that's a collection type of some kind or make a new view model that contains the several you need
    2. ViewData - a key-value pair dictionary
        - this obj is reachable via a property on Controller
        - can assign values in controller and access in the view (during the same HTTP request! It's cleared between requests)
        - e.g. ViewData["numOfmovies"] = viewModels.Count; 
               ViewData["currentTime"] = DateTime.Now;
               <h4>Num of movie: @ViewData["numOfMovies"]</h4>
    3. ViewBag - a different way to access ViewData "dynamic" type
        - set properties instead of using indexing syntax w/string
        - e.g. ViewBag.numOfmovies = viewModels.Count; 
        - allows you to add new properties after object is created
        - turns off compile-time type checking (does not check if it's access a valid property)
    4. TempData - a key-value pair dictionary
        - the values inside it survive across requests "magically" (by default - stored using cookies sent to the client which are then sent back to the server on subsequent requests)
        - But we can configure  other providers for TempData in StartUp
        - e.g. we can use this to incrementally build some model that needs many forms to be submitted,  not just one
        - With regular ["key"] access, the value you access gets deleted after the current request.  We can circumvent that with methods 
            - .Peek("key")
                - accesses value with marking for deletion
            - .Keep("key")
                - unmarks a value for deletion
        - ex: <h5>Counter (with TempData:) @TempData["Counter"]</h5>
            ```cshtml
            @{
                if (((int)TempData["Counter"]) <= 3>)
                {
                    TempData.Keep("Counter");
                }
            }
            if (TempData.ContainsKey("Counter"))
            {
                TempData["Counter"] = ((int)TempData["Counter"]) + 1;
            }
            else
            {
                TempData["Counter"] = 0;
            } ```
        - The other way we can keep data around to incrementally build something like an Order is with hidden form fields (corresponding to view model properties)
- attributes
    - [Route("ShowAllMovies")] - in contrast to global/convention based routing
        - e.g. [/{num:int?}]
            - this skips initial controller part with /
        - e.g. [Index/apples]
    - public ActionResult Index([FromQuery]) int num {}
        -pre method won't work, but if you include '?' query string for num,  it will work

## Client Server MVC
- [Client] -requests-> [Server(MVC)]
- [Client] <-response- [Server(MVC)]
- From Server
    - ASP.NET Core has a sequence of middleware plugged in in-order using .Use___ in Startup.Configure
- From Client
    - Other middleware ->
        - e.g. exceptio-handling, static-file serving, etc.
    - Routing middleware ->
    - MVC
    - Then the response goes back the other way
- From MVC
    - Filters are applied to controllers  or actions using attributes or globally in startup
        - Controller/action selection ->
        - Authorization filter ->
        - Resource filters ->
        - Exception filters ->
        - Model binding ->
        - Action Filters
            - Action filters (before)
            - Action method execution
            - Action tilers (after)

