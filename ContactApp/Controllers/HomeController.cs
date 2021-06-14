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
        /// <summary>
        /// Gets the contacts from the db and forms a list. Passes the list to the view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //connects to the db and gets the contacts, includes all the category information for each one as well.
            var contacts = context.Contacts
                .Include(c => c.Category)
                .OrderBy(c => c.FirstName).ToList();
            //returns the view with the contacts list passed in.
            return View(contacts);
        }
    }
}
