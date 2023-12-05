using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Application.UseCases.School.Commands
{
    public class DeleteSchoolCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
