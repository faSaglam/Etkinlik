using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreate.ViewModels;
using Entitites.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Data;

namespace EventUI.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IEventService _eventService;
        public  CityController(ICityService cityService,IEventService eventService)
        {
            _cityService = cityService;
            _eventService = eventService;
        }
        public IActionResult List()
        {
            List<CityListDTO> list = _cityService.GetAll().Select(c=> new CityListDTO()
            {
                Name = c.Name,
                CityID = c.CityID

            }).ToList();
          
            return View(list);
        }
        public IActionResult EventsOfCity(int id)
        {
            List<EventListDTO> list = _eventService.GetByCityID(id).Select(e=>new EventListDTO
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
        public IActionResult CityControl()
        {
            List<CityListDTO> list = _cityService.GetAll().Select(c => new CityListDTO()
            {
                Name = c.Name,
                CityID = c.CityID

            }).ToList();

            return View(list);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult CityCreate()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CityCreate(CityCreateDTO viewModel)
        {
            var data = _cityService.GetSingleCityByName(viewModel.CityName);
            if(data != null)
            {
                ViewBag.ErrorMessage = "Böyle bir şehir zaten mevcut";
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (ModelState.IsValid)
            {
                var city = new City()
                {
                    Name = viewModel.CityName,
                };
                _cityService.Add(city);
                ViewBag.Successful = "Şehir başarıyla oluşturuldu";

            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int CityID)
        {
     
           var city = _cityService.GetSingleCity(CityID);

            return View(city);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(City city) 
        {
            var cityToRemove = city;
       
            _cityService.Delete(cityToRemove);
           
            return RedirectToAction("CityControl");
        }
    }
}
