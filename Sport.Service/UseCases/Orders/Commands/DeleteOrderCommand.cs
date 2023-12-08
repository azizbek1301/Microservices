using MediatR;

namespace Sport.DataApplication.UseCases.Orders.Commands
{
    public class DeleteOrderCommand:IRequest<bool>
    {
        public int Id {  get; set; }    
    }
}
