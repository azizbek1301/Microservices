using MediatR;

namespace EduCenter.Application.UseCases.Teacher.Queries
{
    public class GetTeacherInfoCommand :IRequest<List<Domain.Entities.Teacher>>
    {
    }
}
