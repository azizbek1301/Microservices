﻿using EduCenter.Api.ViewModels;
using EduCenter.Application.UseCases.Student.Commands;
using EduCenter.Application.UseCases.Student.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduCenter.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public StudentController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateStudnetAsync(StudentDto model)
        {
            var command = new CreateStudentCommand
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Role = model.Role,
                Gender = model.Gender,

            };

            await _mediatr.Send(command);

            return Ok("Yaratildi");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllStudentAsync()
        {
            var student = await _mediatr.Send(new GetAllStudentCommand());
            return Ok(student);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteById(int Id)
        {
            var command = new DeleteStudentCommand
            {
                StudentId = Id
            };
            bool result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateStudentAsync(StudentDto model)
        {
            var student = new UpdateStudentCommand()
            {

                StudentId = model.StudentId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                Role = model.Role,
            };

            await _mediatr.Send(student);

            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetStudentByIdAsync(int Id)
        {
            var res = await _mediatr.Send(new GetStudentByIdCommand { StudentId = Id });
            return Ok(res);
        }
    }
}
