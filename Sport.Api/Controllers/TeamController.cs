using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sport.Api.ViewModel;
using Sport.DataApplication.UseCases.Teams.Commands;
using Sport.DataApplication.UseCases.Teams.Queries;
using Sport.Domain.Entities;

namespace Sport.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMemoryCache _memoryCache;
        public TeamController(IMediator mediatr, IMemoryCache memoryCache)
        {
            _mediatr = mediatr;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateTeamAsync(TeamDto model)
        {
            var command = new CreateTeamCommand
            {
                Name = model.Name,


            };

            await _mediatr.Send(command);

            return Ok("Yaratildi");
        }

        [HttpGet]

        public async ValueTask<IActionResult> GetAllTeamAsync()
        {
            var value = _memoryCache.Get("Id");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Id",
                    value: await _mediatr.Send(new GetAllTeamCommand()));
            }
            return Ok(_memoryCache.Get("Id") as List<Team>);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteByIdAsync(int Id)
        {
            var command = new DeleteTeamCommand
            {
                Id = Id
            };
            bool result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateTeamAsync(TeamDto model)
        {
            var group = new UpdateTeamCommand()
            {

                Id = model.Id,
                Name = model.Name,

            };

            await _mediatr.Send(group);

            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetTeamByIdAsync(int Id)
        {
            var res = await _mediatr.Send(new GetTeamByIdCommand { Id = Id });
            return Ok(res);
        }
    }
}
