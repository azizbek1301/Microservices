using Sport.Domain.Enums;

namespace Sport.Api.ViewModel
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public int PlayerId { get; set; }
    }
}
