using Business.Abstract;
using Entitites.Concreate;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Entities.Concreate.ViewModels;
using FluentValidation;
using System;
using FluentValidation.Results;

namespace EventUI.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ICityService _cityService;
        private readonly ICategoryService _categoryService;
      
        public EventController(
            IEventService eventService ,
            ICategoryService categoryService,
            ICityService cityService
           )
        {
            _eventService = eventService;
            _categoryService = categoryService;
            _cityService = cityService;
         
        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult List(string name,string category,string city)
        {
            #region CategoryListForDropBox
            List<CategoryListDTO> categoryList = _categoryService.GetAll().Select(c=>new CategoryListDTO
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
            }).ToList();
            ViewData["category"]=categoryList;
            #endregion

            #region CityListForDropBox
            List<CityListDTO> cityList = _cityService.GetAll().Select(c=>new CityListDTO
            {
                CityID = c.CityID,
                Name = c.Name,
            }).ToList() ;
            ViewData["City"]=cityList;
            #endregion


            #region EventList
            List<EventListDTO> eventList = _eventService.GetAll().Where(e=>e.IsConfirmed == true).Select(
                e => new EventListDTO
                {
                    EvenetID = e.EvenetID,
                    Name = e.Name,
                    Description = e.Description,
                    Quoto = e.Quoto,
                    LeftTickets= e.LeftTickets,
                    DateTime = e.DateTime,
                    CityName = e.City.Name,
                }).ToList();
            #endregion
            #region Search
            if (!String.IsNullOrEmpty(name))
            {
                List<EventListDTO> result = _eventService.GetAll().Where(e=>e.Name.ToLower().Contains(name.ToLower())).Select(
               e => new EventListDTO
             {
               EvenetID = e.EvenetID,
               Name = e.Name,
               Description = e.Description,
               Quoto = e.Quoto,
               DateTime = e.DateTime,
               CityName = e.City.Name,
               }).ToList();
              return View(result);
            }
            #endregion
            #region Filter
            if (!String.IsNullOrEmpty(category)) 
            {
                List<EventListDTO> res = _eventService.GetAll().Where(e=>e.CategoryID.ToString() == category).Select
                    (
                        e => new EventListDTO
                        {
                            EvenetID = e.EvenetID,
                            Name = e.Name,
                            Description = e.Description,
                            Quoto = e.Quoto,
                            DateTime = e.DateTime,
                            CityName = e.City.Name,
                        }
                    ).ToList();
                return View(res);
            }
            if (!String.IsNullOrEmpty(city))
            {
                List<EventListDTO> resCity= _eventService.GetAll().Where(e => e.CityID.ToString() == city).Select
                    (
                        e => new EventListDTO
                        {
                            EvenetID = e.EvenetID,
                            Name = e.Name,
                            Description = e.Description,
                            Quoto = e.Quoto,
                            DateTime = e.DateTime,
                            CityName = e.City.Name,
                        }
                    ).ToList();
                return View(resCity);
            }
            #endregion
            return View(eventList);
        }

        [Authorize(Roles = "User,Admin")]
        public IActionResult Create()
        {
            #region CategoryListForDropBox
            List<CategoryListDTO> categoryList = _categoryService.GetAll().Select(c => new CategoryListDTO
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
            }).ToList();

            ViewData["category"] = categoryList;
            #endregion
            #region CityListForDropBox
            List<CityListDTO> cityList = _cityService.GetAll().Select(c => new CityListDTO
            {
                CityID = c.CityID,
                Name = c.Name,
            }).ToList();

            ViewData["City"] = cityList;
            #endregion


            return View();

        }
        [Authorize(Roles = "User,Admin")]

        [HttpPost]
        public IActionResult Create(EventCreateDTO model)
        
        {
        
            #region CategoryListForDropBox
            List<CategoryListDTO> categoryList = _categoryService.GetAll().Select(c => new CategoryListDTO
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
            }).ToList();

            ViewData["category"] = categoryList;
            #endregion
            #region CityListForDropBox
            List<CityListDTO> cityList = _cityService.GetAll().Select(c => new CityListDTO
            {
                CityID = c.CityID,
                Name = c.Name,
            }).ToList();

            ViewData["City"] = cityList;
            #endregion
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user == null)
            {
                return RedirectToAction("Login","User");
            }

            if(!ModelState.IsValid)
            {
                return View(); 
            }
            TimeSpan timeSpan = model.DateTime - DateTime.Now.AddDays(5);
            if(timeSpan < TimeSpan.Zero)
            {
                ViewBag.Error = "Geçmiş zamanda bir etkinlik oluşturulamaz.En az 5 gün ileri tarihte bir etkinlik oluşturunuz";
                return View();
            }
            if(model.Quoto < 5)
            {
                ViewBag.ErrorQuoto= "Etkinlik en az 5 kişilik olabilir.";
                return View();

            }

            Event eventForSave = new Event
            {
                Name = model.Name,
                CategoryID = model.CategoryID,
                CityID = model.CityID,
                Quoto = model.Quoto,
                DateTime = model.DateTime,
                Description = model.Description,
                Id = user,
                LeftTickets= model.Quoto
            };
           _eventService.Add(eventForSave);
            return RedirectToAction("MyEvents");

        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult MyEvents()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user == null)
            {
                return NoContent();
            }
            List<EvenetsMyEventsListDTO> myEvents = _eventService.GetAll().Where(e => e.Id == user).Select(
                e => new EvenetsMyEventsListDTO
                {
                    EvenetID=e.EvenetID,
                    Name = e.Name,
                    CityName = e.City.Name,
                    DateTime = e.DateTime,
                    Description = e.Description,
                    Quoto =e.Quoto,
                    LeftTickets = e.LeftTickets,
                   
                    Situation = e.IsConfirmed,
                    CategoryName = _categoryService.GetSingleCategory(e.CategoryID).CategoryName
                   


                }).ToList();
            return View(myEvents);  
        }
        [Authorize(Roles = "Admin")]
        public IActionResult EventControl(string name, string category, string city)
        {
            #region CategoryListForDropBox
            List<CategoryListDTO> categoryList = _categoryService.GetAll().Select(c => new CategoryListDTO
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
            }).ToList();
            ViewData["category"] = categoryList;
            #endregion
            #region CityListForDropBox
            List<CityListDTO> cityList = _cityService.GetAll().Select(c => new CityListDTO
            {
                CityID = c.CityID,
                Name = c.Name,
            }).ToList();
            ViewData["City"] = cityList;
            #endregion
            #region EventList
            List<EventControlDTO> eventList = _eventService.GetAll().Select(
                e => new EventControlDTO
                {
                    EvenetID = e.EvenetID,
                    Name = e.Name,
                    Description = e.Description,
                    Quoto = e.Quoto,
                    CategoryName= _categoryService.GetSingleCategory(e.CategoryID).CategoryName,
                    LeftTickets = e.Quoto,
                    DateTime = e.DateTime,
                    CityName = e.City.Name,
                    IsConfirmed = e.IsConfirmed,
                }).ToList();
            #endregion
            #region Search
            if (!String.IsNullOrEmpty(name))
            {
                List<EventControlDTO> result = _eventService.GetAll().Where(e => e.Name.ToLower().Contains(name.ToLower())).Select(
               e => new EventControlDTO
               {
                   EvenetID = e.EvenetID,
                   Name = e.Name,
                   Description = e.Description,
                   Quoto = e.Quoto,
                   CategoryName = _categoryService.GetSingleCategory(e.CategoryID).CategoryName,
                   LeftTickets = e.Quoto,
                   DateTime = e.DateTime,
                   CityName = e.City.Name,
                   IsConfirmed = e.IsConfirmed,
               }).ToList();
                return View(result);
            }
            #endregion
            #region Filter
            if (!String.IsNullOrEmpty(category))
            {
                List<EventControlDTO> res = _eventService.GetAll().Where(e => e.CategoryID.ToString() == category).Select
                    (
                        e => new EventControlDTO
                        {
                            EvenetID = e.EvenetID,
                            Name = e.Name,
                            Description = e.Description,
                            Quoto = e.Quoto,
                            CategoryName = _categoryService.GetSingleCategory(e.CategoryID).CategoryName,
                            LeftTickets = e.Quoto,
                            DateTime = e.DateTime,
                            CityName = e.City.Name,
                            IsConfirmed = e.IsConfirmed,
                        }
                    ).ToList();
                return View(res);
            }
            if (!String.IsNullOrEmpty(city))
            {
                List<EventControlDTO> resCity = _eventService.GetAll().Where(e => e.CityID.ToString() == city).Select
                    (
                        e => new EventControlDTO
                        {
                            EvenetID = e.EvenetID,
                            Name = e.Name,
                            Description = e.Description,
                            Quoto = e.Quoto,
                            LeftTickets = e.Quoto,
                            CategoryName = _categoryService.GetSingleCategory(e.CategoryID).CategoryName,
                            DateTime = e.DateTime,
                            CityName = e.City.Name,
                            IsConfirmed = e.IsConfirmed,
                        }
                    ).ToList();
                return View(resCity);
            }
            #endregion
            return View(eventList);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Confirm(int id)
        {
            Event eventDetail = _eventService.GetSingleById(id);
          
            return View(eventDetail);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Confirm(Event eventToUpdateId)
        {
            var eventToConfirm = _eventService.GetSingleById(eventToUpdateId.EvenetID);

            eventToConfirm.IsConfirmed = true;
             _eventService.Update(eventToConfirm);
            if(eventToConfirm.IsConfirmed == false )
                {
                ViewBag.Event = "Bir hata oluştu";
                return View();
                }
            ViewBag.Event = "Etkinlik onaylandı";
            return RedirectToAction("EventControl");


        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult Delete(int id)
        {
            Event eventDetail = _eventService.GetSingleById(id);
            DateTime fiveDaysLater = DateTime.Now.AddDays(5);
            if(eventDetail.DateTime < fiveDaysLater) 
            {
                TempData["Error"] = "Etkinliğin gerçekleşeceği tarihe 5 günden az kaldığı için müdahele edemezsiniz.";
                return View(eventDetail);
            }
            if(eventDetail == null)
            {
                return RedirectToAction("List");
            }
            return View(eventDetail);
        }
        [Authorize(Roles = "User,Admin")]

        [HttpPost]
        public IActionResult Delete(Event eventToDeleteId)
        {
         
          var eventToDelete = _eventService.GetSingleById(eventToDeleteId.EvenetID);
          if(eventToDelete == null)
            {
                return RedirectToAction("List");
            }
          _eventService.Delete(eventToDelete);  
          return RedirectToAction("List");

        }
        [Authorize(Roles = "User,Admin")]
        public IActionResult Edit(int id)
        {
            List<CategoryListDTO> categoryList = _categoryService.GetAll().Select(c => new CategoryListDTO
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
            }).ToList();
            ViewData["category"] = categoryList;
            List<CityListDTO> cityList = _cityService.GetAll().Select(c => new CityListDTO
            {
                CityID = c.CityID,
                Name = c.Name,
            }).ToList();
            ViewData["City"] = cityList;
            var eventEntry = _eventService.GetSingleById(id);
          
            if (eventEntry == null) { return NoContent(); }
            DateTime fiveDaysLater = DateTime.Now.AddDays(5);
            if (eventEntry.DateTime < fiveDaysLater)
            {
                TempData["Error"] = "Etkinliğin gerçekleşeceği tarihe 5 günden az kaldığı için müdahele edemezsiniz.";
                return RedirectToAction("MyEvents");
            }

            return View(eventEntry);
            
        }
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public IActionResult Edit(
        int id,
        string Name,
        string Description , 
        DateTime DateTime , 
        int CityID , 
        int Quoto , 
        int CategoryID,
        int LeftTickets)
        
        {
            List<CategoryListDTO> categoryList = _categoryService.GetAll().Select(c => new CategoryListDTO
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName,
            }).ToList();
            ViewData["category"] = categoryList;
            List<CityListDTO> cityList = _cityService.GetAll().Select(c => new CityListDTO
            {
                CityID = c.CityID,
                Name = c.Name,
            }).ToList();
            ViewData["City"] = cityList;


            var eventToUpdate = _eventService.GetSingleById(id); 
            if(eventToUpdate == null)
            {
                return NoContent();
            }
            eventToUpdate.EvenetID = eventToUpdate.EvenetID;
            eventToUpdate.Name = Name;
            eventToUpdate.Description = Description;
            TimeSpan timeSpan = DateTime - DateTime.Now;
            if (timeSpan < TimeSpan.Zero)
            {
                ViewBag.TimeSpan = "Güncellenen tarih geçmiş tarihli olamaz";
                return NoContent();
            }

            eventToUpdate.DateTime = DateTime;
            eventToUpdate.CityID = CityID;  
         
            eventToUpdate.CategoryID = CategoryID;
            if(CityID == 0 || CategoryID == 0)
            {
                ViewBag.Error = "Lütfen şehir ve kategori seçiniz";
                return View();
            }
            if (Quoto < eventToUpdate.LeftTickets)
            {
                ViewBag.Error = "Yeni kişi sayısı satılan biletlerden az olamaz.";
                return View();
            }
            eventToUpdate.LeftTickets = Quoto - (eventToUpdate.Quoto - LeftTickets);
            eventToUpdate.Quoto = Quoto;
            _eventService.Update(eventToUpdate);
            return RedirectToAction("List");


        }



    }
 
}
