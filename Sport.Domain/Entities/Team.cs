namespace Sport.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Coach> Coachs { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}
