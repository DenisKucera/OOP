using System;
using System.Collections.Generic;

public abstract class Auto 
{
    public enum TypPaliva { Benzin, Nafta }
    public double VelikostNadrze { get; protected set; }
    public double StavNadrze { get; protected set; }
    public TypPaliva Palivo { get; protected set; }

    public void Natankuj(TypPaliva typPaliva, double mnozstvi)
    {
        if (typPaliva != Palivo)
            throw new ArgumentException($"Spatne palivo! Toto auto jezdi na {Palivo}.");
        
        if (StavNadrze + mnozstvi > VelikostNadrze)
            throw new InvalidOperationException("Nadrz by pretekla!");

        StavNadrze += mnozstvi;
    }

    public Autoradio Radio { get; } = new Autoradio();

    public override string ToString() => $"Palivo: {Palivo}, Nadrz: {StavNadrze}/{VelikostNadrze}l";

}

public class Osobni : Auto
{
    public int MaxOsob { get; }
    private int prepravovaneOsoby;

    public int PrepravovaneOsoby
    {
        get => prepravovaneOsoby;

        set
        {
            if (value > MaxOsob) throw new Exception("Prekrocen max. pocet osob!");
            prepravovaneOsoby = value;
        }
    }

    public Osobni(double nadrz, TypPaliva palivo, int maxOsob)
    {
        VelikostNadrze = nadrz;
        Palivo = palivo;
        MaxOsob = maxOsob;
        PrepravovaneOsoby = 0;
    }

    public override string ToString() => base.ToString() + $", Osoby: {PrepravovaneOsoby}/{MaxOsob}";
}

public class Nakladni : Auto
{
    public double MaxNaklad { get; }
    private double prepravovanyNaklad;

    public double PrepravovanyNaklad
    {
        get => prepravovanyNaklad;
        set
        {
            if (value > MaxNaklad) throw new Exception("Naklad je prilis tezky!");
            prepravovanyNaklad = value;
        }
    }

    public Nakladni(double nadrz, TypPaliva palivo, double maxNaklad)
    {
        VelikostNadrze = nadrz;
        Palivo = palivo;
        MaxNaklad = maxNaklad;
        PrepravovanyNaklad = 0;
    }

    public override string ToString() => base.ToString() + $", Naklad: {PrepravovanyNaklad}/{MaxNaklad}kg";
}

public class Autoradio
{
    public double NaladenyKmitocet { get; private set; }
    public bool RadioZapnuto { get; set; }
    private Dictionary<int, double> predvolby = new Dictionary<int, double>();

    public void NastavPredvolbu(int cislo, double kmitocet) => predvolby[cislo] = kmitocet;

    public void PreladNaPredvolbu(int cislo)
    {
        if (predvolby.ContainsKey(cislo)) NaladenyKmitocet = predvolby[cislo];
    }

    public override string ToString() => $"Radio: {(RadioZapnuto ? "Zapnuto" : "Vypnuto")}, Frekvence: {NaladenyKmitocet} MHz";
}

