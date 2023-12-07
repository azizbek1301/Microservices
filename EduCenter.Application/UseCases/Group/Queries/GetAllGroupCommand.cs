using MediatR;

namespace EduCenter.Application.UseCases.Group.Queries
{
    public class GetAllGroupCommand : IRequest<List<Domain.Entities.Group>>
    {
    }
}
