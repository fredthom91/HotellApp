using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace HotellApp.Data
{     
        public static class BookingMenu
        {
        
        public static int Menu()
            {
            Console.Clear();
            int i = 0;
            var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("         [yellow]MENY[/]")
            .PageSize(20)
            .MoreChoicesText("[white](Move up and down to reveal more fruits)[/]")
            .AddChoices(new[] {
             "[yellow]Lägg till en bokning[/]",
             "[yellow]Se alla bokningar[/]",
             "[yellow]Ändra i en bokning[/]",
             "[yellow]Ta bort en bokning[/]",
             "[red]Avsluta[/]"
             
            }));

            if (choice == "[yellow]Lägg till en bokning[/]")
            {
                i = 1;
                return i;
            }
            if (choice == "[yellow]Se alla bokningar[/]")
            {
                i = 2;
                return i;
            }
            if (choice == "[yellow]Ändra i en bokning[/]")
            {
                i = 3;
                return i;
            }
            if (choice == "[yellow]Ta bort en bokning[/]")
            {
                i = 4;
                return i;
            }
            if (choice == "[red]Avsluta[/]")
            {
                i = 0;
                return i;
            }           
            else
            {
                return i;
            }
        }
        }
    
}
