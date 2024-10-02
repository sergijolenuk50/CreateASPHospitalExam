using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto?> Get(int id);
        Task Edit(EditCategoryDto model);
        Task Create(CreateCategoryDto model);
        Task Delete(int id);
    }
}
