namespace EduCenter.Api.ViewModels
{
    public class SchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Phone_Number { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
