using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public int SubcategoryId { get; set; }
    }
}
