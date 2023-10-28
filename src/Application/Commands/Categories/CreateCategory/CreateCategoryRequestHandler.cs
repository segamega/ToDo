using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;
using MediatR;

namespace Application.Categories.Commands.CreateCategory;

/// <summary>
/// Обработчик запроса <see cref="CreateCategoryRequest"/>.
/// </summary>
public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryRequestHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, 
        CancellationToken cancellationToken)
    {
        var category = (await _categoryRepository
            .FindAsync(x => x.Name.ToUpper() == request.Name.ToUpper(), cancellationToken))
            .FirstOrDefault();

        if (category != null)
        {
            return new CreateCategoryResponse
            {
                Result = category.Id
            }; 
        }
        
        category = new Domain.Entities.Category {Name = request.Name, ParentCategoryId = request.ParentCategoryId};
        var result = _categoryRepository.Add(category);
        return new CreateCategoryResponse { Result = result };
    }
}