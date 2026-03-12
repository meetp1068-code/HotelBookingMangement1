CREATE PROCEDURE sp_RegisterUser
(
    @FullName NVARCHAR(150),
    @Email NVARCHAR(150),
    @Phone NVARCHAR(20),
    @PasswordHash NVARCHAR(500)
)
AS
BEGIN
    INSERT INTO Users
    (
        FullName,
        Email,
        Phone,
        PasswordHash
    )
    VALUES
    (
        @FullName,
        @Email,
        @Phone,
        @PasswordHash
    );
END
CREATE PROCEDURE sp_GetUserByEmail
(
    @Email NVARCHAR(150)
)
AS
BEGIN
    SELECT *
    FROM Users
    WHERE Email = @Email
END
CREATE PROCEDURE sp_AddHotel
(
    @Name NVARCHAR(150),
    @Location NVARCHAR(150),
    @Description NVARCHAR(MAX),
    @StarRating INT
)
AS
BEGIN
    INSERT INTO Hotels
    (
        Name,
        Location,
        Description,
        StarRating
    )
    VALUES
    (
        @Name,
        @Location,
        @Description,
        @StarRating
    )
END
CREATE PROCEDURE sp_GetHotels
AS
BEGIN
    SELECT *
    FROM Hotels
    WHERE IsActive = 1
END

--GET HOTEL BY ID
CREATE PROCEDURE sp_GetHotelById
(
    @HotelId INT
)
AS
BEGIN
    SELECT *
    FROM Hotels
    WHERE HotelId = @HotelId
END
CREATE PROCEDURE sp_UpdateHotel
(
    @HotelId INT,
    @Name NVARCHAR(150),
    @Location NVARCHAR(150),
    @Description NVARCHAR(MAX),
    @StarRating INT
)
AS
BEGIN
    UPDATE Hotels
    SET
        Name = @Name,
        Location = @Location,
        Description = @Description,
        StarRating = @StarRating
    WHERE HotelId = @HotelId
END
CREATE PROCEDURE sp_DeleteHotel
(
    @HotelId INT
)
AS
BEGIN
    UPDATE Hotels
    SET IsActive = 0
    WHERE HotelId = @HotelId
END
CREATE PROCEDURE sp_AddRoom
(
    @HotelId INT,
    @RoomNumber NVARCHAR(50),
    @RoomType NVARCHAR(100),
    @Capacity INT,
    @Price DECIMAL(10,2)
)
AS
BEGIN
    INSERT INTO Rooms
    (
        HotelId,
        RoomNumber,
        RoomType,
        Capacity,
        Price
    )
    VALUES
    (
        @HotelId,
        @RoomNumber,
        @RoomType,
        @Capacity,
        @Price
    )
END
CREATE PROCEDURE sp_GetRoomsByHotel
(
    @HotelId INT
)
AS
BEGIN
    SELECT *
    FROM Rooms
    WHERE HotelId = @HotelId
    AND IsAvailable = 1
END

--GET ROOM BY ID
CREATE PROCEDURE sp_GetRoomById
(
    @RoomId INT
)
AS
BEGIN
    SELECT *
    FROM Rooms
    WHERE RoomId = @RoomId
END
CREATE PROCEDURE sp_UpdateRoom
(
    @RoomId INT,
    @RoomNumber NVARCHAR(50),
    @RoomType NVARCHAR(100),
    @Capacity INT,
    @Price DECIMAL(10,2)
)
AS
BEGIN
    UPDATE Rooms
    SET
        RoomNumber = @RoomNumber,
        RoomType = @RoomType,
        Capacity = @Capacity,
        Price = @Price
    WHERE RoomId = @RoomId
END
CREATE PROCEDURE sp_DeleteRoom
(
    @RoomId INT
)
AS
BEGIN
    UPDATE Rooms
    SET IsAvailable = 0
    WHERE RoomId = @RoomId
END
CREATE PROCEDURE sp_AddBooking
(
    @UserId INT,
    @HotelId INT,
    @RoomId INT,
    @CheckInDate DATE,
    @CheckOutDate DATE,
    @TotalAmount DECIMAL(10,2)
)
AS
BEGIN
    INSERT INTO Bookings
    (
        UserId,
        HotelId,
        RoomId,
        CheckInDate,
        CheckOutDate,
        TotalAmount
    )
    VALUES
    (
        @UserId,
        @HotelId,
        @RoomId,
        @CheckInDate,
        @CheckOutDate,
        @TotalAmount
    )
END
CREATE PROCEDURE sp_GetBookings
AS
BEGIN
    SELECT *
    FROM Bookings
END

--GET BOOKING BY USER
CREATE PROCEDURE sp_GetBookingsByUser
(
    @UserId INT
)
AS
BEGIN
    SELECT *
    FROM Bookings
    WHERE UserId = @UserId
END
CREATE PROCEDURE sp_CancelBooking
(
    @BookingId INT
)
AS
BEGIN
    UPDATE Bookings
    SET Status = 'Cancelled'
    WHERE BookingId = @BookingId
END
