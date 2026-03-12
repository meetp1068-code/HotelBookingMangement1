using HotelBookingManagement.Models.DTOs;
using HotelBookingManagement.Models.Entities;

public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetHotels();

    Task<Hotel> GetHotelById(int id);

    Task<int> AddHotel(HotelDto dto);

    Task<int> UpdateHotel(int id, HotelDto dto);

    Task<int> DeleteHotel(int id);
}