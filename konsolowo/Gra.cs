using System;

public class Gra
{
    public string nazwa;
    public float cena;
    public string gatunek;

    public Gra(string nazwa, float cena, string gatunek)
    {
        this.nazwa = nazwa;
        this.cena = cena;
        this.gatunek = gatunek;
    }

    public void Wyswietl()
    {
        Console.WriteLine($"Nazwa: {nazwa}, Cena: {cena} zł, Gatunek: {gatunek}");
    }

}
