--1. which artists did not make any albums at all?

SELECT *
FROM Artist
WHERE ArtistId NOT IN (
	SELECT Album.ArtistId
	FROM Album
)

SELECT ar.Name
FROM Artist AS ar
EXCEPT
SELECT ar.Name
FROM Artist AS ar RIGHT JOIN Album AS al ON ar.ArtistId = al.ArtistId

--2. which artists did not record any tracks of the Latin genre?

-- Artist.ArtistId to Album.ArtistId, Album.AlbumId to Track.AlbumId, Track.GenreId to Genre.GenreId

SELECT ar.Name
FROM Artist AS ar
	INNER JOIN Album AS al ON al.ArtistId = ar.ArtistId
	INNER JOIN Track AS t ON t.AlbumId = al.AlbumId
	INNER JOIN Genre AS g ON t.GenreId = g.GenreId
WHERE g.Name != 'Latin'
GROUP BY ar.Name

--3. which video track has the longest length? (use media type table)
SELECT *
FROM MediaType AS mt


--SELECT *
--FROM Artist
--WHERE ArtistId = (
--	SELECT TOP(1) ArtistId
--	FROM Album
--	ORDER BY LEN(Title) DESC
--)

--4. find the names of the customers who live in the same city as the boss employee (the one who reports to nobody)


--5. how many audio tracks were bought by German customers, and what was the total price paid for them?


--6. list the names and countries of the customers supported by an employee who was hired younger than 35.


--^^ solve these with a mixture of joins, subqueries, CTE, and set operators. solve at least one of them in two different ways, and see if the execution plan for them is the same, or different. (edited) 