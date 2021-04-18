using System.Threading.Tasks;
using BookLibrary.Application.Books.Commands.OrderBook;
using BookLibrary.Application.Books.Queries.GetBooksList;
using BookLibrary.Application.Books.Queries.GetOrdersList;
using BookLibrary.Application.Users.Queries.GetUsersList;
using BookLibrary.Domain.Entities.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<BookDto>> GetAll([FromQuery] GetBooksListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        
        [HttpGet("Orders")]
        public async Task<ActionResult<OrderDto>> GetAllOrders([FromQuery] GetOrdersListQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        
        [HttpPost("Orders")]
        public async Task<ActionResult<BookDto>> OrderBook([FromBody] OrderBookCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}