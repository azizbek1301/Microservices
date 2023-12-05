using MediatR;

namespace EduCenter.Application.UseCases.Student.Queries
{
    public class GetAllStudentCommand: IRequest<List<Domain.Entities.Student>>
    {

    }
}
