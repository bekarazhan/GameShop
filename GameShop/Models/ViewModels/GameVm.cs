namespace GameShop.Models.ViewModels
{
    public class GameVm
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int? GenreId { get; set; }
        public string? GenreName { get; set; }

    }
}
