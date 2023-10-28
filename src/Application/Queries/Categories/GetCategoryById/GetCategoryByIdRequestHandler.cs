using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdRequestHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdRequestHandler(
            IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);

            if (category == null)
            {
                // Можно выбросить исключение, если запись с указанным Id не найдена.
                throw new Exception("Запись не найдена");
            }

            return new GetCategoryByIdResponse
            {
                Result = _mapper.Map<CategoryDto>(category)
            };
        }
    }
}
