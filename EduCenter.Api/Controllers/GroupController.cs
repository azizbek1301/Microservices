using EduCenter.Api.ViewModels;
using EduCenter.Application.UseCases.Group.Commands;
using EduCenter.Application.UseCases.Group.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduCenter.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public GroupController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateGroupAsync(GroupDto model)
        {
            var command = new CreateGroupCommand
            {
                ClassNumber = model.ClassNumber,
                StudentCount = model.StudentCount,
                SchoolId = model.SchoolId,

            };

            await _mediatr.Send(command);

            return Ok("Yaratildi");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllGroupAsync()
        {
            var group = await _mediatr.Send(new GetAllGroupCommand());
            return Ok(group);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteById(int Id)
        {
            var command = new DeleteGroupCommand
            {
                Id = Id
            };
            bool result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateGroupAsync(GroupDto model)
        {
            var group = new UpdateGroupCommand()
            {

                Id = model.Id,
                ClassNumber = model.ClassNumber,
                StudentCount = model.StudentCount,
                SchoolId = model.SchoolId,
            };

            await _mediatr.Send(group);

            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetGroupByIdAsync(int Id)
        {
            var res = await _mediatr.Send(new GetGroupByIdCommand { Id = Id });
            return Ok(res);
        }
    }
}
