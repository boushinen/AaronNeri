using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOOKRESERVATION.Models
{
    public class Account
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Age { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
    }
}