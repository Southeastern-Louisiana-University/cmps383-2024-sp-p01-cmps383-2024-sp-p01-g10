namespace Selu383.SP24.Api.Features.Room
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

    }
}
