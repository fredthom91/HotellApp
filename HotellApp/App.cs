

using HotellApp.Controllers;
using HotellApp.Data;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HotellApp
{
    public class App
    {
              
        public void Run()
        {

            var buildApp = new CreateBuild();
            var context = buildApp.AppBuilder();
            var customerConfig = new CustomerController(context);
            var roomConfig = new RoomController(context);
            var bookingConfig = new BookingController(context);

            while (true)
            {
                var menu = CustomizationMenu.Menu();
                if (menu == 1)
                {
                    roomConfig.CreateRoom();
                }
                if (menu == 5)
                {
                    customerConfig.CreateCustomer();
                }
                if (menu == 2)
                {
                    roomConfig.ShowAllRooms();
                }
                if (menu == 6)
                {
                    customerConfig.ShowAllCustomers();
                }
                if (menu == 3)
                {
                    roomConfig.HandleRooms();
                }
                if (menu == 7)
                {
                    customerConfig.HandleCustomer();
                }
                if (menu == 4)
                {
                    roomConfig.DeleteRoom();
                }
                if (menu == 8)
                {
                    customerConfig.DeleteCustomer();
                }
                if (menu == 9)
                {
                    roomConfig.HandleBeds();
                }
                if (menu == 10)
                {
                    roomConfig.RemoveBeds();
                }
                if (menu == 11)
                {
                    while (true)
                    {
                        var bookingMenu = BookingMenu.Menu();

                        if (bookingMenu == 1)
                        {
                            bookingConfig.CreateBooking();
                        }
                        if (bookingMenu == 2)
                        {
                            bookingConfig.ShowAllBookings();
                        }
                        if (bookingMenu == 3)
                        {
                            bookingConfig.HandleBooking();
                        }
                        if (bookingMenu == 4)
                        {
                            bookingConfig.DeleteBooking();
                        }
                        if (bookingMenu == 0)
                        {
                            break;
                        }
                    }
                }
                if (menu == 0)
                {
                    break;
                }
            }
        }


    }
}
