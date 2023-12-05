using MediatR;

namespace EduCenter.Application.UseCases.Student.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int StudentId { get; set; }
    }
}
