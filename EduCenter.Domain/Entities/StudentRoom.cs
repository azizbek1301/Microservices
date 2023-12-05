using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Domain.Entities
{
    public class StudentRoom
    {
        public int Id { get; set; }

        public int StudentId {  get; set; }
        public Student Student { get; set; }    


        public int RoomId {  get; set; }
        public Room Room { get; set; }
    }
}
