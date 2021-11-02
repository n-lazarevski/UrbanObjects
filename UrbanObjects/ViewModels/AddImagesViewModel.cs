using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.ViewModels
{
    public class AddImagesViewModel
    {
        public int SubcategoryId { get; set; }

        [Required]
        public List<IFormFile> NewPhotos { get; set; }
    }
}
