using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOOKRESERVATION.Models
{
        
    public class BookReservationInfo
    {
        public int Id { get; set; }
        public string BorrowersName { get; set; }
        public string BookName { get; set; }
        public int? Qty { get; set; }
    }
}