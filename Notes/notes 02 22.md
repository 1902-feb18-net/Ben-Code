# Revature Notes 02/22/2019

## General notes
- [Rubular]https://rubular.com/
    - Good for learning regex syntax

## SOLID Principles
- *Single-responsibility principle*
    - A class/method should do just one thing
    - Everything a class/method does should be tightly related to each other
- *Open-closed principle*
    - Entities should be open for extension, closed for modification
    - Methods should keep old behavior and function while welcoming in new behavior
    - Try not to modify existing methods
- *Liskov Substitution principle*
    - Objects should be replaceable by instances of their subtypes without altering the correctness of the code
    - ex: `XmlSerializer : Serializer`
    - Freely write code so it could be replaced by a later subtype
    - Inherently involves upcasting
- *Interface Segregation principle*
    - Heavy interfaces should be split up into many light interfaces
    - More free to extend things later, instead of all or nothing with a heavy interface
- *Dependency Inversion principle*
    - Instead of high-level code depending on low-level code or vice-versa, both should depend on interfaces
    - When a class knows explicitly about the design and implementation of another class, it raises the risk that changes to one class will break the other class

## C# Principles
- is: same effect as the "==" operator
    - Instead of `x == null` we can use `x is null`
- Separation of concerns
    - Minimize tight coupling, or being highly dependent on another class
    - loose coupling is better
- Comment your code
    - Use XML comments for the public API
    - Inline comments to explain why we did something
- DRY: Don't repeat yourself
    - Put repetitive code into methods or classes to avoid repitition
- KISS: keep it simple stupid!
    - Making code that other coders can understand

## .NET Framework
- GAC (global assembly cache)
    - C:\Windows\assembly
    - Libraries are put in a global location
- Instead we now use a "strong name" so that they must have version numbers???
- A more modern idea of 3rd party dependencies is that they should be stored with the application
- Package manager NuGet replaced the idea of global installation, now are local and don't interfere with each other
    - Can also update new version from the internet periodically
    - `dotnet restore` automatically searches for new dependencies
    - Can call NuGet directly with `nuget restore` at least with some systems
- Errors
    - Fatal, the worst kind of error, aka critical
    - Error
    - Warn/warning
    - Info
    - Debug
    - Trace
