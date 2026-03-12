using HotelBookingManagement.Models.Entities;
using HotelBookingManagement.Models.DTOs;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetRoomsByHotel(int hotelId);

    Task<Room> GetRoomById(int id);

    Task<int> AddRoom(RoomDto room);

    Task<int> UpdateRoom(int id, RoomDto room);

    Task<int> DeleteRoom(int id);
}