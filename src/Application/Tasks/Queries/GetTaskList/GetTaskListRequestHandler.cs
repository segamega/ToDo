using Application.Categories.Queries.GetCategories;
using Application.Common.Extensions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

            return expr;
        }
    }
}