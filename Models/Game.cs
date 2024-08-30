namespace RelationsNaN.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ReleaseYear { get; set; }
        public Genre? genre { get; set; }
        public List<weshbro> weshbros { get; set; }
    }
}
