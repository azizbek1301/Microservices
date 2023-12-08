namespace Sport.Domain.Entities
{
    public class Coach
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int TeamId {  get; set; }
        public Team Team { get; set; }
    }
}
