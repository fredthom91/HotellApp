using HotellApp.Data;
using Spectre.Console;

namespace HotellApp.Controllers;

public class RoomController
{
    public RoomController(HotellContext context)

    {
        Context = context;
    }

    public HotellContext Context { get; set; }

    public void CreateRoom()
    {
        while (true)
            try
            {
                Console.Clear();
                var room = new Room();

                Console.WriteLine("SKAPA ETT RUM");
                Console.WriteLine(" ");
                Console.WriteLine("---------------------");
                Console.WriteLine(" ");
                Console.WriteLine("Ange typ av rum (enkel/dubbel): ");
                room.RoomType = Console.ReadLine().ToLower();


                if (room.RoomType == "dubbel")
                    room.AmountOfBeds = 2;
                else if (room.RoomType == "enkel")
                    room.AmountOfBeds = 1;
                else
                    continue;


                Console.WriteLine("Ange antal kvm för rummet: ");
                room.RoomSize = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Sätt pris för rummet: ");
                room.RoomPrice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Rummet är registrerat!");
                Context.Rooms.Add(room);
                Context.SaveChanges();


                Console.WriteLine("Vill du lägga till ett rum? (J/N): ");
                var select = Console.ReadLine().ToUpper();
                if (select == "J") CreateRoom();
                if (select == "N") break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Felaktig Inmatning.");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
    }

    public void ShowAllRooms()
    {
        Console.Clear();
        var table = new Table();


        AnsiConsole.WriteLine("ALLA REGISTRERADE RUM");
        AnsiConsole.WriteLine(" ");
        AnsiConsole.WriteLine("------------------------");
        AnsiConsole.WriteLine(" ");
        table.AddColumn("Rumsnummer");
        table.AddColumn(new TableColumn("Rumstyp").Centered());
        table.AddColumn(new TableColumn("Storlek").Centered());
        table.AddColumn(new TableColumn("Antal sängar").Centered());
        table.AddColumn(new TableColumn("Pris").Centered());


        foreach (var room in Context.Rooms.OrderBy(r => r.RoomID).ThenBy(p => p.RoomSize))
            table.AddRow($"{room.RoomID}", $"{room.RoomType}", $"{room.RoomSize}", $"{room.AmountOfBeds}",
                $"{room.RoomPrice}");
        AnsiConsole.Write(table);


        Console.WriteLine("Tryck på valfri tangent för gå tillbaka till menyn: ");
        Console.ReadKey();
    }

    public void GetRooms()
    {
        Console.Clear();
        var table = new Table();


        AnsiConsole.WriteLine("ALLA REGISTRERADE RUM");
        AnsiConsole.WriteLine(" ");
        AnsiConsole.WriteLine("------------------------");
        AnsiConsole.WriteLine(" ");
        table.AddColumn("Rumsnummer");
        table.AddColumn(new TableColumn("Rumstyp").Centered());
        table.AddColumn(new TableColumn("Storlek").Centered());
        table.AddColumn(new TableColumn("Antal sängar").Centered());
        table.AddColumn(new TableColumn("Pris").Centered());


        foreach (var room in Context.Rooms.OrderBy(r => r.RoomID).ThenBy(p => p.RoomSize))
            table.AddRow($"{room.RoomID}", $"{room.RoomType}", $"{room.RoomSize}", $"{room.AmountOfBeds}",
                $"{room.RoomPrice}");
        AnsiConsole.Write(table);
    }

    public void HandleRooms()
    {
        while (true)
        {
            Console.Clear();
            try
            {
                GetRooms();

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("ÄNDRA ETT RUM");
                Console.WriteLine(" ");
                Console.WriteLine("--------------------------");
                Console.WriteLine(" ");
                Console.Write("Ange rumsnummer för rummet du vill hantera: ");
                var roomId = Convert.ToInt32(Console.ReadLine());
                var updatedRoom = Context.Rooms.First(r => r.RoomID == roomId);

                Console.Clear();

                Console.WriteLine("Ange typ av rum (enkel/dubbel): ");
                var newroomType = Console.ReadLine().ToLower();
                var newbeds = 0;

                if (newroomType == "dubbel") newbeds = 2;
                if (newroomType == "enkel") newbeds = 1;


                Console.WriteLine("Ange rummets storlek: ");
                var newroomSize = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ange rummets pris: ");
                var newroomPrice = Convert.ToInt32(Console.ReadLine());
                updatedRoom.ChangeRooms(newroomSize, newroomType, newroomPrice, newbeds);
                Console.WriteLine("Uppgifter uppdaterade!");
                Context.SaveChanges();

                Console.WriteLine(" ");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                Console.ReadKey();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Felaktig Inmatning.");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
        }
    }

    public void HandleBeds()
    {
        while (true)
        {
            Console.Clear();
            try
            {
                GetRooms();
                Console.WriteLine("LÄGG TILL SÄNGAR");
                Console.WriteLine(" ");
                Console.WriteLine("--------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("Ange rumsnummer för rummet du vill lägga till sängar: ");
                var roomId = Convert.ToInt32(Console.ReadLine());
                var updatedRoom = Context.Rooms.First(r => r.RoomID == roomId);


                if (updatedRoom.RoomType == "enkel")
                {
                    Console.WriteLine("Enkelrum kan bara ha 1 säng.");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                    Console.ReadKey();
                    Context.SaveChanges();
                    break;
                }

                if (updatedRoom.RoomType == "dubbel" &&
                    updatedRoom.RoomSize > 50 &&
                    updatedRoom.RoomSize <= 65 &&
                    updatedRoom.AmountOfBeds == 2)
                {
                    Console.WriteLine("Du kan lägga till 1 extra säng.");
                    Console.WriteLine("Lägg till säng? (J/N): ");
                    var selectedChoice = Console.ReadLine().ToUpper();
                    if (selectedChoice == "J")
                    {
                        updatedRoom.AmountOfBeds = 3;
                        Console.WriteLine("Säng tillagd!");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                        Console.ReadKey();
                        Context.SaveChanges();
                        break;
                    }

                    if (selectedChoice == "N")
                    {
                        Console.WriteLine("Ingen säng tillagd.");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                        Console.ReadKey();
                        Context.SaveChanges();
                        break;
                    }
                }


                if (updatedRoom.RoomType == "dubbel" &&
                    updatedRoom.RoomSize > 65 &&
                    updatedRoom.AmountOfBeds == 2)
                {
                    Console.WriteLine("Du kan lägga till 2 extra sängar.");
                    Console.WriteLine("Lägg till säng/sängar? (J/N): ");
                    var choice2 = Console.ReadLine().ToUpper();

                    if (choice2 == "J")
                    {
                        Console.WriteLine("1 eller 2: ");
                        var choice3 = Convert.ToInt32(Console.ReadLine());
                        if (choice3 == 1)
                        {
                            updatedRoom.AmountOfBeds = 3;
                            Console.WriteLine("1 extrasäng tillagd.");
                            Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                            Console.ReadKey();
                            Context.SaveChanges();
                            break;
                        }

                        if (choice3 == 2)
                        {
                            updatedRoom.AmountOfBeds = 4;
                            Console.WriteLine("2 extrasängar tillagda.");
                            Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                            Console.ReadKey();
                            Context.SaveChanges();
                            break;
                        }
                    }

                    if (choice2 == "N")
                    {
                        Console.WriteLine("Ingen extrasäng tillagd.");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                        Console.ReadKey();
                        Context.SaveChanges();
                        break;
                    }
                }


                if (updatedRoom.RoomType == "dubbel" &&
                    updatedRoom.RoomSize > 65 &&
                    updatedRoom.AmountOfBeds == 3)
                {
                    Console.WriteLine("Du kan lägga till 1 extra säng.");
                    Console.WriteLine("Lägg till säng? (J/N): ");
                    var choice4 = Console.ReadLine().ToUpper();
                    if (choice4 == "J")
                    {
                        updatedRoom.AmountOfBeds = 4;
                        Console.WriteLine("Extrasäng tillagd!");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                        Console.ReadKey();
                        Context.SaveChanges();
                        break;
                    }

                    if (choice4 == "N")
                    {
                        Console.WriteLine("Ingen säng tillagd.");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                        Console.ReadKey();
                        Context.SaveChanges();
                        break;
                    }
                }

                if (updatedRoom.RoomType == "dubbel" &&
                    updatedRoom.RoomSize < 65 &&
                    updatedRoom.AmountOfBeds == 3)
                {
                    Console.WriteLine("Rummet har redan max tillgängliga sängar.");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                    Console.ReadKey();
                    break;
                }

                if (updatedRoom.AmountOfBeds == 4)
                {
                    Console.WriteLine("Rummet har redan max tillgängliga sängar.");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                    Console.ReadKey();
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Felaktig Inmatning.");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
        }
    }

    public void RemoveBeds()
    {
        while (true)
        {
            Console.Clear();
            try
            {
                GetRooms();
                Console.WriteLine("TA BORT SÄNGAR");
                Console.WriteLine(" ");
                Console.WriteLine("--------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("Ange rumsnummer för rummet du vill ta bort sängar i: ");
                var roomId = Convert.ToInt32(Console.ReadLine());
                var updatedBeds = Context.Rooms.First(r => r.RoomID == roomId);

                if (updatedBeds.AmountOfBeds == 3)
                {
                    Console.WriteLine("1 säng har tagits bort från rummet! ");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                    Console.ReadKey();

                    updatedBeds.AmountOfBeds += -1;
                    Context.SaveChanges();
                    break;
                }

                if (updatedBeds.AmountOfBeds == 4)
                {
                    Console.WriteLine("Vill du bort 1 eller 2 sängar?: ");
                    var amount = Convert.ToInt32(Console.ReadLine());
                    if (amount == 1)
                    {
                        Console.WriteLine("1 säng har tagits bort från rummet! ");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();

                        updatedBeds.AmountOfBeds += -1;
                        Context.SaveChanges();
                        break;
                    }

                    if (amount == 2)
                    {
                        Console.WriteLine("2 sängar har tagits bort från rummet! ");
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                        Console.ReadKey();

                        updatedBeds.AmountOfBeds += -2;
                        Context.SaveChanges();
                        break;
                    }
                }


                if ((updatedBeds.RoomType == "dubbel" && updatedBeds.AmountOfBeds == 2)
                    || (updatedBeds.RoomType == "enkel"
                        && updatedBeds.AmountOfBeds == 1))
                {
                    Console.WriteLine("Detta rum får ej ha färre sängar");
                    Console.WriteLine("Tryck på valfri tangent för att fortsätta");
                    Console.ReadKey();
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Felaktig Inmatning.");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
        }
    }


    public void DeleteRoom()
    {
        while (true)
        {
            Console.Clear();
            try
            {
                GetRooms();

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("RADERA RUM");
                Console.WriteLine(" ");
                Console.WriteLine("-------------------");
                Console.WriteLine(" ");
                Console.WriteLine("Ange rumsnummer för det rum du vill radera: ");
                var roomId = Convert.ToInt32(Console.ReadLine());
                var deleteRoom = Context.Rooms.First(r => r.RoomID == roomId);
                var controller = Context.Bookings.Any(b => b.Room == deleteRoom);
                if (controller)
                {
                    Console.Clear();
                    Console.WriteLine("Rummet du valt har en bokning och kan ej tas bort.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Tryck på valfri tangent för gå tillbaka till menyn: ");
                    Console.ReadKey();
                    break;
                }

                Context.Rooms.Remove(deleteRoom);
                Context.SaveChanges();
                Console.Clear();
                Console.WriteLine("Rummet är raderat.");
                Console.WriteLine(" ");
                Console.WriteLine("Tryck på valfri tangent för gå tillbaka till menyn: ");
                Console.ReadKey();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Felaktig Inmatning.");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
                Console.ReadKey();
            }
        }
    }
}