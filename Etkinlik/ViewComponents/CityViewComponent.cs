using Business.Abstract;
using Entities.Concreate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EventUI.ViewComponents
{
    public class CityViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly ICityService _cityService;
        public CityViewComponent(ICityService cityService)
        {
            _cityService = cityService;
        }
        public IViewComponentResult Invoke()
        {
            IEnumerable<CityListDTO> cityList = _cityService.GetAll().Select(c => new CityListDTO()
            {
              CityID=c.CityID,
              Name=c.Name,
            }).ToList();
            return View(cityList);

        }
    }
}
