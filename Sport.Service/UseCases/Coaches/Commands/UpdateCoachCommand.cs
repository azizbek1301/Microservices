using MediatR;

namespace Sport.DataApplication.UseCases.Coaches.Commands
{
    public class UpdateCoachCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int TeamId { get; set; }
    }
}
