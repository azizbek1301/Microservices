using MediatR;

namespace EduCenter.Application.UseCases.Room.Queries
{
    public class GetRoomByIdCommand : IRequest<Domain.Entities.Room>
    {
        public int Id { get; set; }
    }
}
