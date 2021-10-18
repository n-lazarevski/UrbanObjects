using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.Models
{
    public interface ISubcategoryRepository
    {
        IEnumerable<Subcategory> GetAllSubcategories();
        IEnumerable<Subcategory> GetSubcategoriesFromCategory(int categoryId);
        Subcategory GetSubcategory(int subcategoryId);
        Subcategory Delete(int Id);
    }
}
