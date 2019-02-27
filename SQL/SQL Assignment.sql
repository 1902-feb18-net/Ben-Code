SELECT CustomerID, FirstName + ' ' + LastName AS [Full Name], Country 
FROM dbo.Customer
WHERE Country != 'USA'

SELECT CustomerID, FirstName + ' ' + LastName AS [Full Name], Country
FROM dbo.Customer
WHERE Country = 'Brazil'

SELECT EmployeeID, FirstName + ' ' + LastName AS [Full Name], Title
FROM dbo.Employee
WHERE Title LIKE 'Sales%'

SELECT BillingCountry
FROM dbo.Invoice
GROUP BY BillingCountry

SELECT COUNT (InvoiceDate) as Count, SUM(Total) as [Total Cost]
FROM dbo.Invoice
WHERE InvoiceDate BETWEEN '2009' AND '2010'

--or for extra credit

SELECT YEAR(InvoiceDate) AS Year, COUNT(InvoiceDate) AS Count, SUM(Total) AS [Total Cost]
From Invoice
GROUP BY YEAR(InvoiceDate)

SELECT SUM(Quantity) as [Total]
FROM dbo.InvoiceLine
WHERE InvoiceID = '37'

SELECT BillingCountry, COUNT(BillingCountry) as [Total Invoices]
FROM dbo.Invoice
GROUP BY BillingCountry
ORDER BY [Total Invoices] DESC

SELECT BillingCountry, SUM(Total) as Total
FROM dbo.Invoice
GROUP BY BillingCountry
ORDER BY Total DESC

SELECT * FROM dbo.Invoice
SELECT * FROM dbo.InvoiceLine
