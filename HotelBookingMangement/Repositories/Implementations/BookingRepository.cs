using Dapper;
using HotelBookingManagement.Data;
using HotelBookingManagement.Models.DTOs;
using HotelBookingManagement.Models.Entities;
using System.Data;

public class BookingRepository : IBookingRepository
{
    private readonly DapperContext _context;

    public BookingRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> AddBooking(BookingDto dto)
    {
        using var connection = _context.CreateConnection();

        return await connection.ExecuteAsync(
            "sp_AddBooking",
            dto,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<IEnumerable<Booking>> GetBookings()
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<Booking>(
            "sp_GetBookings",
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<IEnumerable<Booking>> GetBookingsByUser(int userId)
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<Booking>(
            "sp_GetBookingsByUser",
            new { UserId = userId },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<int> CancelBooking(int bookingId)
    {
        using var connection = _context.CreateConnection();

        return await connection.ExecuteAsync(
            "sp_CancelBooking",
            new { BookingId = bookingId },
            commandType: CommandType.StoredProcedure
        );
    }
}