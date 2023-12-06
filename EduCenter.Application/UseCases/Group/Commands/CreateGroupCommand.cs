using MediatR;

namespace EduCenter.Application.UseCases.Group.Commands
{
    public class CreateGroupCommand:IRequest
    {
        public string ClassNumber { get; set; }
        public int StudentCount { get; set; }

        public int SchoolId { get; set; }

    }
}
