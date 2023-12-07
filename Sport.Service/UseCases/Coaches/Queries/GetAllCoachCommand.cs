using MediatR;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Coaches.Queries
{
    public class GetAllCoachCommand : IRequest<List<Coach>>
    {
    }
}
