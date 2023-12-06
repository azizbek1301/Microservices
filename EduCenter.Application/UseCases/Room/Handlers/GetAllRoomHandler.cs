using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Room.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Room.Handlers
{
    public class GetAllRoomHandler : IRequestHandler<GetAllRoomCommand, List<Domain.Entities.Room>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllRoomHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Room>> Handle(GetAllRoomCommand request, CancellationToken cancellationToken)
        {
            return await _context.Room.ToListAsync();
        }
    }
}
