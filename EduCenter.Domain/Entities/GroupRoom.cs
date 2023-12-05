using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Domain.Entities
{
    public class GroupRoom
    {
        public int Id { get; set; } 

        public int GroupId {  get; set; }
        public Group Group { get; set; }

        public int RoomId {  get; set; }
        public Room Room { get; set; }
    }
}
