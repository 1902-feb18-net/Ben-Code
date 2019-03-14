# 02/20/2019 Notes
- Cognizant will be our first client
- And we will have 5 MORE FUCKING WEEKS OF TRAINING, WTF

## Github information
- Origin/master is the most recent idea of what github has
    - The laptop is not constantly checking with github every moment, only when you pull/push
    - Or unless you're using Visual Studio
    - Called a "remote tracking branch"
- The "master" branch on Github can also be called the "remote branch"
- The "master" branch on your laptop is the "local branch"
- You can have branches that are local and don't go to Github
    - Once finished with them, you can merge them back into "master"
- Merging:
    - When one branch is just ahead of another and not deviating, that's called a "fast forward merge"
    - Merging doesn't delete features, it tries to grab information from one branch and bring it to another
    - Don't merge while there are uncommited changes
- Think of branches like nodes with reference pointers, when you push you add a node at the end. A branch is a point to a commit that includes immediate changes and all changes going backwards
- If you Git Push while on the "master" branch, it will update the branch pointer to include the most recent changes
- If you try to Git Push a branch that isn't on Github you'll get an error, but there are ways around it with a different types of push
- Conflicts can emerge when two different people push different things to "master"
- Git pull is the shortcut for git fetch and merge
    - Git fetch is the command that updates the remote tracking branches
    - Git merge automatically merges the "remote tracking branch" into the current branch
- The three pragmatic principles with Git:
    - Commit often
    - Pull often
    - Push often
- Merge resolution is something important to learn

## Class Stuff
- ": base() means if someone calls the zero-parameter constructor, it first calls the base class's zero parameter constructor (this is done by default)
- In C# we prefer thin constructor and setting properties after the fact
- If we still want validation logic, we can put that in property "sets" and maybe a .Validate method
- Giving fields or properties default values is really just for convenience; in reality,  those assignments are copied to every constructor
- When you make a new class inheriting from another, all fields, methods, and properties are inherited.  However, constructors are not inherited 
- Every non-abstract class has at least one constructor even if you don't write it.  You get a default constructor that does nothing by default.

## Testing
- Running the code in our IDE and plugging in different inputs to test for the expected output is called manual testing
- Automated is where we write the instructions for a test and the expected results, then we rerun lots of tests automatically
- This helps find and solve bugs quicker for subsequent development, and it also helps us design well in the first place; testable code is better designed code in general
- Unit testing is a particular kind of automated testing where we resolve to test the smallest pieces we can at a time
- The alternative would be integration testing where we're testing to make sure the integrated system works from start to finish
- For testing, we put our test methods inside an otherwise ordinary class
    - FactAttribute is an example of fa C# attribute
    - `[Fact]`
    - A second type of xUnit test is Theory
    - `[Theory]`
    - Theories accept sets of parameters to run the test against the code
    - Three general steps to a unit test
        1. Arrange
        2. Act
        3. Assert
            - Use Assert.True(variable) or Assert.False(variable);
    - We can the tested object "subject under test" (SUT)

## Collections
- Can make fixed-length lists of things called arrays
    - `int[] ints = new int[5]`
    - Can also use array initializer syntax: `int[] ints2 = new int[] { 1, 2, 3, 4, 5 }`
    - Can go through arrays with for loop, or foreach loop, but foreach loop cannot change the items in the array
    - Can have arrays of any type including other arrays
        - `int[][] twoDArray = new int [9][]`
        - This is called a jagged array, each row could have different lengths
    - Also can have "multidimensional arrays"
        - `int[,] multiDArray = new int[5,5]`
    - Rarely use arrays except for performance
- Lists are more common and include a wide range of helpful function
    - `var list = new List {5, 8, 1}`
    - Can index list just as if it were an array
    - Mostly stopped using ArrayLists when we got generics
- Generics
    - Safer, can't add the wrong data type
    - `var genericList = new List<int> { 1, 2, 3 }`
- Sets
    - We take our idea of sets from mathematics
    - A set has no concept of duplicates, it's either there or it isn't
    - A set also have no concept of order
    - `var set = new HashSet<string>();`
    - Checking membership in the set is fast
        - Set iteration is  alittle slower than list iteration
        - `var withoutDupes = new List<int>(new HashSet<int>(list))`
- Maps
    - The point of a dictionary is to store a key/valule relationship
    - ```csharp
            var dictionary = new Dictionary<string, string>();
            dictionary["classroom"] = "room where classses are held.";```
    - Also have initializer syntax
    - ```csharp
         var grades = new Dictionary<string, double>
        {
            ["Ben"] = 93
        };```
    - Helpful members: Keys, Values, ContainsKey, ContainsValue, TryGetValue
    - Dictionary objects let you use any type you want to index into it and any type to use for the value stored for that key
    - Sometimes a class/struct is a better choice for paired values

## C# Information
- String/Data type Equality
    - ```csharp
        string a = "asdf";
        string b = "asdf";
        Console.WriteLine(a == b); //returns true
        ```
    - Value types and reference types
        - Value type variables store their values directly
        - Reference type variables store a reference to their value
        - in C# many of our basic types are value types
            - int, double, bool, long, float
        - ```csharp
            int n1 = 5;
            int n2 = n1; //int is value type, so n2 is a copy of n1
            n1 = 6; //n2 stays at 5 because it's a value type
            ```
    - structs are copied entirely every time we pass it to a new method or assign it to a new variable
    - value types are deleted from memory as soon as the one variable that contains them passes out of scope
    - reference types we get a new copy of a reference but to the same underlying object
    - reference types need to be "garbage collected" because we don't know right away when the LAST variable pointing to it passed out of scope
    - objects made from calsses are always reference types
    - objects made from structs are always value types
        - all the build-in value types are "structs" in C#
    - Managed/Unmanaged code
        - in unmanaged code you have to manually write the code to delete reference from memory
        - in managed code,  there is garbage collection that runs periodically to search for objects that are unreachable by any running part of the code
        - our tradeoff is, the computer should work harder so the developer can solve real problems
    - Normally "==" compares value types by value and reference types by reference
        - `Console.WriteLine(new Dummy() == new Dummy()); //false... reference types`
    - For value types liek struct, they don't need to be the same object, only the same value
        - But we make an exception for strings because it's awkward to have to do string.Equals() for comparing strings
    - In C# all value types do derive ultimatlely from object so we can always upcast them to object variables
        - this is called "boxing" - the int is wrapped inside a reference type to give that value reference type semantics
        - ```csharp
            int i1 = 5;
            object o1 = i1; //implicit upcasting going on
            ```
    - We can also do the reverse with downcasting
        - This is called "unboxing"
        - ```csharp
            int i2 = (int)02; //extract that value from inside the object wrapper
        ```
        

