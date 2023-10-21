using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Categories.Queries.GetCategoryList;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Threading;
using Application.Categories.Queries.GetCategoryById;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CategoryController"/>.
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryListResponse))]
        public async Task<IActionResult> GetCategoriesAsync(
            [FromQuery] GetCategoryListRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }

        /// <summary>
        /// Получение категории по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Категория.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var request = new GetCategoryByIdRequest { Id = id };
            var category = await _mediator.Send(request);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
    }
}
