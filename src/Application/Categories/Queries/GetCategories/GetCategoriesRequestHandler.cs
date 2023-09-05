using Application.Common.Extensions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategories
{
    /// <summary>
    /// Обработчик запроса <see cref="GetCategoriesRequest"/>.
    /// </summary>
    public class GetCategoriesRequestHandler : IRequestHandler<GetCategoriesRequest, GetCategoriesResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GetCategoriesRequestHandler"/>.
        /// </summary>
        public GetCategoriesRequestHandler(
            IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        /// <inheritdoc />
        public async Task<GetCategoriesResponse> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var expr = PredicateBuilder.True<Category>();

            if (request.Name != null)
            {
                expr = expr.And(x => x.Name.ToUpper().Contains(request.Name.ToUpper()));
            }

            var categoryList = await _categoryRepository.FindAsync(expr, cancellationToken);

            return new GetCategoriesResponse
            {
                Result = _mapper.Map<CategoryDto[]>(categoryList)
            };
        }
    }
}
