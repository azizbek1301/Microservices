using MediatR;

namespace EduCenter.Application.UseCases.Teacher.Queries
{
    public class GetTeacherByIdCommand : IRequest<Domain.Entities.Teacher>
    {
        public int TeacherId { get; set; }
    }
}
