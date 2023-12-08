using MediatR;

namespace Sport.DataApplication.UseCases.Coaches.Commands
{
    public class CreateCoachCommand:IRequest
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public int TeamId { get; set; }
    }
}
