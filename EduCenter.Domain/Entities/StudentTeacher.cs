namespace EduCenter.Domain.Entities
{
    public class StudentTeacher
    {
        public int Id { get; set; }
        
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }

}
