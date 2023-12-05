using MediatR;

namespace EduCenter.Application.UseCases.Teacher.Queries
{
    public class GetAllTeacherCommand : IRequest<List<Domain.Entities.Teacher>>
    {
    }
}
