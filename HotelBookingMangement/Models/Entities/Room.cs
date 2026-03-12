namespace HotelBookingManagement.Models.Entities
{
    public class Room
    {
        public int RoomId { get; set; }

        public int HotelId { get; set; }

        public string RoomNumber { get; set; }

        public string RoomType { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
    }
}