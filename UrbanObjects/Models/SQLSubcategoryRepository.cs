using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.Models
{
    public class SQLSubcategoryRepository : ISubcategoryRepository
    {
        private readonly AppDbContext context;

        public SQLSubcategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Subcategory Delete(int Id)
        {
            Subcategory subcategory = context.Subcategories.Find(Id);
            if (subcategory != null)
            {
                context.Subcategories.Remove(subcategory);
                context.SaveChanges();
            }
            return subcategory;
        }

        public IEnumerable<Subcategory> GetAllSubcategories()
        {
            return context.Subcategories;
        }

        public IEnumerable<Subcategory> GetSubcategoriesFromCategory(int categoryId)
        {
            return context.Subcategories.Where<Subcategory>(s => s.CategoryId == categoryId);
        }

        public Subcategory GetSubcategory(int subcategoryId)
        {
            return context.Subcategories.Find(subcategoryId);
        }
    }
}
