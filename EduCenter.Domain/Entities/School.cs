using System.ComponentModel.DataAnnotations;

namespace EduCenter.Domain.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }

}
