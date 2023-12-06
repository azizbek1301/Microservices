using MediatR;

namespace EduCenter.Application.UseCases.Group.Commands
{
    public class DeleteGroupCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
