using MediatR;

namespace Sport.DataApplication.UseCases.Teams.Commands
{
    public class CreateTeamCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
