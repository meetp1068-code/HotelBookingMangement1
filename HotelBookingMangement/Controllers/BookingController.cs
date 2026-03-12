using Microsoft.AspNetCore.Mvc;
using HotelBookingManagement.Models.DTOs;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingRepository _bookingRepository;

    public BookingController(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookings()
    {
        var bookings = await _bookingRepository.GetBookings();
        return Ok(bookings);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetBookingsByUser(int userId)
    {
        var bookings = await _bookingRepository.GetBookingsByUser(userId);
        return Ok(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> AddBooking(BookingDto dto)
    {
        var result = await _bookingRepository.AddBooking(dto);
        return Ok(result);
    }

    [HttpPut("cancel/{id}")]
    public async Task<IActionResult> CancelBooking(int id)
    {
        var result = await _bookingRepository.CancelBooking(id);
        return Ok(result);
    }
}