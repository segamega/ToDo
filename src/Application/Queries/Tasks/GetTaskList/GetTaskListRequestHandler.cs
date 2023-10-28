using Application.Common.Extensions;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Tasks.Queries.GetTaskList
{
    /// <summary>
    /// Обработчик запроса <see cref="GetTaskListRequest"/>.
    /// </summary>
    public class GetTaskListRequestHandler : IRequestHandler<GetTaskListRequest, GetTaskListResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GetTaskListRequestHandler"/>.
        /// </summary>
        public GetTaskListRequestHandler(
            IMapper mapper,
            ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }

        /// <inheritdoc />
        public async Task<GetTaskListResponse> Handle(GetTaskListRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Task, bool>> expr = FilterByRequest(request);

            var taskList = await _taskRepository.FindAsync(expr, cancellationToken);

            return new GetTaskListResponse
            {
                Result = _mapper.Map<TaskDto[]>(taskList)
            };
        }

        private static Expression<Func<Domain.Entities.Task, bool>> FilterByRequest(GetTaskListRequest request)
        {
            var expr = PredicateBuilder.True<Domain.Entities.Task>();

            if (request.Title != null)
            {
                expr = expr.And(x => x.Title.ToUpper().Contains(request.Title.ToUpper()));
            }

            if (request.Description != null)
            {
                expr = expr.And(x => x.Description.ToUpper().Contains(request.Description.ToUpper()));
            }

            if (request.CreatedDateFrom.HasValue)
            {
                expr = expr.And(x => x.CreatedDate.Date >= request.CreatedDateFrom.Value.Date);
            }

            if (request.CreatedDateTo.HasValue)
            {
                expr = expr.And(x => x.CreatedDate.Date <= request.CreatedDateTo.Value.Date);
            }

            if (request.UpdatedDateFrom.HasValue)
            {
                expr = expr.And(x => x.UpdatedDate.HasValue 
                                    && x.UpdatedDate.Value.Date >= request.UpdatedDateFrom.Value.Date);
            }

            if (request.UpdatedDateTo.HasValue)
            {
                expr = expr.And(x => x.UpdatedDate.HasValue
                                    && x.UpdatedDate.Value.Date <= request.UpdatedDateTo.Value.Date);
            }

            if (request.DueDateFrom.HasValue)
            {
                expr = expr.And(x => x.DueDate.HasValue
                                    && x.DueDate.Value.Date >= request.DueDateFrom.Value.Date);
            }

            if (request.DueDateTo.HasValue)
            {
                expr = expr.And(x => x.DueDate.HasValue
                                    && x.DueDate.Value.Date <= request.DueDateTo.Value.Date);
            }

            if (request.PriorityType.HasValue)
            {
                expr = expr.And(x => x.PriorityType.Equals(request.PriorityType.Value));
            }

            return expr;
        }
    }
}