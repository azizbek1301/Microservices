using Sport.Domain.Enums;

namespace Sport.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public int PlayerId {  get; set; }
        public Player Player { get; set; }
    }
}
