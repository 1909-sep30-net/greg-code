-- join exercises (Chinook database)

-- 1. show all invoices of customers from brazil (mailing address not billing)
SELECT i.*, c.Country
FROM Invoice AS i INNER JOIN Customer AS c ON i.CustomerId = c.CustomerId
WHERE c.Country = 'Brazil';

-- 2. show all invoices together with the name of the sales agent of each one
Select i.*, e.*
FROM Invoice AS i	inner join Customer AS c ON i.CustomerId = c.CustomerId
					inner join Employee As e ON c.SupportRepId = e.EmployeeId

-- 3. show all playlists ordered by the total number of tracks they have
Select p.Name, COUNT(t.TrackId)
From Playlist as p LEFT JOIN PlaylistTrack as t ON p.PlaylistId = t.PlaylistId
Group by p.Name

-- 4. which sales agent made the most in sales in 2009?
Select e.EmployeeId, SUM(l.UnitPrice * l.Quantity)
FROM Employee AS e	INNER JOIN Customer AS c ON e.EmployeeId = c.SupportRepId
					INNER JOIN Invoice AS i ON c.CustomerId = i.CustomerId
					INNER JOIN InvoiceLine AS l on i.InvoiceId = l.InvoiceId
GROUP BY e.EmployeeId


-- 5. how many customers are assigned to each sales agent?
SELECT e.EmployeeId, e.FirstName + e.LastName, COUNT(c.CustomerId)
FROM Employee e RIGHT JOIN Customer AS c ON e.EmployeeId = c.SupportRepId
GROUP BY e.EmployeeId,  e.FirstName + e.LastName

-- 6. which track was purchased the most since 2010?
SELECT MAX(alpha.[Times Bought]) as [Times Bought]
FROM
	(SELECT t.TrackId as[Track ID], COUNT(il.InvoiceLineId) as [Times Bought]
	FROM Track AS t INNER JOIN InvoiceLine il ON t.TrackId = il.TrackId
					INNER JOIN Invoice i ON il.InvoiceId = i.InvoiceId
	WHERE YEAR(i.InvoiceDate) >= 2010
	GROUP BY t.TrackId) as alpha
GROUP BY alpha.[Track ID]
-- 7. show the top three best-selling artists.

-- 8. which customers have the same initials as at least one other customer?
