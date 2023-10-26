using System.Threading;
using System.Threading.Tasks;
using Application.Categories.Commands.CreateCategory;
using Application.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
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
        /// Добавление категории.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
