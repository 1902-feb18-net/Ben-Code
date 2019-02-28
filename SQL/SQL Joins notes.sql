-- JOINS

-- cross join (on the same table)

SELECT e1. *, e2. *
FROM Employee AS e1 CROSS JOIN Employee AS e2

-- inner join (only keep rows that amtch some condition across that row)
--	usually a foriegn key == a primary key
--	most common kind of join, we're piecing back data before normalization

SELECT *
FROM Track INNER JOIN Genre ON Track.GenreId = Genre.GenreId

-- this is the exact same thing as a cross join
SELECT *
FROM Track INNER JOIN Genre ON 1 = 1

-- outer join 
--	still going to have a condition like inner join
--	if there's no matching row for one table to the other
--	Left outer Join: preserve everything in the left table
--	Right outer join: preserve everything in the right table
--	Full outer Join: Don't want to lose any data from both tables, anything missing is filled with NULL

SELECT t.Name, g.Name
FROM Track t RIGHT JOIN Genre g ON t.GenreId = g.GenreId

-- all rocks songs in the database, showing artist name and song name
SELECT ar.Name + ' - ' + t.Name
FROM Track AS t
	INNER JOIN Album AS al ON t.AlbumId = al.AlbumId
	INNER JOIN Artist AS ar ON al.ArtistId = ar.ArtistId
	INNER JOIN Genre AS g ON t.GenreId = g.GenreId
WHERE g.Name = 'Rock';

-- Every employee together with who he reports to (his manager) if any
SELECT 
	emp.FirstName + ' ' + emp.LastName AS Employee,
	mgr.FirstName + ' ' + mgr.LastName AS Manager
FROM Employee AS emp
	LEFT OUTER JOIN Employee AS mgr ON emp.ReportsTo = mgr.EmployeeId

--1. show all invoices of customers from brazil (mailing address not billing)
SELECT Customer.FirstName, Customer.LastName, Invoice. *
FROM Invoice INNER JOIN Customer ON Invoice.CustomerId = Customer.CustomerId
WHERE Customer.Country = 'Brazil'

--2. show all invoices together with the name of the sales agent of each one
SELECT emp.FirstName + ' ' + emp.LastName AS [Sales Associate Name], i. *
FROM Invoice AS i 
	INNER JOIN Customer AS cus ON i.CustomerId = cus.CustomerId
	INNER JOIN Employee AS emp ON cus.SupportRepId = emp.EmployeeId
WHERE emp.Title LIKE 'Sales%'

SELECT * FROM PlaylistTrack

--3. show all playlists ordered by the total number of tracks they have
SELECT pl. *, SUM(plt.PlaylistID) AS [Number]
FROM Playlist AS pl INNER JOIN PlaylistTrack AS plt ON plt.PlaylistId = pl.PlayListId
ORDER BY pl.Name

--4. which sales agent made the most in sales in 2009?


--5. how many customers are assigned to each sales agent?


--6. which track was purchased the most since 2010?

-- SUBQUERIES

-- another way (actually several ways) besides joins
--	to combine info from multiple tables

-- every track that has never been purchased
SELECT * 
FROM Track AS t
WHERE t.TrackId NOT IN (
	SELECT TrackId
	FROM InvoiceLine
);
-- Here we have a subquery in the WHERE clause of another query
-- we have operators IN, NOT IN


SELECT t.Name 
FROM Track AS t
WHERE t.TrackId = (
	SELECT TOP(1) TrackId
	FROM InvoiceLine
	GROUP BY TrackId
	ORDER BY COUNT(*) DESC
);

-- We have TOP(n) to take just the first n results of a query
-- The inner query is: get the top trackid, when we group all the invoicelines
--	by trackid, and count up how many in each group

-- We can also  have subqueries in HAVING (no difference), but also in the
--	FROM clause

SELECT * 
FROM Track INNER JOIN (
	SELECT Artist.Name AS Artist, Album.Title AS Album, Album.AlbumId AS AlbumId
	FROM Artist JOIN Album ON Album.ArtistId = Artist.ArtistId
	) AS subq ON Track.AlbumId = subq.AlbumId
WHERE Track.Name < 'b';

-- similar to subquery in FROM is "commong table expression" (CTE)
--	which uses a "WITH" clause

-- every track that has never been purchased (CTE version)
WITH purchased_tracks AS (
	SELECT DISTINCT TrackId
	FROM InvoiceLine
)
SELECT *
FROM Track AS t
WHERE t.TrackId NOT IN (
	SELECT TrackId
	FROM purchased_tracks
)

-- some other subquery operators:
-- EXISTS, NOT EXISTS
-- SOME, ANY

-- get the artist who made the album with the longest title
SELECT *
FROM Artist
WHERE ArtistId = (
		SELECT ArtistId
		FROM Album
		WHERE LEN(Title) >= ALL (SELECT LEN(Title) FROM Album)
	)

-- does the same thing (but better)
SELECT *
FROM Artist
WHERE ArtistId = (
	SELECT TOP(1) ArtistId
	FROM Album
	ORDER BY LEN(Title) DESC
)

-- SET OPERATIONS
-- we have from mathematical sets the concepts of UNION,
--	INTERSECT, and (set difference) EXCEPT

-- all first names of customers and employees
SELECT FirstName FROM Customer
UNION
SELECT FirstName FROM Employee --63 rows

-- all rows of the first query and also all rows of the second query
-- (the number and types of the columns need to be compatible)

-- for each set op, we have a distinct version and an ALL version
-- the DISTINCT version is the default
--	So by default, all these operators make a pass to remove duplicate rows from the result

SELECT FirstName FROM Customer
UNION ALL
SELECT FirstName FROM Employee -- 67 (has duplicates)

-- UNION gives you values that are in EITHER  result
-- INTERSECT gives you values that are in BOTH results
-- EXCEPT gives you values that are in the FIRST but NOT the SECOND result


-- DATA MANIPULATION LANGUAGE

-- SQL has many statement/commands
-- they are categorized as a number of sub languages

-- Data manipulation language (DML) operates on individual rows
-- there are five DML commands in SQL Server

-- SELECt, INSERT, UPDATE, DELETE, TRUNCATE TABLE

-- SELECT is for read access to the rows

-- INSERT (simple)
INSERT INTO Genre VALUES (26, 'Misc');
-- really we should name the columns
-- this is more readable/less error prone and it lets us skip
--	columns that have default values we are OK with
INSERT INTO Genre (GenreId, Name) VALUES (26, 'Misc')
INSERT INTO Genre (GenreId, Name) VALUES
(
	(SELECT MAX(GenreId) FROM Genre) + 1,
	'Misc 2'
)

-- can insert multiple rows at once
INSERT INTO Genre (GenreId, Name) VALUES
	(27, 'Misc3'),
	(28, 'Misc4');

-- can insert the result  of a query
-- this one duplicates every genre
INSERT INTO Genre (GenreId, Name) 
	(SELECT GenreId + 100, Name
	FROM Genre)

-- UPDATE statement
UPDATE Genre
SET Name = 'Misc 1' -- could change more than one column, comma separated
WHERE Name = 'Misc';
-- if we left out the where we would change every row 

-- take the high ID copies of my Misc genres, lower the IDs and rename
--	them to say Miscellaneous
UPDATE Genre
SET GenreId = GenreId - 50, Name = 'Miscellaneous ' + SUBSTRING(Name, 6, 1)
WHERE GenreId > 100 AND Name LIKE 'Misc%'

-- DELETE statement
DELETE FROM Genre
WHERE GenreId > 100 -- without WHERE, would delete every row

-- TRUNCATE TABLE
-- TRUNCATE TABLE Genre 
-- -- deletes every row, no conditions

-- DELETE FROM deletes every row, one at a time, slightly safer
-- TRUNCATE TABLE deletes every row all at once, faster

-- EXERCISES
-- 1. insert two new records into the employee table.
SELECT *
FROM Employee
INSERT INTO Employee (EmployeeId, LastName, FirstName, Title, ReportsTo, BirthDate, HireDate, Address, 
City, State, Country, PostalCode, Phone, Fax, Email)
VALUES (9, 'Ly', 'Andy', 'Self-executioner', NULL, 1994-03-25, 2019-02-27, '123 MeStreet Ave', 
'MeVill', 'TX', 'USA', 'TNT 500', '+1 (415) 333-3333', '+1 (415) 333-3333', 'littleteacup@mevill.org')

-- 2. insert two new records into the tracks table.
SELECT *
FROM Track
INSERT INTO Track (TrackId, Name, AlbumId, MediaTypeId, GenreId, Composer, Milliseconds, Bytes, UnitPrice)
VALUES (3504, '1234 Gonna Rock!', 348, 2, 24, 'Ben Mages', 145325, 3415345, 0.99)

-- 3. update customer Aaron Mitchell's name to Robert Walter



-- 4. delete one of the employees you inserted.


-- 5. delete customer Robert Walter. (more complex than it seems!)
DELETE FROM Customer
WHERE FirstName = 'Robert' AND LastName = 'Walter'
-- to preserve referential integrity, the DB throws an error

-- -- we could set those foreign key values to NULL, or we could delete all of them

-- so we need to remove all invoices the reference Robert and all invoice lines 
--	that reference those invoices,  but in the reverse order - deleting robert is 
--	the last step