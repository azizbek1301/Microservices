using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sport.Api.ViewModel;
using Sport.DataApplication.UseCases.Coaches.Commands;
using Sport.DataApplication.UseCases.Coaches.Queries;
using Sport.Domain.Entities;

namespace Sport.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="User")]
    public class CoachController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMemoryCache _memoryCache;
        public CoachController(IMediator mediatr, IMemoryCache memoryCache)
        {
            _mediatr = mediatr;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateCoachAsync(CoachDto model)
        {
            var command = new CreateCoachCommand
            {
                Name = model.Name,
                Salary = model.Salary,
                TeamId = model.TeamId,

            };

            await _mediatr.Send(command);

            return Ok("Yaratildi");
        }

        [HttpGet]

        public async ValueTask<IActionResult> GetAllCoachAsync()
        {
            var value = _memoryCache.Get("Id");
            if (value == null)
            {
                var coches = await _mediatr.Send(new GetAllCoachCommand());
                _memoryCache.Set(
                    key: "Id",
                    value: coches );
            }
            return Ok(_memoryCache.Get("Id") as List<Coach>);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteByIdAsync(int Id)
        {
            var command = new DeleteCoachCommand
            {
                Id = Id
            };
            bool result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateCoachAsync(Coach model)
        {
            var group = new UpdateCoachCommand()
            {

                Id = model.Id,
                Name = model.Name,
                Salary = model.Salary,
                TeamId = model.TeamId,
            };

            await _mediatr.Send(group);

            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetCoachByIdAsync(int Id)
        {
            var res = await _mediatr.Send(new GetCouchByIdCommand { Id = Id });
            return Ok(res);
        }
    }
}
