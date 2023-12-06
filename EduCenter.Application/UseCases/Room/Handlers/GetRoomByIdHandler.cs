using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Room.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Room.Handlers
{
    public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdCommand, Domain.Entities.Room>
    {
        private readonly IApplicationDbContext _context;

        public GetRoomByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Room> Handle(GetRoomByIdCommand request, CancellationToken cancellationToken)
        {
            var room=await _context.Room.FirstOrDefaultAsync(x=>x.Id==request.Id);
            return room;
        }
    }
}
