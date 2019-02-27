-- in SSM, like in VS we have CTRL+KC for comment, CTRL+KU for uncomment

-- data tyeps
--	numerics
--		- TINYINT (1 byte) (byte/char)
--		- SMALLINT (2 byte) (short)
--		- INT (4 bytes) (we use this one when we have no special need)
--		- BIGINT (8 bytes) (long)
--	floating-point
--		- FLOAT
--		- REAL
--		- DECIMAL/NUMERIC(n, p) (highest precision + custom precision -- we use this one)
--			DECIMAL (4, 3) means 4 digits with 3 of them after the decimal point (3.333)
--	currency
--		- MONEY (minor rounding, uses current collation syntax, ex: $ in US collation)
--	string
--		- CHAR/CHARACTER(n)
--			fixed-length character with size N
--			uses one-byte-per-character encoding specified by the collation
--		- VARCHAR/CHARACTER VARYING(n)
--			variable-length string up to size N
--			uses one-byte-per-character encoding specified by the collation
--			when we say 'abc', this is a VARCHAR
--			we can set N to MAX (VARCHAR(MAX)) and that will allow maximum size
--		- NCHAR(n)
--			unicode CHAR (the N stands for 'national'))
--		- NVARCHAR(n)
--			unicode VARCHAR.  This is the one we use all the time for string stuff
--			we use this to store many international alphebets without depending on
--				collation
--			when we say N'abc', this is an NVARCHAR (can also use MAX here)
--	date/time
--		- DATE for dates
--		- TIME for times
--		- DATETIME for timestamps, for times of a certain day
--			We don't use DATETIME because it is low precision and limited range
--		- DATETIME2(n) for high-precision, wide-range timestamps
--			N controls precision (might as well use MAX)
--		- DATETIMEOFFSET for intervals of time
--		We can use EXTRACT to get e.g. the YEAR fomr out of a DATETIME2.
--		There's also implicit conversion from strings so I can compare dates with '2019'

-- SELECT statement advanced usage
-- GROUP BY clause
-- by itself, it doesn't do a lot, but becomes useful with aggregate functions
--	aggregate functions are functions that take in many values and return one value
--		COUNT, AVG, SUM, MIN, MAX

-- all first names of customers, and the number of duplicates of them
SELECT FirstName, COUNT(FirstName) AS Count
FROM SalesLT.Customer
GROUP BY FirstName
ORDER BY COUNT(FirstName) DESC

-- GROUP BY accepts a list of columns and all rows which share the same values
--	of all those columns are combined into one row in the result set

SELECT FirstName, COUNT(FirstName) AS Count, LastName
FROM SalesLT.Customer
GROUP BY FirstName, LastName
ORDER BY COUNT(FirstName) DESC

-- if we havea a GROUP BY, we can't use any column in the select list unless
--	we say how to combine it together
-- Either you make it the basis for combining rows (put it in the GROUP BY)
--	OR, you run into some aggregate function which says how to turn the many
--	values into one value

-- how can I show all  first names having no duplicate?
SELECT FirstName
FROM SalesLT.Customer
WHERE COUNT(FirstName) = 1
GROUP BY FirstName -- doesn't work

-- first, rows from the table are filtered with WHERE
-- THEN, we run any aggregations with GROUP BY
-- if we want to run conditions based on the aggregated rows, we need the HAVING clause

SELECT FirstName
FROM SalesLT.Customer
WHERE LastName < 'n' -- we don't have to return every column we use
GROUP BY FirstName 
HAVING COUNT(FirstName) = 1

-- logical order of execution of a SELECT statemetn
-- essentially it "runs" in the order you write it except the SELECT cause is last
-- https://docs.microsoft.com/en-us/sql/t-sql/queries/select-transact-sql?view=sql-server-2017
-- 1. From
-- 2. Where
-- 3. GROUP BY
-- 4. HAVING
-- 5. SELECT
-- 6. ORDER BY