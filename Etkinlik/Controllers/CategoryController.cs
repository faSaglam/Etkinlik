using Business.Abstract;
using Entities.Concreate.ViewModels;
using Entitites.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;

namespace EventUI.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class CategoryController : Controller
    {
      
        private readonly ICategoryService _categoryService;
        private readonly IEventService _eventService;
        public CategoryController(ICategoryService categoryService, IEventService eventService)
        {
            _categoryService = categoryService;
            _eventService = eventService;
        }

        public IActionResult List()
        {
            List<CategoryListDTO> list = _categoryService.GetAll().Select(c=>new CategoryListDTO()
            {
                CategoryName=c.CategoryName,
                CategoryID =c.CategoryID,
            }).ToList();
            return View(list);
            
        }
        public IActionResult EventsOfCategories(int id)
        {
            List<EventListDTO> list = _eventService.GetByCategoryID(id).Select(e=>new EventListDTO
            {
                EvenetID = e.EvenetID,
                Name = e.Name,
                Description = e.Description,
                Quoto = e.Quoto,
                DateTime = e.DateTime,
                CityName = e.City.Name,
            }).ToList();
           
            return View(list);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult CategoryControl()
        {
            List<CategoryListDTO> list = _categoryService.GetAll().Select(c => new CategoryListDTO()
            {
                CategoryName = c.CategoryName,
                CategoryID = c.CategoryID,
                

            }).ToList();

            return View(list);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CategoryCreate(CategoryCreateDTO viewModel)
        {
            var data = _categoryService.GetSingleCategory(viewModel.CategoryName);
            if (data != null)
            {
                ViewBag.ErrorMessage = "Böyle bir kategori zaten mevcut";
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    CategoryName = viewModel.CategoryName,
                };
                _categoryService.Add(category);
                ViewBag.Successful = "Kategori başarıyla oluşturuldu";

            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int CategoryID)
        {
          
            var category = _categoryService.GetSingleCategory(CategoryID);
            if (category != null)
            {
                return RedirectToAction("CategoryControl");
            }

            return View(category);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            var categoryToRemove = category;

            _categoryService.Delete(categoryToRemove);

            return RedirectToAction("CategoryControl");
        }
    }
}
