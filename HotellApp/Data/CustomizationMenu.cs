using Spectre.Console;

namespace HotellApp.Data;

public static class CustomizationMenu
{
    public static int Menu()
    {
        Console.Clear();
        var i = 0;
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("         [yellow]MENY[/]")
                .PageSize(20)
                .MoreChoicesText("[white](Move up and down to reveal more fruits)[/]")
                .AddChoices("[yellow]Lägg till ett nytt rum[/]", "[yellow]Se alla rum[/]",
                    "[yellow]Ändra/Hantera ett rum[/]", "[yellow]Ta bort ett rum[/]",
                    "[yellow]Registrera en ny kund[/]", "[yellow]Se alla kunder[/]", "[yellow]Ändra/Hantera en kund[/]",
                    "[yellow]Ta bort en kund[/]", "[yellow]Lägg till sängar[/]", "[yellow]Ta bort sängar[/]",
                    "[yellow]Gå till Bokningsmeny[/]", "[red]Avsluta[/]"));

        if (choice == "[yellow]Lägg till ett nytt rum[/]")
        {
            i = 1;
            return i;
        }

        if (choice == "[yellow]Se alla rum[/]")
        {
            i = 2;
            return i;
        }

        if (choice == "[yellow]Ändra/Hantera ett rum[/]")
        {
            i = 3;
            return i;
        }

        if (choice == "[yellow]Ta bort ett rum[/]")
        {
            i = 4;
            return i;
        }

        if (choice == "[yellow]Registrera en ny kund[/]")
        {
            i = 5;
            return i;
        }

        if (choice == "[yellow]Se alla kunder[/]")
        {
            i = 6;
            return i;
        }

        if (choice == "[yellow]Ändra/Hantera en kund[/]")
        {
            i = 7;
            return i;
        }

        if (choice == "[yellow]Ta bort en kund[/]")
        {
            i = 8;
            return i;
        }

        if (choice == "[yellow]Lägg till sängar[/]")
        {
            i = 9;
            return i;
        }

        if (choice == "[yellow]Ta bort sängar[/]")
        {
            i = 10;
            return i;
        }

        if (choice == "[red]Avsluta[/]")
        {
            i = 0;
            return i;
        }

        if (choice == "[yellow]Gå till Bokningsmeny[/]")
        {
            i = 11;
            return i;
        }

        return i;
    }
}