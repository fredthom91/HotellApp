using HotellApp.Data;
using Spectre.Console;

namespace HotellApp.Controllers;

public class CustomerController
{
    public CustomerController(HotellContext context)

    {
        Context = context;
    }

    public HotellContext Context { get; set; }

    public void CreateCustomer()
    {
        while (true)
            try
            {
                Console.Clear();
                var customer = new Customer();
                Console.WriteLine("REGISTRERA KUND");
                Console.WriteLine(" ");
                Console.WriteLine("----------------");
                Console.WriteLine(" ");
                Console.WriteLine("Kundens Förnamn: ");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("Kundens Efternamn: ");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Kundens telefonnummer: ");
                customer.PhoneNumber = Console.ReadLine();
                Console.WriteLine("Kunden är registrerad!");
                Context.Customers.Add(customer);
                Context.SaveChanges();


                Console.WriteLine("Vill du lägga till en ny kund? (J/N): ");
                var select = Console.ReadLine().ToUpper();

                if (select == "J") CreateCustomer();
                if (select == "N") break;
            }
            catch (Exception)
            {
                new ErrorHandling().CatchMessage();
            }
    }

    public void GetCustomers()
    {
        Console.Clear();
        var table = new Table();


        AnsiConsole.WriteLine("ALLA REGISTRERADE KUNDER");
        AnsiConsole.WriteLine("------------------------");
        AnsiConsole.WriteLine(" ");
        table.AddColumn("Kundnummer");
        table.AddColumn(new TableColumn("Förnamn").Centered());
        table.AddColumn(new TableColumn("Efternamn").Centered());
        table.AddColumn(new TableColumn("Telefonnummer").Centered());


        foreach (var customer in Context.Customers.OrderBy(c => c.CustomerID))
            table.AddRow($"{customer.CustomerID}",
                $"{customer.FirstName}",
                $"{customer.LastName}",
                $"{customer.PhoneNumber}");
        AnsiConsole.Write(table);
    }

    public void ShowAllCustomers()
    {
        Console.Clear();
        var table = new Table();


        AnsiConsole.WriteLine("ALLA REGISTRERADE KUNDER");
        AnsiConsole.WriteLine(" ");
        AnsiConsole.WriteLine("------------------------");
        AnsiConsole.WriteLine(" ");
        table.AddColumn("Kundnummer");
        table.AddColumn(new TableColumn("Förnamn").Centered());
        table.AddColumn(new TableColumn("Efternamn").Centered());
        table.AddColumn(new TableColumn("Telefonnummer").Centered());


        foreach (var customer in Context.Customers.OrderBy(c => c.CustomerID))
            table.AddRow($"{customer.CustomerID}",
                $"{customer.FirstName}",
                $"{customer.LastName}",
                $"{customer.PhoneNumber}");
        AnsiConsole.Write(table);


        Console.WriteLine("Tryck på valfri tangent för gå tillbaka till menyn: ");
        Console.ReadKey();
    }

    public void HandleCustomer()
    {
        while (true)
        {
            Console.Clear();
            try
            {
                GetCustomers();

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("UPPDATERA GÄSTER");
                Console.WriteLine(" ");
                Console.WriteLine("-------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("Ange kundnummer för den kund du vill ändra: ");
                var customerId = Convert.ToInt32(Console.ReadLine());
                var updatedCustomer = Context.Customers.First(c => c.CustomerID == customerId);

                ChangeCustomerInfo(updatedCustomer);
                break;
            }
            catch (Exception)
            {
                new ErrorHandling().CatchMessage();
            }
        }
    }

    public void ChangeCustomerInfo(Customer updatedCustomer)
    {
        Console.Clear();
        Console.WriteLine("Förnamn: ");
        var firstname = Console.ReadLine();
        Console.WriteLine("Efternamn: ");
        var lastname = Console.ReadLine();
        Console.WriteLine("Telefonummer: ");
        var phone = Console.ReadLine();
        updatedCustomer.ChangeCustomer(firstname, lastname, phone);
        Console.WriteLine("Uppgifter uppdaterade!");

        Context.SaveChanges();
        Console.WriteLine();
        Console.WriteLine("Tryck på valfri tangent för gå tillbaka till menyn: ");
        Console.ReadKey();
    }

    public void DeleteCustomer()
    {
        while (true)
        {
            Console.Clear();
            try
            {
                GetCustomers();

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("RADERA GÄSTER");
                Console.WriteLine(" ");
                Console.WriteLine("-------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("Ange kundnummer för den kund du vill radera: ");
                var customerId = Convert.ToInt32(Console.ReadLine());
                var deleteCustomer = Context.Customers.First(c => c.CustomerID == customerId);
                var controller = Context.Bookings.Any(b => b.Customer == deleteCustomer);
                if (controller)
                {
                    NoPossibleDelete();
                    break;
                }

                PossibleDelete(deleteCustomer);
                break;
            }
            catch (Exception)
            {
                new ErrorHandling().CatchMessage();
            }
        }
    }

    public void NoPossibleDelete()
    {
        Console.Clear();
        Console.WriteLine("Kunden du valt har en bokning och kan ej tas bort.");
        Console.WriteLine(" ");
        Console.WriteLine("Tryck på valfri tangent för gå tillbaka till menyn: ");
        Console.ReadKey();
    }

    public void PossibleDelete(Customer deleteCustomer)
    {
        Context.Customers.Remove(deleteCustomer);
        Context.SaveChanges();
        Console.Clear();
        Console.WriteLine("Kunden är raderad.");
        Console.WriteLine(" ");
        Console.WriteLine("Tryck på valfri tangent för gå tillbaka till menyn: ");
        Console.ReadKey();
    }
}