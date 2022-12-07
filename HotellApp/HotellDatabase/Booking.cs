using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.HotellDatabase
{
    public class Booking
    {
        public int BookingID { get; set; }

        public int RoomID { get; set; }
        public int CustomerID { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
