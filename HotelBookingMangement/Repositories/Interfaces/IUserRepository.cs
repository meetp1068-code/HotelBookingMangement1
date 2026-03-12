using HotelBookingManagement.Models.DTOs;
using HotelBookingManagement.Models.Entities;

public interface IUserRepository
{
    Task<int> RegisterUser(RegisterDto user);

    Task<User> GetUserByEmail(string email);
}