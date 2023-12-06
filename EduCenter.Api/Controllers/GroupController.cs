using EduCenter.Api.ViewModels;
using EduCenter.Application.UseCases.Group.Commands;
using EduCenter.Application.UseCases.Group.Queries;
using EduCenter.Application.UseCases.School.Queries;
using EduCenter.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EduCenter.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMemoryCache _memoryCache;
        public GroupController(IMediator mediatr, IMemoryCache memoryCache)
        {
            _mediatr = mediatr;
            _memoryCache = memoryCache;
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
            var value = _memoryCache.Get("key");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "key",
                    value: await _mediatr.Send(new GetAllGroupCommand()));
            }
            return Ok(_memoryCache.Get("key") as List<Group>);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteByIdAsync(int Id)
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
