using EduCenter.Domain.Enums;

namespace EduCenter.Api.ViewModels
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }  
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public int SchoolId { get; set; }
    }
}
