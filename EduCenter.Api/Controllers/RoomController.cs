using EduCenter.Api.ViewModels;
using EduCenter.Application.UseCases.Room.Commands;
using EduCenter.Application.UseCases.Room.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduCenter.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public RoomController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateRoomAsync(RoomDto model)
        {
            var command = new CreateRoomCommand
            {
                RoomNumber = model.RoomNumber,
                SeatCount = model.SeatCount,

            };

            await _mediatr.Send(command);

            return Ok("Yaratildi");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllRoomAsync()
        {
            var room = await _mediatr.Send(new GetAllRoomCommand());
            return Ok(room);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteById(int Id)
        {
            var command = new DeleteRoomCommand
            {
                Id = Id
            };
            bool result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateRoomAsync(RoomDto model)
        {
            var room = new UpdateRoomCommand()
            {
                RoomNumber = model.RoomNumber,
                SeatCount = model.SeatCount,
            };

            await _mediatr.Send(room);

            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetRoomByIdAsync(int Id)
        {
            var res = await _mediatr.Send(new GetRoomByIdCommand { Id = Id });
            return Ok(res);
        }
    }
}
