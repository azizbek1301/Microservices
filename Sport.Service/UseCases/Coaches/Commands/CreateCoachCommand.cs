using MediatR;

namespace Sport.DataApplication.UseCases.Coaches.Commands
{
    public class CreateCoachCommand:IRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int TeamId { get; set; }
    }
}
