using MediatR;

namespace Sport.DataApplication.UseCases.Teams.Commands
{
    public class UpdateTeamCommand :IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
