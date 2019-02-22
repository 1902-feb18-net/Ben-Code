# 02/21/2019

## LINQ
- Consider practicing this later on instead of conventional code for practice

## .NET
- .NET is a platform for many languages
    - C# being the most popular
    - F# (sort of a functional version of C#)
    - VB.NET (visual basic platform)
    - Python
    - Java
    - R
    - Typescript/JS
- Provides limited interoperability between languages
    - Provides similar infrastructure for different languages to work with others
    - cross-platform independent
    - Architecture independent
    - Universal exception handling
    - Universal managed environments (garbage collecting)
- Provides interface for anyone to make .NET runtime
- **.NET Common language infrastructure (CLI)**
- **.NET Command Line Interface (CLI)**
    - a standard for what a runtime has to have to be good
    - **virtual execution system (VES)**
        - VES is equivalent to Java JVM
        - Inside the VES we have the **JIT** (Just In Time) compiler
            - Converts VES to native instructions executed directly by CPU
    - "dotnet" command that we use
    - **Common Type System (CTS)**
        - Arrays belong here
    - **Base Class Library (BCL)**
        - Things like lists
- First step to build:
    - .NET code in .cs file
        - C# compiler using dotnet build, masbuild, csc
        - .NET code is compiled by c# compiler using "common intermediate language"
            - **IL** (intermediate language), **CIL** (common intermediate language"), **MSIL**
            (microsoft intermediate language), bytecode, assembly
            - .dll, .exe
            - IL is a instruction set for the VES
- Second step to run: Inside VES(JIT compiler -> (Native Instructions) -> (CPU runs))
- Implementations...
    - .NET Framework
        - Windows only
        - The most common .NET out there (v4.7)
        - msbuild back then instead of dotnet
    - .NET core
        - Provided by Microsoft, but cross platform
        - Write once, run anywhere
        - Up to v2.2
    - Mono
        - Came before .NET framework, was a port for Mac/Linux
        - Somewhat obsolete since .NET Core came into the picture

- ADO.NET: Data access
- ASP.net: Web development
- WPF: Windows style popups and form control, wouldn't work with Mono
- WCF: Web service
- .NET Standard
    - A common definition for what both .NET Framework and .NET Core should have and do
    - The common subset that both .NET Framework and .NET Core agree with
    - VES implementation is called **Common Language Runtime (CLR)**

## OOP Principles (WHAT ARE THEY, AND WHAT IS AN EXAMPLE OF EACH)
- Abstraction
    - Separation between needed functionality and implementation details
    - In a way the other 3 principles are aspects of abstraction
    - Example:
        - Properties
        - Methods
        - Common type system
- Encapsulation
    - Restricting access to information within objects
    - Packaging related things together and treating them as a unit
    - Examples:
        - Objects
        - Access modifiers
- Polymorphism
    - The possibility of many implementations behind a common contract
    - Method overriding
        - Can change between which version of a function to be called, whether it be the most recent or the older (virtual) version
    - Method overloading
        - The same function can accept different numbers or types of parameters
    - Ability to treat a derived class object as thought it were a base class object
- Inheritance
    - The ability for a class to take and extend behavior from another class
    - Example
        - Have MemoryList take all that a List can but also do more
    - Inheritance vs Compositioin
        - Inheritance "is a"
        - **Composition** "has a"
            - Takes fields/properties
            - Can use non-virtual fields or methods

## Seralization and Asynchronous programming
- Steps for Async
    - filler filler filler
- When we make code async, the method has to have the "async" modifier
- The methods needs to return a Task (for void-return) or a `Task<Something>` if we wanted to return something
- the method should say Async at the end of its name (for self-documenting purposes)
- When we call Async methods in our own methods, we need to "await" the tasks they give us
- Can use "await" keyword
- When the method executing reaches an await statment, it allows other code to run in the meantime (outside the class/method)
- **Async function must have an "await," "wait," or ".Result" method**
- Main can't be async so you have to use `persons = DeserializeSMLFromFileAsync(filename).Result` with an emphasis  on the `.Result`
- Async code requires async tests
- Can serialize in JSON format instead of XML
    - DataContractSerializer (build-in to .NET)
    - JSON.NET (aka  Newtonsoft JSON) (third-party)
        - persons = ```csharp
        JsonConvert.DeserializeObject<List<Person>>(File.ReadAllTextAsync(jsonFile).Result)
        string newData = JsonConvert.SerializeObject(persons);
        File.WriteAllTextAsync(jsonFile, newData)
        ```
- `[XmlIgnore]` causes XML (or JSON.NET if you change XML to JSON) to ignore the data and not include it
        
## PROJECT 0
- Console application to manage a store and inventory
- Keep track of customers
- Keep track of stores/locations
- Keep track of orders and order history
- statistics on orders
    - What day did the most sales come in on?
    - Try using LINQ
- Inventory
- Complexity to things you can buy
    - a non-simple relationship between inventory and product
    - ex: order pizza at pizza store, maybe have dough/cheese/etc as well as just "pizza"
    - More complex things should be there, and you should be able to order more than one thing per order
- Business rules
    - ex: no more than 10 pizzas per order allowed
- Menu-based interface
- Have save/load from file options
- Have testing project for library
- 3 projects: Library, Console, Tests for library