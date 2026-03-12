using Dapper;
using HotelBookingManagement.Data;
using HotelBookingManagement.Models.DTOs;
using HotelBookingManagement.Models.Entities;
using System.Data;

public class RoomRepository : IRoomRepository
{
    private readonly DapperContext _context;

    public RoomRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> AddRoom(RoomDto dto)
    {
        using var connection = _context.CreateConnection();

        return await connection.ExecuteAsync(
            "sp_AddRoom",
            dto,
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<IEnumerable<Room>> GetRoomsByHotel(int hotelId)
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryAsync<Room>(
            "sp_GetRoomsByHotel",
            new { HotelId = hotelId },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<Room> GetRoomById(int id)
    {
        using var connection = _context.CreateConnection();

        return await connection.QueryFirstOrDefaultAsync<Room>(
            "sp_GetRoomById",
            new { RoomId = id },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<int> UpdateRoom(int id, RoomDto dto)
    {
        using var connection = _context.CreateConnection();

        return await connection.ExecuteAsync(
            "sp_UpdateRoom",
            new
            {
                RoomId = id,
                dto.RoomNumber,
                dto.RoomType,
                dto.Capacity,
                dto.Price
            },
            commandType: CommandType.StoredProcedure
        );
    }

    public async Task<int> DeleteRoom(int id)
    {
        using var connection = _context.CreateConnection();

        return await connection.ExecuteAsync(
            "sp_DeleteRoom",
            new { RoomId = id },
            commandType: CommandType.StoredProcedure
        );
    }
}