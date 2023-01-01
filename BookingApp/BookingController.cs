using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotellDataLibrary;



namespace HotellDataLibrary.LibraryData
{
    public class BookingController
    {
        public HotellContext Context { get; set; }
        

        public BookingController(HotellContext context)
                                  
        {
            Context = context;
        }

        public void CreateBooking()
        {

        }

        public void GetBookings()
        {

        }

        public void HandleBooking()
        {

        }

        public void DeleteBooking()
        {

        }
    }
}
