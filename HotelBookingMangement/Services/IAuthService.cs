using HotelBookingManagement.Models.DTOs;

namespace HotelBookingManagement.Services;

public interface IAuthService
{
    Task<string> Register(RegisterDto dto);
    Task<string> Login(LoginDto dto);
}