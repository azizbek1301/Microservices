using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Application.UseCases.School.Queries
{
    public class GetSchoolByIdCommand:IRequest<Domain.Entities.School>
    {
        public int Id { get; set; }

    }
}
