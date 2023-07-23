using CoreServices.Models;
using CoreServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<CategoryViewModel> GetCategory(int? Id);
    }
}
