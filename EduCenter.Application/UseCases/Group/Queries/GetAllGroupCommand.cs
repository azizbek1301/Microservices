using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Application.UseCases.Group.Queries
{
    public class GetAllGroupCommand :IRequest<List<Domain.Entities.Group>>
    {
    }
}
