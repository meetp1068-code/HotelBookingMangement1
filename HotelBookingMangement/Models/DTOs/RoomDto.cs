namespace HotelBookingManagement.Models.DTOs
{
    public class RoomDto
    {
        public int HotelId { get; set; }

        public string RoomNumber { get; set; }

        public string RoomType { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }
    }
}