namespace HotelBookingManagement.Models.DTOs
{
    public class HotelDto
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public int StarRating { get; set; }

        public decimal PricePerNight { get; set; }
    }
}