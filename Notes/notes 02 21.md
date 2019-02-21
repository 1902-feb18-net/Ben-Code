# 02/21/2019

## LINQ

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