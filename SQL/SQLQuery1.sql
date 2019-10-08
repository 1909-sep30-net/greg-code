-- basic exercises (Chinook database)

-- 1. list all customers (full names, customer ID, and country) who are not in the US
SELECT *
FROM Customer
WHERE Country != 'USA';

-- 2. list all customers from brazil
SELECT *
FROM dbo.
WHERE Country = 'Brazil';

-- 3. list all sales agents
SELECT *
FROM Employee
WHERE Title LIKE '%Sales%Agent%'; --Sales Agent

-- 4. show a list of all countries in billing addresses on invoices.
SELECT BillingCountry
FROM Invoice;

-- 5. how many invoices were there in 2009, and what was the sales total for that year?
--    (extra challenge: find the invoice count sales total for every year, using one query)
SELECT *
FROM Invoice

SELECT COUNT(*), SUM(Total)
FROM Invoice
WHERE year(InvoiceDate) = 2009; 

SELECT DISTINCT (YEAR(InvoiceDate)) AS [Year], COUNT(*), SUM(Total)
FROM INVOICE
GROUP BY (YEAR(InvoiceDate));

-- 6. how many line items were there for invoice #37?
SELECT COUNT(*)
FROM INVOICELine
WHERE InvoiceId = 37;


-- 7. how many invoices per country?
SELECT BillingCountry, COUNT(*)
From Invoice
GROUP BY BillingCountry;


-- 8. show total sales per country, ordered by highest sales first.
SELECT BillingCountry, SUM(Total)
FROM Invoice
GROUP BY BillingCountry
ORDER BY SUM(Total) DESC;