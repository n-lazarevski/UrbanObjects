using Microsoft.AspNetCore.Http; 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.ViewModels
{
    public class CreateSubcategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required(ErrorMessage = "Attach a document")]
        [Display(Name = "Description document")]
        public IFormFile FilePath { get; set; }
    }
}
