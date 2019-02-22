# Revature Notes 02/22/2019

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
