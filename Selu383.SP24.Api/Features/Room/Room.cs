namespace Selu383.SP24.Api.Features.Room
{
    public class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string RoomNumber { get; set; }
        public bool IsAvailable { get; set; }
        public int HotelId { get; set; }
        public decimal Price { get; set; }


    }
}
