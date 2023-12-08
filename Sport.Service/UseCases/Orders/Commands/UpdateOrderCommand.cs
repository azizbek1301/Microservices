using MediatR;
using Sport.Domain.Enums;

namespace Sport.DataApplication.UseCases.Orders.Commands
{
    public class UpdateOrderCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public int PlayerId { get; set; }
    }
}
