using HotellApp.Data;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace HotellApp.Controllers;

public class BookingController
{
    public BookingController(HotellContext context)

    {
        Context = context;
    }

    public HotellContext Context { get; set; }

    public void CreateBooking()
    {
        Console.Clear();
        var table = new Table();
        var _table = new Table();
        var newBooking = new Booking();
        new CustomerController(Context).GetCustomers();


        while (true)
            try
            {
                SetCustomer(newBooking);

                Console.Clear();

                Console.WriteLine("Skriv in antal nätter som skall bokas: ");
                var totalNights = Convert.ToInt32(Console.ReadLine());

                SetStartDate(newBooking);

                SetEndDate(newBooking, totalNights);

                var newBookingAllDates = ShowAllBookingDates(newBooking);

                var availableRooms = GetAvailableRooms(newBooking, newBookingAllDates);


                if (availableRooms.Count() < 1)
                {
                    NoAvailableRooms();
                    return;
                }

                ShowAvailableRooms(availableRooms);

                SetRoom(newBooking);

                BookingSuccess(newBooking, totalNights);
                break;
            }
            catch (Exception)
            {
                new ErrorHandling().CatchMessage();
            }
    }


    public void GetBookings()
    {
        Console.Clear();
        var table4 = new Table();
        Console.WriteLine("ALLA BOKNINGAR");
        Console.WriteLine(" ");
        Console.WriteLine("-----------------------------");

        table4.AddColumn("Bokningsnummer");
        table4.AddColumn(new TableColumn("Rumsnummer").Centered());
        table4.AddColumn(new TableColumn("Förnamn").Centered());
        table4.AddColumn(new TableColumn("Efternamn").Centered());
        table4.AddColumn(new TableColumn("Telefonnummer").Centered());
        table4.AddColumn(new TableColumn("Start").Centered());
        table4.AddColumn(new TableColumn("Slut").Centered());

        var bookedCustomer = Context.Bookings.Include(c => c.Customer);


        foreach (var booking in bookedCustomer.OrderBy(b => b.BookingID))
            table4.AddRow($"{booking.BookingID}",
                $"{booking.RoomID}",
                $"{booking.Customer.FirstName}",
                $"{booking.Customer.LastName}",
                $"{booking.Customer.PhoneNumber}",
                $"{booking.StartDate.ToShortDateString()}",
                $"{booking.EndDate.ToShortDateString()}");
        AnsiConsole.Write(table4);
    }

    public void HandleBooking()
    {
        Console.Clear();
        while (true)
            try
            {
                GetBookings();
                if (Context.Bookings.Any())
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("ÄNDRA BOKNING");
                    Console.WriteLine(" ");
                    Console.WriteLine("-------------------");
                    Console.WriteLine(" ");
                    Console.WriteLine("Ange bokningsnummer för den bokning du vill hantera: ");
                    var bookingId = Convert.ToInt32(Console.ReadLine());
                    var updatedBooking = Context.Bookings.First(b => b.BookingID == bookingId);


                    var select = ChangeBookingData();


                    if (select == 1)
                    {
                        Console.Clear();

                        new CustomerController(Context).GetCustomers();

                        NewCustomerOnBooking(updatedBooking);
                        break;
                    }

                    if (select == 2)
                    {
                        Console.Clear();

                        GetBookings();
                        NewDateForBooking(updatedBooking);
                        break;
                    }

                    if (select == 0) break;
                }
                else
                {
                    new ErrorHandling().NoActiveBookings();
                    break;
                }
            }
            catch (Exception)
            {
                new ErrorHandling().CatchMessage();
                break;
            }
    }

    public void DeleteBooking()
    {
        Console.Clear();
        while (true)
            try
            {
                GetBookings();
                if (Context.Bookings.Any())
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine("RADERA BOKNING");
                    Console.WriteLine(" ");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine(" ");
                    Console.WriteLine("Ange bokningsnummer för den bokning du vill avboka: ");
                    var bookingId = Convert.ToInt32(Console.ReadLine());
                    var deleteBooking = Context.Bookings.First(b => b.BookingID == bookingId);


                    Console.WriteLine("Är du säker på att du vill radera bokningen? (J/N): ");
                    var choice = Console.ReadLine().ToUpper();

                    if (choice == "J")
                    {
                        DeleteBooking(deleteBooking);
                        break;
                    }

                    if (choice == "N")
                    {
                        Console.WriteLine("Bokningen blev EJ raderad.");
                        Console.WriteLine("tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();
                        break;
                    }

                    if (choice != "J" || choice != "N")
                        Console.WriteLine("Felaktig inmatning, var god skriv J eller N.");
                }
                else
                {
                    new ErrorHandling().NoActiveBookings();
                    break;
                }
            }
            catch (Exception)
            {
                new ErrorHandling().CatchMessage();
                break;
            }
    }

    public static int ChangeBookingData()
    {
        Console.Clear();
        var i = 0;
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("         [yellow]BOKNINGSHANTERARE[/]")
                .PageSize(20)
                .MoreChoicesText("[white](Move up and down to reveal more fruits)[/]")
                .AddChoices("[yellow]Ändra Kundinformation för en bokning[/]", "[yellow]Ändra datum för en bokning[/]",
                    "[red]Avsluta[/]"));
        if (choice == "[yellow]Ändra Kundinformation för en bokning[/]")
        {
            i = 1;
            return i;
        }

        if (choice == "[yellow]Ändra datum för en bokning[/]")
        {
            i = 2;
            return i;
        }

        if (choice == "[red]Avsluta[/]")
        {
            i = 0;
            return i;
        }

        return i;
    }

    public void ShowAllBookings()
    {
        Console.Clear();
        var table5 = new Table();
        Console.WriteLine("ALLA BOKNINGAR");
        Console.WriteLine(" ");
        Console.WriteLine("-----------------------------");

        table5.AddColumn("Bokningsnummer");
        table5.AddColumn(new TableColumn("Rumsnummer").Centered());
        table5.AddColumn(new TableColumn("Förnamn").Centered());
        table5.AddColumn(new TableColumn("Efternamn").Centered());
        table5.AddColumn(new TableColumn("Telefonnummer").Centered());
        table5.AddColumn(new TableColumn("Start").Centered());
        table5.AddColumn(new TableColumn("Slut").Centered());

        var bookedCustomer = Context.Bookings.Include(c => c.Customer);

        foreach (var booking in bookedCustomer.OrderBy(b => b.BookingID))
            table5.AddRow($"{booking.BookingID}",
                $"{booking.RoomID}",
                $"{booking.Customer.FirstName}",
                $"{booking.Customer.LastName}",
                $"{booking.Customer.PhoneNumber}",
                $"{booking.StartDate.ToShortDateString()}",
                $"{booking.EndDate.ToShortDateString()}");
        AnsiConsole.Write(table5);


        if (!Context.Bookings.Any())
        {
            new ErrorHandling().NoActiveBookings();
        }
        else
        {
            Console.WriteLine("Tryck på valfri tangent för att fortsätta");
            Console.ReadKey();
        }
    }

    public void SetStartDate(Booking newBooking)
    {
        newBooking.StartDate = new DateTime(2014, 01, 03, 23, 59, 59);
        while (newBooking.StartDate < DateTime.Now.Date)
        {
            Console.WriteLine("Skriv in datum för incheckning (yyyy-mm-dd): ");
            newBooking.StartDate = Convert.ToDateTime(Console.ReadLine());
        }
    }

    public void SetEndDate(Booking newBooking, int totalNights)
    {
        if (totalNights == 1) newBooking.EndDate = newBooking.StartDate;
        else if (totalNights > 1) newBooking.EndDate = newBooking.StartDate.AddDays(totalNights);
    }

    public void SetCustomer(Booking newBooking)
    {
        Console.WriteLine("Ange kundnummer för den gäst som bokningen ska stå på: ");
        var customerId = Convert.ToInt32(Console.ReadLine());
        var customer = Context.Customers.First(c => c.CustomerID == customerId);
        newBooking.Customer = customer;
    }

    public List<DateTime> ShowAllBookingDates(Booking newBooking)
    {
        var newBookingAllDates = new List<DateTime>();
        for (var dt = newBooking.StartDate; dt <= newBooking.EndDate; dt = dt.AddDays(1))
            newBookingAllDates.Add(dt);
        return newBookingAllDates;
    }

    public List<Room> GetAvailableRooms(Booking newBooking, List<DateTime> newBookingAllDates)
    {
        var availableRooms = new List<Room>();
        foreach (var room in Context.Rooms.ToList())
        {
            var roomIsFree = true;
            foreach (var booking in Context.Bookings.Include(b => b.Room).Where(b => b.Room == room))
            {
                for (var dt = booking.StartDate; dt <= booking.EndDate; dt = dt.AddDays(1))
                    if (newBookingAllDates.Contains(dt))
                        roomIsFree = false;


                if (!roomIsFree) break;
            }


            if (roomIsFree) availableRooms.Add(room);
        }

        return availableRooms;
    }

    public void NoAvailableRooms()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Finns inga lediga rum för perioden du vill boka, försök med annat datum");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("tryck på valfri tangent för att fortsätta.");
        Console.ReadKey();
    }

    public void ShowAvailableRooms(List<Room> availableRooms)

    {
        Console.Clear();
        var table2 = new Table();
        Console.WriteLine("DOM HÄR RUMMEN ÄR LEDIGA");
        Console.WriteLine(" ");
        Console.WriteLine("---------------------");

        table2.AddColumn("Rumsnummer");
        table2.AddColumn(new TableColumn("Rumstyp").Centered());
        table2.AddColumn(new TableColumn("Storlek").Centered());
        table2.AddColumn(new TableColumn("Antal sängar").Centered());
        table2.AddColumn(new TableColumn("Pris").Centered());

        foreach (var room in availableRooms.OrderBy(r => r.RoomID))
            table2.AddRow($"{room.RoomID}",
                $"{room.RoomType}",
                $"{room.RoomSize}",
                $"{room.AmountOfBeds}",
                $"{room.RoomPrice}");
        AnsiConsole.Write(table2);
    }

    public void SetRoom(Booking newBooking)
    {
        Console.WriteLine("Välj rum, ange RUMSNUMMER: ");
        var roomNumber = Convert.ToInt32(Console.ReadLine());
        newBooking.Room = Context.Rooms
            .Where(r => r.RoomID == roomNumber)
            .FirstOrDefault();

        Context.Add(newBooking);
        Context.SaveChanges();
    }

    public void BookingSuccess(Booking newBooking, int totalNights)
    {
        var table3 = new Table();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine("Bokning Genomförd!");
        Console.WriteLine("----------------------");

        table3.AddColumn("Start");
        table3.AddColumn(new TableColumn("Slut").Centered());
        table3.AddColumn(new TableColumn("Antal nätter").Centered());

        table3.AddRow($" {newBooking.StartDate.ToShortDateString()}",
            $"{newBooking.EndDate.ToShortDateString()}",
            $"{totalNights}");
        AnsiConsole.Write(table3);

        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("tryck på valfri tangent för att fortsätta");
        Console.ReadKey();
    }

    public void NewCustomerOnBooking(Booking updatedBooking)
    {
        new CustomerController(Context).GetCustomers();
        Console.WriteLine(" ");
        Console.WriteLine("NY INNEHAVARE AV BOKNING");
        Console.WriteLine(" ");
        Console.WriteLine("---------------------------");
        Console.WriteLine(" ");

        Console.Write("Välj Kundnummer för ersättaren på bokningen: ");
        var customerId = Convert.ToInt32(Console.ReadLine());
        var customer = Context.Customers.First(c => c.CustomerID == customerId);
        updatedBooking.Customer = customer;
        Context.SaveChanges();
        Console.WriteLine("Bokning Uppdaterad!");
        Console.WriteLine("tryck på valfri tangent för att fortsätta");
        Console.ReadKey();
    }

    public void NewDateForBooking(Booking updatedBooking)
    {
        Console.WriteLine(" ");
        Console.WriteLine("NYTT DATUM FÖR BOKNING");
        Console.WriteLine(" ");
        Console.WriteLine("---------------------------");
        Console.WriteLine(" ");


        Console.Write("Skriv in antal nätter?: ");
        var totalNights = int.Parse(Console.ReadLine());
        Console.Write("Datum för incheckning (yyyy-mm-dd): ");
        var checkInDate = Convert.ToDateTime(Console.ReadLine());
        var checkOutDate = checkInDate.AddDays(totalNights);
        updatedBooking.UpdatedReservationDate(checkInDate, checkOutDate);

        Context.SaveChanges();
        Console.WriteLine("Bokning Uppdaterad!");
        Console.WriteLine("tryck på valfri tangent för att fortsätta");
        Console.ReadKey();
    }

    public void DeleteBooking(Booking deleteBooking)
    {
        Context.Bookings.Remove(deleteBooking);
        Context.SaveChanges();
        Console.WriteLine("Bokning raderad!");
        Console.WriteLine("tryck på valfri tangent för att fortsätta.");
        Console.ReadKey();
    }
}