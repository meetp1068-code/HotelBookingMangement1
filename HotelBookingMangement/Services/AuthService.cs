using HotelBookingManagement.Models.DTOs;
using HotelBookingManagement.Helpers;
using BCrypt.Net;

namespace HotelBookingManagement.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtHelper _jwtHelper;

    public AuthService(IUserRepository userRepository, JwtHelper jwtHelper)
    {
        _userRepository = userRepository;
        _jwtHelper = jwtHelper;
    }

    public async Task<string> Register(RegisterDto dto)
    {
        var existingUser = await _userRepository.GetUserByEmail(dto.Email);

        if (existingUser != null)
            return "User already exists";

        // Hash password
        dto.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        await _userRepository.RegisterUser(dto);

        return "User registered successfully";
    }

    public async Task<string> Login(LoginDto dto)
    {
        var user = await _userRepository.GetUserByEmail(dto.Email);

        if (user == null)
            return "User not found";

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

        if (!isPasswordValid)
            return "Invalid password";

        var token = _jwtHelper.GenerateToken(user);

        return token;
    }
}