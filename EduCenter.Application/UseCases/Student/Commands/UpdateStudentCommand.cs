using EduCenter.Domain.Enums;
using MediatR;

namespace EduCenter.Application.UseCases.Student.Commands
{
    public class UpdateStudentCommand:IRequest<bool>
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
