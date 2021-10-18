using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public List<Photo> Photos { get; set; }
        public int CategoryId { get; set; }

        public Subcategory()
        {
            Photos = new List<Photo>();
        }
        
    }
}
