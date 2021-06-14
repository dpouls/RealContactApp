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

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter an email.")]
        public string Email { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a category.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public DateTime DateCreated { get; set; }

        public string Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();
    }
}