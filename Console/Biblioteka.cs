using System.Collections.Generic;

public class Biblioteka
{
    public List<Gra> gry = new List<Gra>();
    public Dictionary<Gra, int> godziny = new Dictionary<Gra, int>();
    public void DodajGre(Gra gra)
    {
        gry.Add(gra);
        godziny.Add(gra, 0);
    }
    public void WyswietlGodziny()
    {
        foreach (var gra in godziny)
        {
            gra.Key.Wyswietl();
            System.Console.WriteLine($"Godziny: {gra.Value}");
        }
    }
    public void WyswietlListeGier()
    {
        foreach (var gra in gry)
        {
            gra.Wyswietl();
        }
    }

    public void DodajTestoweGry()
    {
        DodajGre(new Gra("GTA V", 100, "Akcji"));
        DodajGre(new Gra("Minecraft", 50, "Sandbox"));
        DodajGre(new Gra("CS:GO", 0, "FPS"));
    }
}
