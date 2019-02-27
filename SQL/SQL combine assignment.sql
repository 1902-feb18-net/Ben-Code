--1. which artists did not make any albums at all?
SELECT *
FROM Artist
WHERE ArtistId = (
	SELECT ArtistId
	FROM Album
	WHERE COUNT(Title) = 0
)

SELECT ar.Name
FROM Artist AS ar INNER JOIN Album AS al ON ar.ArtistId != al.ArtistId
GROUP BY ar.Name
ORDER BY al.ArtistId

SELECT * FROM Album
--2. which artists did not record any tracks of the Latin genre?


--3. which video track has the longest length? (use media type table)


--4. find the names of the customers who live in the same city as the boss employee (the one who reports to nobody)


--5. how many audio tracks were bought by German customers, and what was the total price paid for them?


--6. list the names and countries of the customers supported by an employee who was hired younger than 35.


--^^ solve these with a mixture of joins, subqueries, CTE, and set operators. solve at least one of them in two different ways, and see if the execution plan for them is the same, or different. (edited) 