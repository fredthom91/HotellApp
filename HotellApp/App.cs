using HotellApp.HotellDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellApp
{
    public class App
    {
        List<Customer> saveCustomer = new Customer();
        var booking = new Booking();
        var room = new Room();

        public void AddBooking()
        {
            Console.WriteLine("LÄGG TILL EN BOKNING");
            Console.WriteLine("---------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Sparade Kunder: ");
            foreach(var customer in saveCustomer)
            {
                Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName} ----- Telefonnr: {customer.PhoneNumber}");
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine("Skriv in namn på den kund du vill boka: ");
            var name = Console.ReadLine();
            Console.WriteLine("Tillgängliga Rum:")

        }
        public void ChangeCustomer()
        {
            
            Console.WriteLine("ÄNDRA/HANTERA EN KUND");
            Console.WriteLine("----------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Skriv in namn för kunden du vill ändra: ");
            var selectedcustomer = Console.ReadLine();
            var splitName = selectedcustomer.Split(' ');
            var firstName = splitName[0];
            var lastName = splitName[1];
            Console.WriteLine("Skriv in kundens telefonnummer: ");
            var phonenmbr = Console.ReadLine();
            
            Console.WriteLine("1. Ändra info");
            Console.WriteLine("2. Ta bort kunden");
            var select = Convert.ToInt32(Console.ReadLine());
            if(select == 1)
            {
                Console.WriteLine("Skriv in nytt namn: ");
                var name = Console.ReadLine();
                var newName = name.Split(' ');
                var newFirstName = newName[0];
                var newLastName = newName[1];
                saveCustomer.Remove(firstName);
                saveCustomer.Add(newFirstName);
                saveCustomer.Remove(lastName);
                saveCustomer.Add(newLastName);
                Console.WriteLine("Skriv in nytt telefonnummer: ");
                var newPhone = Console.ReadLine();
                saveCustomer.Remove(phonenmbr);
                saveCustomer.Add(newPhone);
                Console.WriteLine("Tack! Kund ändrad");
                
            }
            if(select == 2)
            {
                saveCustomer.Remove(firstName);
                saveCustomer.Remove(lastName);
                saveCustomer.Remove(phonenmbr);
            }
        }
        public void SaveCustomer(string firstname, string lastname, string phone)
        {
            
            if (firstname == null || lastname == null || phone == null)
            {
                
                saveCustomer.FirstName = firstname;
                saveCustomer.LastName = lastname;
                saveCustomer.PhoneNumber = phone;
            }
            
        }
        public void CustomizeRoom()
        {
            Console.WriteLine("HANTERA ETT RUM");
            Console.WriteLine("------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Skriv in rumsnumret på det rum du vill ändra/hantera: ");
            var roomSelect = Convert.ToInt31(Console.ReadLine());
            Console.WriteLine("1. Lägg till Sängar");
            Console.WriteLine("2. Ta bort Sängar");
            Console.WriteLine("3. Ta bort rum");
        }
        public void SetCustomer()
        {
            
            Console.WriteLine("LÄGG TILL KUND");
            Console.WriteLine("----------------");
            Console.WriteLine(" ");
            Console.WriteLine("Kundens namn: ");
            var name = Console.ReadLine();
            var fullName = name.Split(' ');
            var firstName = fullName[0];
            var lastName = fullName[1];

            Console.WriteLine("Kundens telefonnummer: ");
            var phoneNmbr = Console.ReadLine();
            SaveCustomer(firstName, lastName, phoneNmbr);
            Console.WriteLine("Kund tillagd!");
            Console.WriteLine("Vill du lägga till en ny kund? (J/N): ");
            var sel = Console.ReadLine();
            if (sel == "J")
            {
                continue;
            }
            if (sel == "N")
            {
                break;
            }
            else
            {
                Console.WriteLine("Felaktig inmatning, var god svara med J eller N");
            }

        }
        public void Run()
        {
            Console.WriteLine("BOKNINGS MENY");
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("1. Registrera ett rum");
            Console.WriteLine("2. Ändra/Hantera ett rum");
            Console.WriteLine("3. Registrera en kund");
            Console.WriteLine("4. Ändra en kund");
            Console.WriteLine("5. Lägg till en bokning");
            Console.WriteLine("6. Ändra en bokning");
            Console.WriteLine("7. Ta bort en bokning");
            Console.WriteLine("8. Avsluta");
            var select = Convert.ToInt32(Console.ReadLine());

            if (select == 1)
            {
                while (true)
                Console.WriteLine("Skriv in rummets yta: ");
                var newRoom = Convert.ToInt31(Console.ReadLine());
                Console.WriteLine("Rummet är registrerat!");
                Console.WriteLine("Vill du lägga till ett till rum? (J/N): ");
                var sel = Console.ReadLine();
                if(sel == "J")
                {
                    continue;
                }
                if(sel == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning, var god svara med J eller N");
                }
                                
            }
            if(select == 2)
            {
                CustomizeRoom();

            }
            if(select == 3)
            {
                SetCustomer();
            }
            if(select == 4)
            {
                ChangeCustomer();
            }
            if(select == 5)
            {

            }
        }
        
    }
}
