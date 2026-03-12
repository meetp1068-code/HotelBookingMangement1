
   CREATE TABLE Users
(
    UserId INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(15),
    PasswordHash NVARCHAR(255),
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
)
CREATE TABLE Hotels
(
    HotelId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Location NVARCHAR(150) NOT NULL,
    Description NVARCHAR(MAX),
    StarRating INT,
    PricePerNight DECIMAL(10,2),
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
CREATE TABLE Rooms
(
    RoomId INT IDENTITY(1,1) PRIMARY KEY,
    HotelId INT NOT NULL,
    RoomNumber NVARCHAR(20),
    RoomType NVARCHAR(50),
    Capacity INT,
    Price DECIMAL(10,2),
    IsAvailable BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Rooms_Hotel
    FOREIGN KEY (HotelId) REFERENCES Hotels(HotelId)
);

CREATE TABLE Bookings
(
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    HotelId INT NOT NULL,
    RoomId INT NOT NULL,

    CheckInDate DATE,
    CheckOutDate DATE,

    TotalAmount DECIMAL(10,2),
    Status NVARCHAR(50) DEFAULT 'Pending',

    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Booking_User FOREIGN KEY (UserId) REFERENCES Users(UserId),
    CONSTRAINT FK_Booking_Hotel FOREIGN KEY (HotelId) REFERENCES Hotels(HotelId),
    CONSTRAINT FK_Booking_Room FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId)
);
