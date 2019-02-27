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