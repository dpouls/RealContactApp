using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Controllers
{
    public class HomeController : Controller
    {


        //this property holds the information needed for our database connection
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx)
        {
            //we assign the database information to this context variable.
            context = ctx;
        }
        public IActionResult Index()
        {
            var contacts = context.Contacts
                .Include(c => c.Category)
                .OrderBy(c => c.FirstName).ToList();
            return View(contacts);
        }
    }
}
