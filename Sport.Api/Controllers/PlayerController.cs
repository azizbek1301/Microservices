using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sport.Api.ViewModel;
using Sport.DataApplication.UseCases.Players.Commands;
using Sport.DataApplication.UseCases.Players.Queries;
using Sport.Domain.Entities;

namespace Sport.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMemoryCache _memoryCache;
        public PlayerController(IMediator mediatr, IMemoryCache memoryCache)
        {
            _mediatr = mediatr;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreatePlayerAsync(PlayerDto model)
        {
            var command = new CreatePlayerCommand
            {
                Name= model.Name,
                Age= model.Age,
                TeamId= model.TeamId,
         

            };

            await _mediatr.Send(command);

            return Ok("Yaratildi");
        }

        [HttpGet]

        public async ValueTask<IActionResult> GetAllPlayerAsync()
        {
            var value = _memoryCache.Get("Id");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Id",
                    value: await _mediatr.Send(new GetAllPlayerCommand()));
            }
            return Ok(_memoryCache.Get("Id") as List<Player>);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteByIdAsync(int Id)
        {
            var command = new DeletePlayerCommand
            {
                Id = Id
            };
            bool result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdatePlayerAsync(PlayerDto model)
        {
            var group = new UpdatePlayerCommand()
            {

                Id = model.Id,
                Name = model.Name,
                Age = model.Age,
                TeamId = model.TeamId,
            };

            await _mediatr.Send(group);

            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetPlayerByIdAsync(int Id)
        {
            var res = await _mediatr.Send(new GetPlayerByIdCommand { Id = Id });
            return Ok(res);
        }
    }
}
