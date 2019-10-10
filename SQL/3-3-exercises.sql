-- exercises
SELECT * FROM Employee
-- 1. insert two new records into the employee table.
INSERT INTO Employee VALUES
(20, 'Favrot', 'Greg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(21, 'Barrilleaux', 'Ellie', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
-- 2. insert two new records into the tracks table.
SELECT * FROM Track
SELECT * FROM MediaType
INSERT INTO Track VALUES

--((SELECT (MAX(TrackID) + 1) FROM Track), 'Darling I Do', NULL, 1, NULL, 'Landon Pigg', 100000, NULL, 1.99),
((SELECT (MAX(TrackID) + 1) FROM Track), 'Love Me Do', NULL, 1, NULL, 'The Beatles', 100000, NULL, 1.99)


-- 3. update customer Aaron Mitchell's name to Robert Walter
UPDATE Customer
SET FirstName = 'Robert',
	LastName = 'Walter'
WHERE FirstName = 'Aaron' AND LastName = 'Mitchell'

SELECT * FROM Customer WHERE FirstName = 'Robert'



---UPDATE Customer
---SET FirstName = 'Robert', LastName = 'Walter'
---WHERE FirstName = 'Aaron' AND LastName = 'Mitchell';

-- 4. delete one of the employees you inserted.
DELETE Employee
WHERE EmployeeID = 20;
-- 5. delete customer Robert Walter.






--DELETE FROM InvoiceLine WHERE InvoiceId IN (
    SELECT InvoiceId FROM Invoice WHERE CustomerId = (
        SELECT CustomerId FROM Customer
        WHERE FirstName = 'Robert' AND LastName = 'Walter'
    )
);
DELETE FROM Invoice WHERE CustomerId = (
    SELECT CustomerId FROM Customer
    WHERE FirstName = 'Robert' AND LastName = 'Walter'
);
DELETE FROM Customer
WHERE FirstName = 'Robert' AND LastName = 'Walter';