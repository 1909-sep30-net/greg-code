-- exercises

-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?
SELECT ar.ArtistId, ar.Name
FROM Artist AS ar LEFT JOIN Album as al ON ar.ArtistId = al.ArtistId
GROUP BY ar.ArtistId, ar.Name
HAVING COUNT(al.ArtistId) = 0

SELECT ArtistId, Name
FROM Artist
WHERE ArtistId NOT IN
(SELECT DISTINCT ArtistId
FROM Album)

-- 2. which artists did not record any tracks of the Latin genre?
-- join version
SELECT * FROM Artist
EXCEPT
SELECT ar.* FROM Artist AS ar
    LEFT JOIN Album AS al ON ar.ArtistId = al.ArtistId
    LEFT JOIN Track AS t ON al.AlbumId = t.AlbumId
    LEFT JOIN Genre AS g ON t.GenreId = g.GenreId
WHERE g.Name = 'Latin';

-- unfinished subquery version
SELECT * FROM Artist
WHERE ArtistId NOT IN (
    SELECT AlbumId FROM Album WHERE 
    SELECT TrackId FROM Track WHERE GenreId = (
        SELECT GenreId FROM Genre WHERE Name = 'Latin'
    )
);

-- 3. which video track has the longest length? (use media type table)
SELECT *
FROM MediaType

SELECT *
FROM Track

--SELECT TrackId, MAX(Milliseconds)
--FROM Track
--WHERE MediaTypeId LIKE
--	(SELECT MediaTypeId
--	FROM MediaType
--	WHERE Name LIKE '%video%')
--GROUP BY TrackId
SELECT t.TrackID, t.Name, t.Milliseconds
FROM Track as t INNER JOIN MediaType as mt ON t.MediaTypeId = mt.MediaTypeId
WHERE	mt.Name LIKE '%video%' AND 
		t.Milliseconds = (SELECT MAX(Milliseconds) FROM Track)
GROUP BY t.Milliseconds, t.TrackID, t.Name



-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)
SELECT *
FROM Customer
WHERE City + State + Country = (SELECT City + State + Country
								FROM Employee
								WHERE ReportsTo IS NULL)


-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?
SELECT COUNT(t.TrackId) AS [Number of Tracks], SUM(il.Quantity * il.UnitPrice) AS [Total Price]
FROM Track AS t INNER JOIN MediaType AS mt ON t.MediaTypeId = mt.MediaTypeId
				INNER JOIN InvoiceLine AS il ON t.TrackId = il.TrackId
				INNER JOIN Invoice AS i ON il.InvoiceId = i.InvoiceId
				INNER JOIN Customer AS c ON i.CustomerId = c.CustomerId
WHERE	mt.Name LIKE '%audio%' AND
		c.Country = 'Germany'

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.
SELECT c.FirstName + ' ' + c.LastName AS [Name], c.Country
FROM	Customer AS c INNER JOIN
			(SELECT *
			FROM Employee
			WHERE (YEAR(HireDate) - YEAR(BirthDate)) < 35) AS e 
		 ON c.SupportRepId = e.EmployeeId