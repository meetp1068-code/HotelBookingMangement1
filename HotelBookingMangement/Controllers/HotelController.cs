using Microsoft.AspNetCore.Mvc;
using HotelBookingManagement.Models.DTOs;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    private readonly IHotelRepository _hotelRepository;

    public HotelController(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetHotels()
    {
        var hotels = await _hotelRepository.GetHotels();
        return Ok(hotels);
    }

    [HttpPost]
    public async Task<IActionResult> AddHotel(HotelDto dto)
    {
        var result = await _hotelRepository.AddHotel(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotel(int id, HotelDto dto)
    {
        var result = await _hotelRepository.UpdateHotel(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var result = await _hotelRepository.DeleteHotel(id);
        return Ok(result);
    }
}