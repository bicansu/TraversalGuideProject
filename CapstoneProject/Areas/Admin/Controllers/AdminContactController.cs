using AutoMapper;
using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DTOLayer.DTOs.ContactDTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CapstoneProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminContactController : Controller
    {
        private readonly IContact3Service _contact3Service;
        private readonly IMapper _mapper;

        public AdminContactController(IContact3Service contact3Service, IMapper mapper)
        {
            _contact3Service = contact3Service;
            _mapper = mapper;
        }
        [Route("Admin/AdminContact/Index")]
        public IActionResult Index()
        {
            var values = _mapper.Map<List<ContactListDto>>(_contact3Service.TGetList());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddContact()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddContact(ContactAddDto model)
        {
            if (ModelState.IsValid)
            {
                _contact3Service.TAdd(new Contact3()
                {
                    NameSurname = model.NameSurname,
                    Email = model.Email,
                    Comment = model.Comment,
                    Subject = model.Subject,
                    Phone = model.Phone,
                    Date = DateTime.Parse(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = _contact3Service.TGetByID(id);
            _contact3Service.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var values = _mapper.Map<ContactUpdateDTO>(_contact3Service.TGetByID(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateContact(ContactUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                _contact3Service.TUpdate(new Contact3
                {
                    Contact3ID = model.Contact3ID,
                    NameSurname = model.NameSurname,
                    Email = model.Email,
                    Comment = model.Comment,
                    Subject = model.Subject,
                    Date = model.Date,
                    Phone = model.Phone
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
