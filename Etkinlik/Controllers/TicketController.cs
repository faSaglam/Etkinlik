

using Business.Abstract;
using Entities.Concreate;
using Entities.Concreate.ViewModels;
using Entitites.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Tracing;
using System.Security.Claims;

namespace EventUI.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IEventService _eventService;
        private readonly ICityService _cityService;
        private readonly UserManager<User> _userManager;
        public TicketController
            (
            ITicketService ticketService, IEventService eventService,UserManager<User> userManager,ICityService cityService
            )
        {
            _ticketService = ticketService;
            _eventService = eventService;
            _userManager = userManager;
            _cityService = cityService;
        }

        public IActionResult Create(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return View("Error");
            }
            
            TicketCreateDTO ticketCreateDTO = new TicketCreateDTO();
       
            ticketCreateDTO.FirstName = _userManager.FindByIdAsync(userId).Result.FirstName;
            ticketCreateDTO.LastName = _userManager.FindByIdAsync(userId).Result.LastName;
            ticketCreateDTO.EventName = _eventService.GetSingleById(id).Name;
            ticketCreateDTO.EventId = id;
            
            ticketCreateDTO.TicketID = "E"+id.ToString()+":"+ticketCreateDTO.EventName+"|U"+_userManager.FindByIdAsync(userId).Result.Email;
            if (_ticketService.GetSingleById(ticketCreateDTO.TicketID) != null)
            {
                ViewBag.Error = "Sadece bir tane bilet alabilirsin";
                return NoContent();
            }
            ticketCreateDTO.DateTime = _eventService.GetSingleById(id).DateTime;

            
           
            return View(ticketCreateDTO);
        }
        [HttpPost]
        public IActionResult Confirm(int id,string ticketId)
        {
            var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if(userId == null)
            {
                return View("Error");
            }
            var ticket = new Ticket();
            ticket.UserName = userId.ToString();
            ticket.EventID = id;
            ticket.TicketID = ticketId;
            _ticketService.Add(ticket);

            Event ticketEvent = _eventService.GetSingleById(id);
            ticketEvent.LeftTickets = ticketEvent.LeftTickets -1;
            _eventService.Update(ticketEvent);

            return RedirectToAction("List");
        }
        public IActionResult List()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var ticketList = _ticketService.GetAll().Where(t=>t.UserName == userId).ToList();
            List<TicketListDTO> list = _ticketService.GetAll().Where(t=>t.UserName == userId)
                .Select(t=>new TicketListDTO
                {
                    TicketID = t.TicketID,  
                    DateTime = _eventService.GetSingleById(t.EventID).DateTime,
                    EventName = _eventService.GetSingleById(t.EventID).Name,
                    CityID = _eventService.GetSingleById(t.EventID).CityID,
                    CityName = _cityService.GetSingleCity(_eventService.GetSingleById(t.EventID).CityID).Name
                 


        }).ToList();
          
            
        
           
            return View(list);

        }
        public IActionResult Delete(string id)
        {
            var ticket = _ticketService.GetSingleById(id);

            _ticketService.Delete(ticket);
            Event currentEvent= _eventService.GetSingleById(ticket.EventID);
            currentEvent.LeftTickets = currentEvent.LeftTickets + 1;
            _eventService.Update(currentEvent);
            

            return RedirectToAction("List");    
        }

        public IActionResult TicketControl()
        {
      
            return View();

        }
        [HttpPost]
        public IActionResult TicketControl(int EventId, string UserName)
        {
            if(_eventService.GetSingleById(EventId) == null)
            {
                ViewBag.Info = "Etkinlik Mevcut Değil";
                return View();
              
            }
            var eventName = _eventService.GetSingleById(EventId).Name;

            //"E" + id.ToString() + ":" + ticketCreateDTO.EventName + "|U" + _userManager.FindByIdAsync(userId).Result.Email;
            var ticketId = "E"+EventId.ToString()+":"+eventName+"|U"+UserName;
            var ticketIsExist = _ticketService.GetSingleById(ticketId);
            if (ticketIsExist == null)
            {
                ViewBag.Info = "Bilet mevcut değil!";
            }
            else
            {
                ViewBag.Info = "Bilet onaylandı";
            }
            return View();

        }

    }

}
