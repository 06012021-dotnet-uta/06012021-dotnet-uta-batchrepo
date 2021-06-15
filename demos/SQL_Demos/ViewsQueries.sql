
-- make a view that does a join.

CREATE VIEW JoinCustomerWithAddress 
AS
SELECT FirstName, LastName, Addresses.City, Addresses.AddressLine1, Addresses.Addressid
FROM Customers
RIGHT JOIN Addresses 
ON Customers.AddressID = Addresses.Addressid
WHERE Addresses.City = 'Dallas, TX';

-- envoke the view.
SELECT * FROM JoinCustomerWithAddress;
DROP VIEW JoinCustomerWithAddress;

-- create teh same VIEW WITH SCHEMABINDING
CREATE VIEW JoinCustomerWithAddressWITHSCHEMABINDING 
WITH SCHEMABINDING
AS
SELECT Customers.FirstName, Customers.LastName, Addresses.City, Addresses.AddressLine1, Addresses.Addressid
FROM dbo.Customers
RIGHT JOIN dbo.Addresses 
ON Customers.AddressID = Addresses.Addressid
WHERE Addresses.City = 'Dallas, TX';

SELECT * FROM JoinCustomerWithAddressWITHSCHEMABINDING;
DROP VIEW JoinCustomerWithAddressWITHSCHEMABINDING ;

-- change some info to show data can still be changed when WITH SCHEMABINDING is used.
UPDATE Customers SET FirstName = 'Lib' WHERE FirstName = 'Libby';