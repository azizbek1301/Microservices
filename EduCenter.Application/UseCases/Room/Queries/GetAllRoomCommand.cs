using MediatR;

namespace EduCenter.Application.UseCases.Room.Queries
{
    public class GetAllRoomCommand :IRequest<List<Domain.Entities.Room>>
    {

    }
}
