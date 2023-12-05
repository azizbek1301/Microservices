using EduCenter.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EduCenter.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }

        public ICollection<StudentTeacher> StudentTeachers { get; set; }
        public ICollection<StudentRoom> StudentRooms { get; set; }
    }

}
