using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Application.UseCases.School.Queries
{
    public class GetSchoolCommand:IRequest<List<Domain.Entities.School>>
    {

    }
}
