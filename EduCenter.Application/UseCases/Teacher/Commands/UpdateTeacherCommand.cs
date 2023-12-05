using EduCenter.Domain.Enums;
using MediatR;

namespace EduCenter.Application.UseCases.Teacher.Commands
{
    public class UpdateTeacherCommand : IRequest<bool>
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public int SchoolId { get; set; }
    }
}
