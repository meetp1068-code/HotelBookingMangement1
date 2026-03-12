using HotelBookingManagement.Models.DTOs;
using HotelBookingManagement.Models.Entities;

public interface IBookingRepository
{
    Task<int> AddBooking(BookingDto dto);

    Task<IEnumerable<Booking>> GetBookings();

    Task<IEnumerable<Booking>> GetBookingsByUser(int userId);

    Task<int> CancelBooking(int bookingId);
}