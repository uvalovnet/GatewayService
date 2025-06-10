namespace Entities.Responses.Game
{
    public class Game
    {
        public int Id { get; set; }
        public int Places { get; set; }
        public int PlacesOccupied { get; set; }
        public decimal BuyIn { get; set; }
        public string TimeMode { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
    }
}
