using CoreServices.Models;
using CoreServices.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        BlogDBContext db;
        public CategoryRepository(BlogDBContext _db)
        {
            db = _db;
        }

        public async Task<List<Category>> GetCategories()
        {
            if (db != null)
            {
                return await db.Category.ToListAsync();
            }

            return null;
        }

        public async Task<CategoryViewModel> GetCategory(int? Id)
        {
            if (db != null)
            {
                return await (from c in db.Category
                              where c.Id == Id
                              select new CategoryViewModel
                              {
                                  Name = c.Name,
                                  Slug = c.Slug
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

    }
}
