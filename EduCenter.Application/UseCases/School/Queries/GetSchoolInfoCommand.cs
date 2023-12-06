using MediatR;

namespace EduCenter.Application.UseCases.School.Queries
{
    public class GetSchoolInfoCommand :IRequest<List<Domain.Entities.School>>
    {

    }
}
