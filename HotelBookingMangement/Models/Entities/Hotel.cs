namespace HotelBookingManagement.Models.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int StarRating { get; set; }

        public decimal PricePerNight { get; set; }

        public bool IsActive { get; set; }
    }
}