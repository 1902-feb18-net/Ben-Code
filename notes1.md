# Revature 02/18/19 Notes:
Gitbash is a way to emulate some of Linux’s functions, but isn’t necessarily the best for beginners.  Consider using tutorials.  Class will be using Git Bash quite a bit.

## Contact Information
- Your trainer: Nick Escalona: nick.escalona@revature.com
- Recruitment: contact your recruiter
- Housing: housing@revature.com - supplies, check-in, check-out
- Human resource: hr@revature.com

## Enterprise Project Development Overview - .NET
- Agile/Scrum
- Enterprise project development
- Build and deployment
- Microservices
- Continous integration
- Test automation and refactoring

## Soft Skills and Career Coaching
- Working as a team
- Corporate liason program
- Presentation skills
- Best practices for meeting
- Do's and Don't's of projects
- Interviewing skills

## Program Structure
- Build foundation
- Software architecture
- Adopt DevOps
- Advanced Concepts
- Work on a live application
- Monitor progress

## Capability of Revature Software Engineers
- Equivalent to 12 months of experience in core skill
- Industry leading certification (90% certified)
- Enterprise based large project experience (3 Projects)
- Softskills and Agile work experience
- Enterprise project readiness from day 1

## Gitbash commands: 
 - cd: change directory, brings you to a target directly (ex: cd c/users/mages)
 - cd ..: goes to previous folder
 - mkdir: make directory, creates an empty directory in current folder (ex: mkdir revature)
 - ls: list, shows all elements in current folder
 - ls –la: list that shows all hidden elements as well as normal elements
 - git clone: creates a local copy of the repository that exists on github (ex: git clone https://github.com/1902-feb18-net/training-code.git)
 - git status: what is the current status
 - git pull: pulls latest things from the git repository onto the machine

 ## Dotnet commands
 - dotnet run: runs the code
 - dotnet run --project projectName: runs the project from the parent folder
 - dotnet new: generates a new .net project from a variety of templates, e.g. "console" (ex: dotnet new console)
 - Steps to build and run code:
    - Dotnet restore: download/update all code dependencies
    - Dotnet build: compiles your code
    - Dotnet run runs code (in the DLL)



## Training weeks:
 - Week 1 – C#, .NET, OOP, testing
 - Week 2 – SQL (SQL Server), Entity Framework
 - Week 3 – ASP.NET MVC, HTML, CSS; Project 0 due in middle of week
 - Week 4 – DevOps, CI/CD, Azure, Docker; Project 1
 - Week 5 – Service-oriented architecture, REST, JS
 - Week 6 – TypeScript, Angular
 - Weeks 7 to 9 – Projects 2 and 3, panel
 - Week 10 – Specialized training in another framework
 - Weekly Schedule:
    - Monday – Assessment quiz, timed coding, mock interviews, QC audit?
    - Tuesday to Thursday – training;
    - Friday – Training + project work time

## When using .NET
- Check version: dotnet –version
- Use dotnet new console
- Use dotnet restore to download all 3rd party dependencies
- Use dotnet build to build everything needed
- Dotnet run runs the code
 
## When pushing new file to repository
- git add . (adds everything inside current directory)
- git commit -m "This is a message" (commits changes)
- git push (pushes to github)

## C# Notes
- Console.WriteLine("Something"): Starts a new line and prints to console.
- Console.Write("Something"): Prints to console, but doesn't start a new line.
- Static keyword: this function is not tied to any particular instance of current class.  What does this mean?  Nick says he'll talk about it tomorrow.
- var keyword can take the place of a specific data type based on initial value (ex: var data = "asdf", var is a string data type).
- Solution (set of related projects)
- Interpolated string: a string with a value inserted (ex: $"Hello, {name}. It's a pleasure to meet you!", where name is a string). $ is required before the opening quotation, and {} encloses the variable.

## C# Asssembly Notes
- Project/assembly (.dll or dynamic linked library, or .exe)
    - file (Program.cs)
        - namespace (System) -> using System;
            - class (Console)
                - Methods (WriteLine)
                - Properties
                - Fields

## .NET framework
 - Includes a virtual execution system called the common language runtime (CLR) and a unified set of class libraries
 - The CLR is the Microsoft implementation of the common language infrastructure (CLI), an international standard that is the basis for creating execution and development environments in which languages and libraries work together seamlessly
 - Source code written in C# is compiled into an intermediate language (IL) that conforms to the CLI specification.  They are stored on a disk in an executable file called an assembly, usully .exe (application) or .dll (library).
