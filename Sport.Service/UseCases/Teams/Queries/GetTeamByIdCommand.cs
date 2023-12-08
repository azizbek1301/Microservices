using MediatR;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Teams.Queries
{
    public class GetTeamByIdCommand :IRequest<Team>
    {
        public int Id { get; set; }
    }
}
