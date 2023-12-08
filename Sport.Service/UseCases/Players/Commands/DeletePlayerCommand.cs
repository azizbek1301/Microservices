using MediatR;

namespace Sport.DataApplication.UseCases.Players.Commands
{
    public class DeletePlayerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
