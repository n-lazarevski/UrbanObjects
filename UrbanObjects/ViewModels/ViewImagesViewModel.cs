using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrbanObjects.Models;

namespace UrbanObjects.ViewModels
{
    public class ViewImagesViewModel
    {
        public Subcategory subcategory { get; set; }
        public List<Photo> photos { get; set; }
    }
}
