namespace KnotExe.Models
{
    public class Timeline
    {
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public List<Jogo> Jogos { get; set; } = new List<Jogo>();

        public Timeline()
        {
            Posts = new List<Post>();
            Jogos = new List<Jogo>();
        }
    }
}
