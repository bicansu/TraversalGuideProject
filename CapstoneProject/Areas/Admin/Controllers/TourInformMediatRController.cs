using CapstoneProject.CQRS.Commands.TourInformCommands;
using CapstoneProject.CQRS.Commands.TravelAgencyCommands;
using CapstoneProject.CQRS.Handlers.TravelAgencyHandlers;
using CapstoneProject.CQRS.Queries.TourInformQuery;
using CapstoneProject.CQRS.Queries.TravelAgencyQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapstoneProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous] 
    public class TourInformMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public TourInformMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("Admin/TourInformMediatR/Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllTourInformQuery());
            return View(values);
        }
        [HttpGet]
        [Route("Admin/TourInformMediatR/GetTourInforms/{id}")]
        public async Task<IActionResult> GetTourInforms(int id)
        {
            var values = await _mediator.Send(new GetTourInformByIDQuery(id));
            ViewBag.Image = values.Image;
            return View(values);
        }
        [HttpPost]
       
        public async Task<IActionResult> GetTourInforms(UpdateTourInformCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Admin/TourInformMediatR/AddTourInform")]
        public IActionResult AddTourInform()
        {
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> AddTourInform(CreateTourInformCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        } 
        public async Task<IActionResult> DeleteTourInform(int id)
        {
            await _mediator.Send(new RemoveTourInformCommand(id));
            return RedirectToAction("Index");

        }
    }
}
