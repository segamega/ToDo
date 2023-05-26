using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Categories.Queries.GetCategories;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BlanksController"/>.
        /// </summary>
        /// <param name="mediator">Медиатор.</param>
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получение категорий с фильтрацией по наименованию.
        /// </summary>
        /// <param name="request">Модель данных запроса.</param>
        /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/> 
        /// для отслеживания запросов отмены операции.</param>
        /// <returns>Список категорий.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoriesResponse))]
        public async Task<IActionResult> GetTicketsAsync(
            [FromQuery] GetCategoriesRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
