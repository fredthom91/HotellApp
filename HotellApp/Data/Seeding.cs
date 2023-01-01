using Microsoft.EntityFrameworkCore;

namespace HotellApp.Data;

public class Seeding
{
    public void Seed(HotellContext Context)
    {
        Context.Database.Migrate();
        CustomerSeeding(Context);
        RoomSeeding(Context);
        Context.SaveChanges();
    }


    public void CustomerSeeding(HotellContext Context)
    {
        string[] name = { "Conny", "Lars-Inge", "Jake Sully", "Lennart", "Lasse" };
        string[] lastname = { "Andersson", "Svartenbrandt", "Turocmacto", "Hyland", "Kongo" };
        string[] phone = { "0701234567", "0709876543", "1234567890", "9988446655", "112112112" };


        if (!Context.Customers.Any())
        {
            var i = 0;
            while (i < 5)
            {
                Context.Customers.Add(new Customer
                {
                    FirstName = name[i],
                    LastName = lastname[i],
                    PhoneNumber = phone[i]
                });
                i++;
            }
        }
    }

    public void RoomSeeding(HotellContext Context)
    {
        int[] roomsize = { 35, 42, 62, 75, 80 };
        int[] roomprice = { 1000, 2000, 3000, 4000, 5000 };
        string[] roomtype = { "enkel", "enkel", "dubbel", "dubbel", "dubbel" };
        int[] beds = { 1, 1, 2, 2, 2 };


        if (!Context.Rooms.Any())
        {
            var i = 0;
            while (i < 5)
            {
                Context.Rooms.Add(new Room
                {
                    RoomSize = roomsize[i],
                    RoomPrice = roomprice[i],
                    RoomType = roomtype[i],
                    AmountOfBeds = beds[i]
                });
                i++;
            }
        }
    }
}