using BLL.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contact.ContactStatus = true;
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contactService.Insert(contact);
            return RedirectToAction("Index", "Blog");
        }
    }
}
