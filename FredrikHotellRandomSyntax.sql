Use FredrikHotell;



SELECT COUNT(CustomerID), FirstName
FROM Customers
GROUP BY FirstName
ORDER BY COUNT(CustomerID)

SELECT COUNT(LastName), FirstName
FROM Customers
GROUP BY FirstName


SELECT Bookings.BookingID, Customers.FirstName, Bookings.BookingDate
FROM ((Bookings
JOIN Customers ON Bookings.CustomerID = Customers.CustomerID)
JOIN Rooms ON Bookings.RoomID = Rooms.RoomID);

SELECT * FROM Rooms WHERE Rooms.RoomSize < 50
ORDER BY RoomPrice DESC

SELECT * FROM Rooms WHERE Rooms.RoomType = 'dubbel'
ORDER BY Rooms.AmountOfBeds, Rooms.RoomSize DESC