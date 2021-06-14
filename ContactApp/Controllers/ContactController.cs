using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        //creates an instance of the ContactContext class
        private ContactContext context { get; set; }
        //assigns the context to the ctx variable in the constructor.
        public ContactController(ContactContext ctx)
        {
            //we assign the database information to this context variable.
            context = ctx;
        }
        /// <summary>
        /// Get request that displays the details page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            //if the id is 0 that means it is coming from the Add Contact page and we wan to redirect to the home page
            if (id == 0)
            {
                //redirects user to home page
                return RedirectToAction("Index", "Home");
            }
            //looks up the contact in the db by the id passed into the action. Includes the information from the category table.
            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);
            //returns the details view with the contact passed to it.
            return View(contact);
        }
        //defines the method is for an HTTP GET request
        [HttpGet]
        //Assigns viewbag content and returns the edit view renamed with Add
        public IActionResult Add()
        {
            //change viewbag.action to Add
            ViewBag.Action = "Add";
            //change viewbag.genres to what the genres are in the database via the context variable defined in the constructor method
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            //returns the view "Edit" and creates a new instance of the Contact Class.
            return View("Edit", new Contact());
        }
        //defines the method is for an HTTP GET request
        [HttpGet]
        ///Returns the edit contact page with the appropriate contact information
        public IActionResult Edit(int id)
        {
            //assigns "Edit" as the value to Viewbag.Action
            ViewBag.Action = "Edit";
            //Assigns a list of all the categories from the db to ViewBag.Categories 
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            //looks up the contact in the db by the id passed into the action. Includes the information from the category table.
            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);
            //returns the view with the contact passed in
            return View(contact);
        }
        /// <summary>
        /// Post request to handle the submission of the edit form. Determines if it is add or edit form then executes code accordingly
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            //determines if the action is Add or edit based on the contact Id
            string action = (contact.ContactId == 0) ? "Add" : "Edit";
            //checks to make sure the model state is valid before continuing
            if (ModelState.IsValid)
            {
                //if the action is Add, create a time stamp and add the rest of the contact to the db with it.
                if (action == "Add")
                {
                    //creates the time stamp and assigns it to the DateCreated property
                    contact.DateCreated = DateTime.Now;
                    //Add the new contact to the db
                    context.Contacts.Add(contact);
                }
                else
                {
                    //this is an edit statement so we will replace the old contact in the db with the new one that is passed in.
                    context.Contacts.Update(contact);
                }
                //We need to save changes to the db.
                context.SaveChanges();
                //redirects the user to the home page after executing the add or edit code
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //changes teh viewbag action to the action value
                ViewBag.Action = action;
                //Creates a list of categories from the db 
                ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
                //retuns the edit view with the user information
                return View(contact);
            }
        }
        [HttpGet]
        //finds the Contact and displays it in a view
        public IActionResult Delete(int id)
        {
            //finds the Contact in the database
            Contact contact = context.Contacts.Find(id);
            //returns the view with the Contact information
            return View(contact);
        }
        //defines the method is for an HTTP Post request

        [HttpPost]
        //deletes the Contact from the database
        public IActionResult Delete(Contact contact)
        {
            //goes to the database and removes the Contact
            context.Contacts.Remove(contact);
            //save the changes to the database
            context.SaveChanges();
            //redirects the user to the index or home page via the home controller.
            return RedirectToAction("Index", "Home");
        }
    }
}
