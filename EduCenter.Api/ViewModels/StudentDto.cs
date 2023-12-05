using EduCenter.Domain.Enums;

namespace EduCenter.Api.ViewModels
{
    public class StudentDto
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
