namespace EduCenter.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string ClassNumber { get; set; }
        public int StudentCount { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }

        public ICollection<GroupRoom> GroupRooms { get; set; }
    }

}
