using System.ComponentModel.DataAnnotations.Schema;

namespace EduCenter.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int SeatCount { get; set; }

        public ICollection<GroupRoom> Groups { get; set; }
        public ICollection<StudentRoom> StudentRooms { get; set; }
    }
}
