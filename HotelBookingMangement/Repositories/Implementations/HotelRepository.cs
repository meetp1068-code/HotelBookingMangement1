using Dapper;
using HotelBookingManagement.Data;
using HotelBookingManagement.Models.DTOs;
using HotelBookingManagement.Models.Entities;
using System.Data;

public class HotelRepository : IHotelRepository
{
    private readonly DapperContext _context;

    public HotelRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Hotel>> GetHotels()
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<Hotel>(
            "sp_GetHotels",
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<Hotel> GetHotelById(int id)
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Hotel>(
            "sp_GetHotelById",
            new { HotelId = id },   // PASS PARAMETER
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<int> AddHotel(HotelDto dto)
    {
        using var connection = _context.CreateConnection();

        return await connection.ExecuteAsync(
            "sp_AddHotel",
            dto,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<int> UpdateHotel(int id, HotelDto dto)
    {
        using var connection = _context.CreateConnection();

        return await connection.ExecuteAsync(
            "sp_UpdateHotel",
            new
            {
                HotelId = id,
                dto.Name,
                dto.Location,
                dto.Description,
                dto.StarRating
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<int> DeleteHotel(int id)
    {
        using var connection = _context.CreateConnection();

        return await connection.ExecuteAsync(
            "sp_DeleteHotel",
            new { HotelId = id },
            commandType: CommandType.StoredProcedure
        );
    }
}