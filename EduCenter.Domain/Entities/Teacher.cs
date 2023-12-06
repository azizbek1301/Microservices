using EduCenter.Domain.Enums;

namespace EduCenter.Domain.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }

        public ICollection<StudentTeacher> StudentTeachers { get; set; }

    }

}
