using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sport.Api.ViewModel;
using Sport.DataApplication.UseCases.Orders.Commands;
using Sport.DataApplication.UseCases.Orders.Queries;
using Sport.Domain.Entities;

namespace Sport.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly IMemoryCache _memoryCache;
        public OrderController(IMediator mediatr, IMemoryCache memoryCache)
        {
            _mediatr = mediatr;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateOrderAsync(OrderDto model)
        {
            var command = new CreatOrderCommand
            {
                Status = model.Status,
                PlayerId = model.PlayerId,


            };

            await _mediatr.Send(command);

            return Ok("Yaratildi");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async ValueTask<IActionResult> GetAllOrderAsync()
        {
            var value = _memoryCache.Get("Id");
            if (value == null)
            {
                _memoryCache.Set(
                    key: "Id",
                    value: await _mediatr.Send(new GetAllOrderCommand()));
            }
            return Ok(_memoryCache.Get("Id") as List<Order>);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteByIdAsync(int Id)
        {
            var command = new DeleteOrderCommand
            {
                Id = Id
            };
            bool result = await _mediatr.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateOrderAsync(OrderDto model)
        {
            var group = new UpdateOrderCommand()
            {

                Id = model.Id,
                Status = model.Status,
                PlayerId = model.PlayerId,
            };

            await _mediatr.Send(group);

            return Ok("Updated");
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetOrderByIdAsync(int Id)
        {
            var res = await _mediatr.Send(new GetOrderByIdCommand { Id = Id });
            return Ok(res);
        }
    }
}
