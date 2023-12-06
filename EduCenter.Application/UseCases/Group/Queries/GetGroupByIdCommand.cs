using MediatR;

namespace EduCenter.Application.UseCases.Group.Queries
{
    public class GetGroupByIdCommand:IRequest<Domain.Entities.Group>
    {
        public int Id { get; set; }
    }
}
