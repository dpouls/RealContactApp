using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Models
{
    public class Category
    {

        //int value automatically recognized as the primary key. 
        public int CategoryId { get; set; }
        //name of the category that goes with the CategoryId
        public string Name { get; set; }
    }
}
