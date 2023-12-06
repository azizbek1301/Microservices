using EduCenter.Api.ViewModels;
using EduCenter.Application.UseCases.School.Commands;
using EduCenter.Application.UseCases.School.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduCenter.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public SchoolController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateSchoolAsync(SchoolDto model)
        {
            var command = new CreateSchoolCommand
            {
                Name = model.Name,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.Phone_Number

            };

            await _mediatr.Send(command);

            return Ok("Yaratildi");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllSchoolAsync()
        {
            var school = await _mediatr.Send(new GetSchoolCommand());
            return Ok(school);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteById(int Id)
        {
            var command=new DeleteSchoolCommand
            {
                Id= Id
            };
            bool result=await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateSchoolAsync(SchoolDto model)
        {
            UpdateSchoolCommand school = new UpdateSchoolCommand()
            {
                Id = model.Id,
                Name= model.Name,
                Address= model.Address,
                Email= model.Email,
                PhoneNumber= model.Phone_Number
            };

            await _mediatr.Send(school);

            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetSchoolByIdAsync(int Id)
        {
            var res= await _mediatr.Send(new GetSchoolByIdCommand { Id = Id });
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetSchoolInfoAsync()
        {
            var school = await _mediatr.Send(new GetSchoolInfoCommand());
            return Ok(school);
        }
    }
}
