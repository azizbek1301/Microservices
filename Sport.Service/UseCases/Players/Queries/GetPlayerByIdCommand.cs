using MediatR;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Players.Queries
{
    public class GetPlayerByIdCommand : IRequest<Player>
    {
        public int Id { get; set; }
    }
}
