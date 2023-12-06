using MediatR;

namespace EduCenter.Application.UseCases.Room.Commands
{
    public class DeleteRoomCommand:IRequest<bool>
    {
        public int Id {  get; set; }
    }
}
