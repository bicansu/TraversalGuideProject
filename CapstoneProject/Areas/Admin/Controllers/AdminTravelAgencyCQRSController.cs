using CapstoneProject.CQRS.Commands.TravelAgencyCommands;
using CapstoneProject.CQRS.Handlers.TravelAgencyHandlers;
using CapstoneProject.CQRS.Queries.TravelAgencyQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminTravelAgencyCQRSController : Controller
    {
        private readonly GetAllTravelAgencyQueryHandler _getAllTravelAgencyQueryHandler;
        private readonly GetTravelAgencyByIDQueryHandler _getTravelAgencyByIDQueryHandler;
        private readonly CreateTravelAgencyCommandHandler _createTravelAgencyCommandHandler;
        private readonly RemoveTravelAgencyCommandHandler _removeTravelAgencyCommandHandler;
        private readonly UpdateTravelAgencyCommandHandler _updateTravelAgencyCommandHandler;
        public AdminTravelAgencyCQRSController(GetAllTravelAgencyQueryHandler getAllTravelAgencyQueryHandler, GetTravelAgencyByIDQueryHandler getTravelAgencyByIDQueryHandler, CreateTravelAgencyCommandHandler createTravelAgencyCommandHandler, RemoveTravelAgencyCommandHandler removeTravelAgencyCommandHandler, UpdateTravelAgencyCommandHandler updateTravelAgencyCommandHandler)
        {
            _getAllTravelAgencyQueryHandler = getAllTravelAgencyQueryHandler;
            _getTravelAgencyByIDQueryHandler = getTravelAgencyByIDQueryHandler;
            _createTravelAgencyCommandHandler = createTravelAgencyCommandHandler;
            _removeTravelAgencyCommandHandler = removeTravelAgencyCommandHandler;
            _updateTravelAgencyCommandHandler = updateTravelAgencyCommandHandler;
        }
        [Route("Admin/AdminTravelAgencyCQRS/Index")]
        public IActionResult Index()
        {
            var values = _getAllTravelAgencyQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]

        [Route("Admin/AdminTravelAgencyCQRS/GetTravelAgency")]
        public IActionResult GetTravelAgency(int id)
        {
            var values = _getTravelAgencyByIDQueryHandler.Handle(new GetTravelAgencyByIDQuery(id));
            ViewBag.resim = values.Image;
            return View(values);
        }
        [HttpPost]

        public IActionResult GetTravelAgency(UpdateTravelAgencyCommand command)
        {
            _updateTravelAgencyCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        [HttpGet]

        [Route("Admin/AdminTravelAgencyCQRS/AddTravelAgency")]
        public IActionResult AddTravelAgency()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTravelAgency(CreateTravelAgencyCommand command)
        {
            _createTravelAgencyCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTravelAgency(int id)
        {
            _removeTravelAgencyCommandHandler.Handle(new RemoveTravelAgencyCommand(id));
            return RedirectToAction("Index");
        }
    }
}
