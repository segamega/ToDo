using Application.Common.Extensions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryList
{
    /// <summary>
    /// Обработчик запроса <see cref="GetCategoryListRequest"/>.
    /// </summary>
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, GetCategoryListResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GetCategoryListRequestHandler"/>.
        /// </summary>
        public GetCategoryListRequestHandler(
            IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        /// <inheritdoc />
        public async Task<GetCategoryListResponse> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var expr = PredicateBuilder.True<Category>();

            if (request.Name != null)
            {
                expr = expr.And(x => x.Name.ToUpper().Contains(request.Name.ToUpper()));
            }

            var categoryList = await _categoryRepository.FindAsync(expr, cancellationToken);

            return new GetCategoryListResponse
            {
                Result = _mapper.Map<CategoryDto[]>(categoryList)
            };
        }
    }
}
