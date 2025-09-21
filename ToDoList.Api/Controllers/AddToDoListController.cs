using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ToDoList.Application.ToDoList.AddToDoList;
using ToDoList.Application.ToDoList.DeleteToDoList;
using ToDoList.Application.ToDoList.GetAllToDoList;
using ToDoList.Application.ToDoList.GetToDoList;

namespace ToDoList.Api.Controllers.Commands
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly ISender _sender;

        public ToDoListController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IEnumerable<GetToDoListResponse>> GetAllAsync()
        {
            return await _sender.Send(new GetAllToDoListQuery());
        }

        [HttpGet("{id}")]
        public async Task<GetToDoListResponse> GetAsync(Guid id)
        {
            return await _sender.Send(new GetToDoListQuery(id));
        }

        [HttpPost]
        public async Task<Guid> AddAsync([FromBody] AddToDoListRequest request)
        {
            return await _sender.Send(new AddToDoListCommand(request.Title, request.Description, DateTime.Now.AddDays(request.RemainDate)));

        }

        [HttpDelete]
        public async Task<OkResult> DeleteAsync(string id)
        {
            await _sender.Send(new DeleteToDoListCommand(id));

            return Ok();
        }
    }
}
