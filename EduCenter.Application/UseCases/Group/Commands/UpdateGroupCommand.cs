using MediatR;

namespace EduCenter.Application.UseCases.Group.Commands
{
    public class UpdateGroupCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string ClassNumber { get; set; }
        public int StudentCount { get; set; }
        public int SchoolId { get; set; }
    }
}
