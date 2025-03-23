using System;
using System.Collections.Generic;

public class Konto
{
    public string login;
    public string haslo;
    public string email;
    public string nick;
    public bool czyAdministrator;
    public Biblioteka mojaBiblioteka;
    public float balans;

    public Konto(string login, string haslo, string email, string nick, bool czyAdministrator)
    {
        this.login = login;
        this.haslo = haslo;
        this.email = email;
        this.nick = nick;
        this.czyAdministrator = czyAdministrator;
        this.mojaBiblioteka = new Biblioteka();
        this.balans = 0;
    }

    public void Wyswietl()
    {
        Console.WriteLine($"Login: {login}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Nick: {nick}");
        Console.WriteLine($"Balans: {balans} zł");
    }

    public void WyswietlStatystyki()
    {
        Console.WriteLine("Wyświetlanie statystyk gry...");
        mojaBiblioteka.WyswietlGodziny();
        Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu.");
        Console.ReadKey();
    }

    public void DoladujKonto()
    {
        Console.WriteLine("Podaj kwotę do doładowania:");
        if (float.TryParse(Console.ReadLine(), out float kwota) && kwota > 0)
        {
            balans += kwota;
            Console.WriteLine($"Doładowano konto o {kwota} zł. Aktualny balans: {balans} zł.");
        }
        else
        {
            Console.WriteLine("Nieprawidłowa kwota.");
        }
        Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu.");
        Console.ReadKey();
    }

    public void DodajGodzinyDoGry()
    {
        int teraz = 0;
        List<Gra> gry = mojaBiblioteka.gry;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Wybierz grę, do której chcesz dodać godziny:");

            for (int i = 0; i < gry.Count; i++)
            {
                Console.WriteLine((i == teraz ? "-> " : "   ") + gry[i].nazwa);
            }

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow && teraz > 0) teraz--;
            else if (key.Key == ConsoleKey.DownArrow && teraz < gry.Count - 1) teraz++;
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine($"Dodajesz godziny do gry: {gry[teraz].nazwa}");
                Console.WriteLine("Podaj ilość godzin do dodania:");
                if (float.TryParse(Console.ReadLine(), out float godziny) && godziny > 0)
                {
                    mojaBiblioteka.godziny[gry[teraz]] += (int)godziny;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa ilość godzin.");
                }
                Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu.");
                Console.ReadKey();
                break;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    public void KupGre(Biblioteka bibliotekaGlowna)
    {
        int teraz = 0;
        List<Gra> gry = bibliotekaGlowna.gry;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Twój aktualny balans: {balans} zł");
            Console.WriteLine("Którą grę chcesz kupić?");

            for (int i = 0; i < gry.Count; i++)
            {
                Console.WriteLine((i == teraz ? "-> " : "   ") + gry[i].nazwa + " - " + gry[i].cena + " zł");
            }

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow && teraz > 0) teraz--;
            else if (key.Key == ConsoleKey.DownArrow && teraz < gry.Count - 1) teraz++;
            else if (key.Key == ConsoleKey.Enter)
            {
                Gra wybranaGra = gry[teraz];
                if (balans >= wybranaGra.cena)
                {
                    balans -= wybranaGra.cena;
                    mojaBiblioteka.DodajGre(wybranaGra);
                    Console.WriteLine($"Zakupiłeś grę: {wybranaGra.nazwa}. Pozostały balans: {balans} zł.");
                }
                else
                {
                    Console.WriteLine("Niewystarczające środki na koncie.");
                }
                Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu.");
                Console.ReadKey();
                break;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    public void WyswietlKonto()
    {
        Console.WriteLine("Wyświetlanie konta...");
        Wyswietl();
        Console.WriteLine("Twoja biblioteka Gier: ");
        mojaBiblioteka.WyswietlListeGier();
        Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu.");
        Console.ReadKey();
    }
}
