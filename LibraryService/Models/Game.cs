namespace LibraryService.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Gerne { get; set; }
        public Developer Developer { get; set; }        
    }
}
