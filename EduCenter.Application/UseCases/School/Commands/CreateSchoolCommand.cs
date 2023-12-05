using MediatR;

namespace EduCenter.Application.UseCases.School.Commands
{
    public class CreateSchoolCommand:IRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } 
    }
}
