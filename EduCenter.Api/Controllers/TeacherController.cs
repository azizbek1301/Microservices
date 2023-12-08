using EduCenter.Api.ViewModels;
using EduCenter.Application.UseCases.Teacher.Commands;
using EduCenter.Application.UseCases.Teacher.Queries;
using EduCenter.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EduCenter.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMemoryCache _memoryCache;

        public TeacherController(IMediator mediatr, IMemoryCache memoryCache)
        {
            _mediatr = mediatr;
            _memoryCache = memoryCache;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateTeacherAsync(TeacherDto model)
        {
            var command = new CreatTeacherCommand
            {
                Name = model.Name,
                LastName = model.LastName,
                Phone = model.Phone,
                Role = model.Role,
                SchoolId = model.SchoolId,

            };

            await _mediatr.Send(command);

            return Ok("Yaratildi");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllTeacherAsync()
        {
            var teacher = await _mediatr.Send(new GetAllTeacherCommand());
            return Ok(teacher);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteById(int Id)
        {
            var command = new DeleteTeacherComman
            {
                TeacherId = Id
            };
            bool result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateTeacherAsync(TeacherDto model)
        {
            var teacher = new UpdateTeacherCommand()
            {

                TeacherId = model.TeacherId,
                LastName = model.LastName,
                Name = model.Name,
                SchoolId = model.SchoolId,
                Role = model.Role,
                Phone = model.Phone
            };

            await _mediatr.Send(teacher);

            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetTeacherByIdAsync(int Id)
        {
            var res = await _mediatr.Send(new GetTeacherByIdCommand { TeacherId = Id });
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetTeacherInfoAsync()
        {
            var value = _memoryCache.Get("Id");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Id",
                    value: await _mediatr.Send(new GetTeacherInfoCommand()));
            }
            return Ok(_memoryCache.Get("Id") as List<Teacher>);
        }
    }
}
