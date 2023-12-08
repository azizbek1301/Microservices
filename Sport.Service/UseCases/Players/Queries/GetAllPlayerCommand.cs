using MediatR;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Players.Queries
{
    public class GetAllPlayerCommand : IRequest<List<Player>>
    {
    }
}
