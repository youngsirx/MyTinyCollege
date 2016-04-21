using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTinyCollege.Models
{
    public class Person
    {
        public int ID { get; set; }

        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public string Email { get; set; }

        //full name is a calculated property that returns a value created by concatenating
        //two other properties. Therefore it only has a get accessor, and because of this 
        //no fullname columnwill be generated in the database
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
    }
}