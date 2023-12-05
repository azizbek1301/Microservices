using EduCenter.Application.Abstarction;
using EduCenter.Application.UseCases.Student.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduCenter.Application.UseCases.Student.Handlers
{
    public class GetAllStudentHandler : IRequestHandler<GetAllStudentCommand, List<Domain.Entities.Student>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllStudentHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Student>> Handle(GetAllStudentCommand request, CancellationToken cancellationToken)
        {
            return await _context.Student.ToListAsync();
        }
    }
}
