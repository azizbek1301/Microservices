using MediatR;

namespace EduCenter.Application.UseCases.Student.Queries
{
    public class GetStudentByIdCommand :IRequest<Domain.Entities.Student>
    {
        public int StudentId {  get; set; }
    }
}
