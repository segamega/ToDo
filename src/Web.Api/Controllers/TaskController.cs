using System.Threading;
using System.Threading.Tasks;
using Application.Tasks.Queries.GetTaskList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="TaskController"/>.
    /// </summary>
    /// <param name="mediator">Медиатор.</param>
    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получение списка задач с фильтрацией по наименованию.
    /// </summary>
    /// <param name="request">Модель данных запроса.</param>
    /// <param name="cancellationToken">Экземпляр <see cref="CancellationToken"/> 
    /// для отслеживания запросов отмены операции.</param>
    /// <returns>Список задач.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTaskListResponse))]
    public async Task<IActionResult> GetTaskListAsync(GetTaskListRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}