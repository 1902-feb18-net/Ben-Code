using System;

namespace HelloEntityFramework
{
    class Program
    {
        //EF database-first approach steps:
        //
        //1.  Have startup project, and data access library project
        //2.  Reference data access from startup project
        //3.  Add NuGet packages to the startup proejct
        //      - Microsoft.EntityFrameworkCore.SqlServer
        //      - Microsoft.EntityFrameworkCore.Tools
        //      and to the data access project:
        //      - Microsoft.EntityFrameworkCore.SqlServer
        //4.  Open Pacckage Manager Console in VS
        //      (View -> Other Windows -> Package Manager Console)
        //5.  Run command:
        //  Scaffold-DbContext "<your-connection-string>" Microsoft.EntityFrameworkCore.SqlServer
        //                      -Project<name-of-data-project> -Force
        //6.  Delete the  OnConfiguring override in the DbContext to prevent 
        //          committing your connection string to git.
        //7.  Any time we change the database (add a new column, etc.) go to step 4
        
        //by default, the scaffolding will configure the models in OnModelCreating
        //  with the fluent API.  This is the right way to do it - strongest separation
        //  of concerns, more flexibility
        //if we scaffold with option "-DataAnnotations" (/"--data-annotations") we'll put the configuration on the
        //  Movie and Genre classes themselves with attributes

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
