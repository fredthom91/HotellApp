using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp.HotellDatabase
{
    public class Room
    {
        public int RoomID { get; set; }
        public int RoomSize { get; set; }
        public int RoomNumber { get; set; }
        public int CustomerID { get; set; }
        public int BookingID { get; set; }

        public string SingleBed(string bedName)
        {
            bedName = "Single Bed";
            return bedName;

        }

        public string DoubleBed(string bedName2)
        {
            bedName2 = "Double beds";
            return bedName2;
        }


    }
}
