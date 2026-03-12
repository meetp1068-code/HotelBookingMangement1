using Dapper;
using HotelBookingManagement.Data;
using HotelBookingManagement.Models.DTOs;
using HotelBookingManagement.Models.Entities;
using System.Data;

public class UserRepository : IUserRepository
{
    private readonly DapperContext _context;

    public UserRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> RegisterUser(RegisterDto user)
    {
        var parameters = new DynamicParameters();

        parameters.Add("@FullName", user.FullName);
        parameters.Add("@Email", user.Email);
        parameters.Add("@Phone", user.Phone);
        parameters.Add("@PasswordHash", user.Password);

        using var connection = _context.CreateConnection();

        return await connection.ExecuteAsync(
            "sp_RegisterUser",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var parameters = new DynamicParameters();

        parameters.Add("@Email", email);

        using var connection = _context.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<User>(
            "sp_GetUserByEmail",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }
}