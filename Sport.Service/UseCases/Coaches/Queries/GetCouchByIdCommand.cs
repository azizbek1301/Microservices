using MediatR;
using Sport.Domain.Entities;

namespace Sport.DataApplication.UseCases.Coaches.Queries
{
    public class GetCouchByIdCommand : IRequest<Coach>
    {
        public int Id {  get; set; }
    }
}
