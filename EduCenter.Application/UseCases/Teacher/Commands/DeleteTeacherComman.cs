using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Application.UseCases.Teacher.Commands
{
    public class DeleteTeacherComman:IRequest<bool>
    {
        public int TeacherId {  get; set; }
    }
}
