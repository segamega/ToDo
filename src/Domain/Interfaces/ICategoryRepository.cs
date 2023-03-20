using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для управлением категориями.
    /// </summary>
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
