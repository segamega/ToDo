using System.Collections.Generic;

namespace Application.Projects.Queries.GetProjectList;

/// <summary>
/// Ответ на запрос <see cref="GetProjectListRequest"/>.
/// </summary>
public class GetProjectListResponse
{
    /// <summary>
    /// Список проектов.
    /// </summary>
    public  ICollection<ProjectDto> Result { get; set; } = new List<ProjectDto>();
}