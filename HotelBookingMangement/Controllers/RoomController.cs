using Microsoft.AspNetCore.Mvc;
using HotelBookingManagement.Models.DTOs;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomRepository _roomRepository;

    public RoomController(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    [HttpGet("hotel/{hotelId}")]
    public async Task<IActionResult> GetRoomsByHotel(int hotelId)
    {
        var rooms = await _roomRepository.GetRoomsByHotel(hotelId);
        return Ok(rooms);
    }

    [HttpPost]
    public async Task<IActionResult> AddRoom(RoomDto dto)
    {
        var result = await _roomRepository.AddRoom(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(int id, RoomDto dto)
    {
        var result = await _roomRepository.UpdateRoom(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var result = await _roomRepository.DeleteRoom(id);
        return Ok(result);
    }
}