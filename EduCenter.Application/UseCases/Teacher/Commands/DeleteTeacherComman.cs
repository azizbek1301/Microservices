using MediatR;

namespace EduCenter.Application.UseCases.Teacher.Commands
{
    public class DeleteTeacherComman : IRequest<bool>
    {
        public int TeacherId { get; set; }
    }
}
