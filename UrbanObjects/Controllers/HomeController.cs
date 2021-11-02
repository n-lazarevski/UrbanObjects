using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UrbanObjects.Models;
using UrbanObjects.ViewModels;

namespace UrbanObjects.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryRepository categoryRepository;
        private readonly ISubcategoryRepository subcategoryRepository;
        private readonly IPhotoRepository photoRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(ICategoryRepository categoryRepository, 
                              ISubcategoryRepository subcategoryRepository,
                              IPhotoRepository photoRepository,
                              IWebHostEnvironment hostingEnvironment,
                              ILogger<HomeController> logger)
        {
            _logger = logger;
            this.categoryRepository = categoryRepository;
            this.subcategoryRepository = subcategoryRepository;
            this.photoRepository = photoRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                categoriesCount = categoryRepository.GetAllCategories().Count(),
                subcategoriesCount = subcategoryRepository.GetAllSubcategories().Count(),
                photosCount = photoRepository.GetAllPhotos().Count()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Categories()
        {
            var model = categoryRepository.GetAllCategories();
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateCategory(CreateCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Subcategories = new List<Subcategory>()
                };

                categoryRepository.Add(category);
                return RedirectToAction("Categories");
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteCategory(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Categories");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = categoryRepository.GetCategory(id);
            category.Subcategories = subcategoryRepository.GetSubcategoriesFromCategory(id).ToList();
            if (category == null)
            {
                Response.StatusCode = 404;
                return View("CategoryNotFound", id);
            }

            return View(category);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddSubcategory(int categoryId)
        {
            CreateSubcategoryViewModel model = new CreateSubcategoryViewModel
            {
                CategoryId = categoryId
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddSubcategory(CreateSubcategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = ProcessUploadedFile(model.FilePath, "documents");
                
                var category = categoryRepository.GetCategory(model.CategoryId);
                var subcategory = new Subcategory
                {
                    Name = model.Name,
                    Description = model.Description,
                    FilePath = fileName
                };

                category.Subcategories.Add(subcategory);
                categoryRepository.Update(category);
                return RedirectToAction("Details", new { id = model.CategoryId });
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteSubcategory(int id)
        {
            int categoryId = subcategoryRepository.GetSubcategory(id).CategoryId;
            subcategoryRepository.Delete(id);
            return RedirectToAction("Details", new { id = categoryId });
        }

        [HttpGet]
        public IActionResult Images(int subcategoryId)
        {
            ViewImagesViewModel model = new ViewImagesViewModel
            {
                subcategory = subcategoryRepository.GetSubcategory(subcategoryId),
                photos = photoRepository.GetPhotosFromSubcategory(subcategoryId).ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult AddImages(int subcategoryId)
        {
            AddImagesViewModel model = new AddImagesViewModel
            {
                SubcategoryId = subcategoryId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddImages(AddImagesViewModel model)
        {
            if(ModelState.IsValid)
            {
                List<Photo> newPhotos = new List<Photo>();
                foreach(IFormFile photo in model.NewPhotos)
                {
                    newPhotos.Add(new Photo
                    {
                        SubcategoryId = model.SubcategoryId,
                        PhotoPath = ProcessUploadedFile(photo, "images")
                    });
                }

                photoRepository.AddPhotos(newPhotos);
                return RedirectToAction("Images", new { subcategoryId = model.SubcategoryId });
            }
            return View(model);
        }

        private string ProcessUploadedFile(IFormFile formFile, string folder)
        {
            string fileName = null;
            if (formFile != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, folder);
                fileName = formFile.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                formFile.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
