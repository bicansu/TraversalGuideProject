using CapstoneProject.Models;
using CapstoneProject_BusinessLayer.Abstract.AbstractUow;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CapstoneProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]

        [Route("Admin/Account/Index")]
        public IActionResult Index()
        {
            var values = _accountService.TGetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender   = _accountService.TGetByID(model.SenderID);
            var valueReceiver = _accountService.TGetByID(model.ReceiverID);

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;

            List<Account> modifiedAccounts = new List<Account>()
            {
                valueSender,
                valueReceiver
            };
            _accountService.TMultiUpdate(modifiedAccounts);
            return RedirectToAction("Index");
        }
        public IActionResult getRList(int val)
        {
            var values = _accountService.TGetByWithOutID(val);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
            //return this.Json((from obj in context.accounts select new {accountID = obj.AccountID, accountName = obj.AccountName}));
        }
    }
}
