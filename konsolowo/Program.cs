using System;
using System.Collections.Generic;
using System.Threading;
using xxx;

internal class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Biblioteka bibliotekaGlowna = new Biblioteka();
            bibliotekaGlowna.DodajTestoweGry();

            string[] opcje_administrator = { "Dodaj Gre", "Edytuj Gre", "Edytuj konto", "utworz konto", "Wyswietl liste gier na platformie", "Wyloguj się" };
            string[] opcje_edytuj_gre = { "zmien nazwe", "zmien cene", "zmien gatunek" };
            string[] opcje_edytuj_konto = { "zmien haslo", "zmien email", "zmien nick" };
            string[] opcje_uzytkownik = { "Kup Gre", "Wyswietl Statystyki Gry", "Wyswietl Konto", "Doładuj Konto", "Dodaj Godziny Do Gry", "Wyloguj się" };

            Dictionary<string, Konto> konta = new Dictionary<string, Konto>
            {
                { "admin", new Administrator("admin", "admin", null, null) },
                { "user", new Konto("user", "user", "user@example.com", "user", false) }
            };

            while (true)
            {
                string[] daneLogowania = ZalogujSie();
                string login = daneLogowania[0];
                string haslo = daneLogowania[1];

                if (!konta.ContainsKey(login) || konta[login].haslo != haslo)
                {
                    Console.WriteLine("Niepoprawne dane logowania");
                    Thread.Sleep(2000);
                    continue;
                }

                Konto zalogowaneKonto = konta[login];
                bool czyAdmin = zalogowaneKonto.czyAdministrator;
                Administrator admin = czyAdmin ? (Administrator)zalogowaneKonto : null;
                string[] aktualne_opcje = czyAdmin ? opcje_administrator : opcje_uzytkownik;
                int teraz = 0;
                int etap = 1;
                bool edycjaGry = false;
                bool edycjaKonta = false;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(czyAdmin ? "Witaj adminie!" : "Witaj użytkowniku!");

                    for (int i = 0; i < aktualne_opcje.Length; i++)
                    {
                        Console.WriteLine((i == teraz ? "-> " : "   ") + aktualne_opcje[i]);
                    }

                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow && teraz > 0) teraz--;
                    else if (key.Key == ConsoleKey.DownArrow && teraz < aktualne_opcje.Length - 1) teraz++;
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        if (czyAdmin && etap == 1)
                        {
                            if (teraz == 0)
                            {
                                admin.DodajGre(bibliotekaGlowna);
                            }
                            else if (teraz == 1 && !edycjaGry)
                            {
                                admin.EdytujGre(bibliotekaGlowna, ref aktualne_opcje, ref etap, ref edycjaGry);
                            }
                            else if (teraz == 2 && !edycjaKonta)
                            {
                                admin.EdytujKonto(konta, ref aktualne_opcje, ref etap, ref edycjaKonta);
                            }
                            else if (teraz == 3)
                            {
                                admin.UtworzKonto(konta);
                                etap = 1;
                                aktualne_opcje = opcje_administrator;
                            }
                            else if (teraz == 4)
                            {
                                admin.WyswietlListeGier(bibliotekaGlowna);
                            }
                            else if (teraz == 5)
                            {
                                break;
                            }
                        }
                        else if (!czyAdmin && etap == 1)
                        {
                            if (teraz == 0)
                            {
                                zalogowaneKonto.KupGre(bibliotekaGlowna);
                            }
                            else if (teraz == 1)
                            {
                                zalogowaneKonto.WyswietlStatystyki();
                            }
                            else if (teraz == 2)
                            {
                                zalogowaneKonto.WyswietlKonto();
                            }
                            else if (teraz == 3)
                            {
                                zalogowaneKonto.DoladujKonto();
                            }
                            else if (teraz == 4)
                            {
                                zalogowaneKonto.DodajGodzinyDoGry();
                            }
                            else if (teraz == 5)
                            {
                                break;
                            }
                        }
                        else if (etap == 2 && edycjaGry)
                        {
                            admin.EdytujGreOpcje(bibliotekaGlowna, ref teraz, opcje_edytuj_gre, ref etap, ref edycjaGry, ref aktualne_opcje, opcje_administrator);
                        }
                        else if (etap == 2 && edycjaKonta)
                        {
                            admin.EdytujKontoOpcje(konta, ref teraz, opcje_edytuj_konto, ref etap, ref edycjaKonta, ref aktualne_opcje, opcje_administrator);
                        }
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        if (etap == 2 && edycjaGry)
                        {
                            etap = 1;
                            edycjaGry = false;
                            aktualne_opcje = opcje_administrator;
                        }
                        else if (etap == 2 && edycjaKonta)
                        {
                            etap = 1;
                            edycjaKonta = false;
                            aktualne_opcje = opcje_administrator;
                        }
                    }
                }
            }
        }
    }

    public static string[] ZalogujSie()
    {
        Console.WriteLine("Podaj login");
        string login = Console.ReadLine();
        Console.WriteLine("Podaj haslo");
        string haslo = Console.ReadLine();
        return new string[] { login, haslo };
    }
}
