using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        //if nothing was entered, show error message
        [Required(ErrorMessage = "Please enter a first name.")]
        //stores the first name in a string
        public string FirstName { get; set; }
        //if nothing was entered, show error message
        [Required(ErrorMessage = "Please enter a last name.")]
        //stores the last name in a string.
        public string LastName { get; set; }
        //if nothing was entered, show error message
        [Required(ErrorMessage = "Please enter a phone number.")]
        //stores the phone number as a string
        public string Phone { get; set; }
        //if nothing was entered, show error message
        [Required(ErrorMessage = "Please enter an email.")]
        //string to store the email
        public string Email { get; set; }
        //If the id isn't more than one, show error message.
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a category.")]
        //Category Id is a foreign key to the the Category table/model. It tells us which category to find. 
        public int CategoryId { get; set; }
        //Stores the instance of a Category that corresponds to the CategoryId
        public Category Category { get; set; }
        //DateTime property to store when the contact was created
        public DateTime DateCreated { get; set; }
        //concatenates the first name and last name with hyphens. Also makes them lowercase. 
        public string Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();
    }
}