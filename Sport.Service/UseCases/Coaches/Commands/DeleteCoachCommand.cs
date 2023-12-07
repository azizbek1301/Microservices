using MediatR;

namespace Sport.DataApplication.UseCases.Coaches.Commands
{
    public class DeleteCoachCommand : IRequest<bool>
    {
        public int Id {  get; set; }
    }
}
