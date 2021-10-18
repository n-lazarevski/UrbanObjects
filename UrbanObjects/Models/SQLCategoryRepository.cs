using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.Models
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public SQLCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Category Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public Category Delete(int Id)
        {
            Category category = context.Categories.Find(Id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return category;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return context.Categories;
        }

        public Category GetCategory(int Id)
        {
            return context.Categories.Find(Id);
        }

        public Category Update(Category categoryChanges)
        {
            var category = context.Categories.Attach(categoryChanges);
            category.State = EntityState.Modified;
            context.SaveChanges();
            return categoryChanges;
        }
    }
}
