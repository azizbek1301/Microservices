using MediatR;

namespace Sport.DataApplication.UseCases.Teams.Commands
{
    public class DeleteTeamCommand :IRequest<bool>
    {
        public int Id { get; set; }
    }
}
