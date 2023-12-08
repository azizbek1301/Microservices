using MediatR;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Teams.Queries
{
    public class GetAllTeamCommand : IRequest<List<Team>>
    {
    }
}
