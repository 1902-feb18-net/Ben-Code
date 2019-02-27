SELECT * FROM SalesLT.Customer;

-- commenting in SQL with '--'

-- in a SQL server... you have many databases.
-- within each database, we have many "schemas"
-- a schema is a namespace/scope for datatbase object

-- in AdventureWorksLT database, we have schema SalesLT
-- inside schemas, we have many DB objects, including tables

USE AdventureWorksLT;
-- this WOULD switch databases (from master)
-- but Azure SQL DB doesn't support it yet

-- whitespace doesn't matter
-- semicolons aren't necessary
-- case doesn't matter

sElEcT			*
from

sAlESLT.Customer
-- select what you want to run before hitting F5 or the execute button

-- SQL's string comaprison by default is also case-insensitive
--	but really that depends on the collation" i.e. the settings
--	for datetime format, number format, etc.

-- the SELECT statement ...
-- doesn't even access the DB
SELECT 1;
SELECT CURRENT_TIMESTAMP;

-- we get all columns and all rows from a table with SELECT * FROM
SELECT *
FROM SalesLT.Customer;

-- we can select exactly which columns we want by replacing the *
SELECT Title, FirstName, MiddleName, LastName 
FROM SalesLT.Customer;

-- we can do "aliases" with AS
-- the standard SQL way to spell an identifier with spaces is ""
-- the SQL server way is []
SELECT FirstName AS [First Name], LastName AS "Last Name"
FROM SalesLT.Customer;

-- we can compute new values from the column's values
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM SalesLT.Customer;

-- we can process the returned rows with DISTINCT
-- any rows of the result set that have all the same column values
--	will be de-duplicated

-- get all first names that customers have
SELECT DISTINCT FirstName
FROM SalesLT.Customer;

-- we can filter rows on conditions as well with the WHERE clause
SELECT *
FROM SalesLT.Customer
WHERE FirstName = 'Alice';

SELECT *
FROM SalesLT.Customer
WHERE FirstName = 'Alice' AND LastName = 'Steiner';
-- so we have boolean operators AND, OR, NOT, and !-
--	(or... traditional SQL <>)

SELECT *
FROM SalesLT.Customer
WHERE FirstName = 'Alice' AND LastName != 'Steiner';

-- we have ordered comaprison of numbers, dates, times, and strings
-- strings are ordered by "dictionary.order" "lexicographic order"
-- but this is affected by collation
-- operators <, <=, >, >=

-- all customers whose first name starts with C
SELECT *
FROM SalesLT.Customer
WHERE FirstName >= 'c' AND FirstName < 'd';

-- we can sort the results (they are in undefined order by default)
-- ORDER BY clause accomplishes this

-- all customers first name starting witih C
-- ordered by first name with last name as tiebreaker
SELECT *
FROM SalesLT.Customer
WHERE FirstName >= 'c' AND FirstName < 'd'
ORDER BY FirstName, LastName DESC, CustomerID;
-- ordering is "ascending" (ASC) by default but can be descending (DESC)
-- So in this example, first name will be abc, last name will be cba as tiebreaker

-- we can do regex-lite pattern matching on strings with LIKE operator

-- all customers with first name starting with c, then a vowel
SELECT *
FROM SalesLT.Customer
WHERE FirstName LIKE 'C[aeiou]%'
-- [abc] for one character, either a, b, or c
-- % for any number of characters
-- _ for one of any character

