using EduCenter.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCenter.Application.UseCases.Teacher.Commands
{
    public class CreatTeacherCommand:IRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public int SchoolId { get; set; }
    }
}
