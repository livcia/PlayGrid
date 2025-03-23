using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace xxx
{
    public class Administrator : Konto
    {
        public Administrator(string login, string haslo, string email, string nick)
            : base(login, haslo, email, nick, true)
        {
        }

        public void DodajGre(Biblioteka bibliotekaGlowna)
        {
            Console.Write("Podaj tytul: ");
            string tytul = Console.ReadLine();
            Console.Write("Podaj cene: ");
            string cena = Console.ReadLine();
            Console.Write("Podaj gatunek: ");
            string gatunek = Console.ReadLine();
            bibliotekaGlowna.DodajGre(new Gra(tytul, float.Parse(cena), gatunek));
            Console.WriteLine("Dodano gre");
            Thread.Sleep(200);
        }

        public void EdytujGre(Biblioteka bibliotekaGlowna, ref string[] aktualne_opcje, ref int etap, ref bool edycjaGry)
        {
            Console.WriteLine("ktora gre chcesz edytowac: ");
            aktualne_opcje = bibliotekaGlowna.gry.Select(x => x.nazwa).ToArray();
            etap = 2;
            edycjaGry = true;
        }

        public void EdytujGreOpcje(Biblioteka bibliotekaGlowna, ref int teraz, string[] opcje_edytuj_gre, ref int etap, ref bool edycjaGry, ref string[] aktualne_opcje, string[] opcje_administrator)
        {
            int opcjaTeraz = 0;
            while (true)
            {
                Console.Clear();
                Gra gra = bibliotekaGlowna.gry[teraz];
                Console.WriteLine($"Edytujesz gre: {gra.nazwa} co chcesz zmienic? ");
                gra.Wyswietl();
                for (int i = 0; i < opcje_edytuj_gre.Length; i++)
                {
                    Console.WriteLine((i == opcjaTeraz ? "-> " : "   ") + opcje_edytuj_gre[i]);
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && opcjaTeraz > 0) opcjaTeraz--;
                else if (key.Key == ConsoleKey.DownArrow && opcjaTeraz < opcje_edytuj_gre.Length - 1) opcjaTeraz++;
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (opcjaTeraz == 0)
                    {
                        Console.Write("Podaj nowa nazwe: ");
                        gra.nazwa = Console.ReadLine();
                    }
                    else if (opcjaTeraz == 1)
                    {
                        Console.Write("Podaj nowa cene: ");
                        gra.cena = float.Parse(Console.ReadLine());
                    }
                    else if (opcjaTeraz == 2)
                    {
                        Console.Write("Podaj nowy gatunek: ");
                        gra.gatunek = Console.ReadLine();
                    }
                    Console.WriteLine("Zaktualizowano gre");
                    Thread.Sleep(200);
                    break;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    etap = 1;
                    edycjaGry = false;
                    aktualne_opcje = opcje_administrator;
                    break;
                }
            }
        }

        public void EdytujKonto(Dictionary<string, Konto> konta, ref string[] aktualne_opcje, ref int etap, ref bool edycjaKonta)
        {
            Console.WriteLine("ktore konto chcesz edytowac: ");
            aktualne_opcje = konta.Keys.ToArray();
            etap = 2;
            edycjaKonta = true;
        }

        public void EdytujKontoOpcje(Dictionary<string, Konto> konta, ref int teraz, string[] opcje_edytuj_konto, ref int etap, ref bool edycjaKonta, ref string[] aktualne_opcje, string[] opcje_administrator)
        {
            int opcjaTeraz = 0;
            while (true)
            {
                Console.Clear();
                Konto konto = konta[aktualne_opcje[teraz]];
                Console.WriteLine($"Edytujesz konto: {konto.login} co chcesz zmienic? ");
                konto.Wyswietl();
                for (int i = 0; i < opcje_edytuj_konto.Length; i++)
                {
                    Console.WriteLine((i == opcjaTeraz ? "-> " : "   ") + opcje_edytuj_konto[i]);
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && opcjaTeraz > 0) opcjaTeraz--;
                else if (key.Key == ConsoleKey.DownArrow && opcjaTeraz < opcje_edytuj_konto.Length - 1) opcjaTeraz++;
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (opcjaTeraz == 0)
                    {
                        Console.Write("Podaj nowe haslo: ");
                        konto.haslo = Console.ReadLine();
                    }
                    else if (opcjaTeraz == 1)
                    {
                        Console.Write("Podaj nowy email: ");
                        konto.email = Console.ReadLine();
                    }
                    else if (opcjaTeraz == 2)
                    {
                        Console.Write("Podaj nowy nick: ");
                        konto.nick = Console.ReadLine();
                    }
                    Console.WriteLine("Zaktualizowano konto");
                    Thread.Sleep(200);
                    break;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    etap = 1;
                    edycjaKonta = false;
                    aktualne_opcje = opcje_administrator;
                    break;
                }
            }
        }

        public void UtworzKonto(Dictionary<string, Konto> konta)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Podaj login: ");
                string login = Console.ReadLine();
                if (konta.ContainsKey(login))
                {
                    Console.WriteLine("Konto o takim loginie już istnieje.");
                    Thread.Sleep(2000);
                    continue;
                }
                Console.Write("Podaj haslo: ");
                string haslo = Console.ReadLine();
                Console.Write("Podaj email: ");
                string email = Console.ReadLine();
                Console.Write("Podaj nick: ");
                string nick = Console.ReadLine();
                Console.Write("Czy to konto administratora? (tak/nie): ");
                bool czyAdministrator = Console.ReadLine().ToLower() == "tak";

                Konto noweKonto = new Konto(login, haslo, email, nick, czyAdministrator);
                konta.Add(login, noweKonto);
                Console.WriteLine("Utworzono konto. Naciśnij dowolny klawisz, aby kontynuować.");
                Console.ReadKey();
                break;
            }
        }


        public void WyswietlListeGier(Biblioteka bibliotekaGlowna)
        {
            Console.Clear();
            bibliotekaGlowna.WyswietlListeGier();
            Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu.");
            Console.ReadKey();
        }
    }
}
