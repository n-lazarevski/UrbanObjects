using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanObjects.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        public string Name { get; set; }

    }
}
