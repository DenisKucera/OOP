using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Cv_11.EFCore; 

class Program
{
    static void Main(string[] args)
    {
        using (var context = new VyukaContext())
        {
            //Reset databaze
            context.Database.EnsureDeleted();
            //Vytvoreni databaze
            context.Database.EnsureCreated();
            //EF connection
            SeedDatabase(context);

            Console.WriteLine("Predmety a pocet studentu");
            var predmetyPocet = context.Predmety
                .Select(p => new { p.Nazev, Pocet = p.Studenti.Count })
                .OrderByDescending(x => x.Pocet)
                .ToList();

            foreach (var p in predmetyPocet)
            {
                Console.WriteLine($"{p.Nazev}: {p.Pocet} studentů");
            }

            Console.WriteLine("\n Metody StudentiPredmetu a PredmetyStudenta");
            
            var studentiOOP = StudentiPredmetu(context, "BPC-OOP");
            Console.WriteLine("Studenti zapsani v BPC-OOP:");
            foreach (var s in studentiOOP)
                Console.WriteLine($"- {s.Jmeno} {s.Prijmeni} {s.StudentId}");

            var predmetyStudenta1 = PredmetyStudenta(context, 256655);
            Console.WriteLine("\nPredmety, ktere ma zapsane student ID 256655:");
            foreach (var p in predmetyStudenta1)
                Console.WriteLine($"- {p.Nazev}");

            var predmetyStudenta2 = PredmetyStudenta(context, 256778);
            Console.WriteLine("\nPredmety, ktere ma zapsane student ID 256778:");
            foreach (var p in predmetyStudenta2)
                Console.WriteLine($"- {p.Nazev}");

            Console.WriteLine("\n Predmety a prumerna znamka obou studentu");
            var prumery = context.Predmety
                .Select(p => new 
                { 
                    p.Nazev, 
                    Prumer = p.Hodnoceni.Any() ? p.Hodnoceni.Average(h => h.Znamka) : 0 
                })
                .ToList();

            foreach (var p in prumery)
            {
                string textPrumeru = p.Prumer > 0 ? p.Prumer.ToString("F1") : "Nehodnoceno";
                Console.WriteLine($"{p.Nazev}: {textPrumeru}");
            }
        }
    }


    static void SeedDatabase(VyukaContext context)
    {
        if (!context.Predmety.Any(p => p.PredmetId == "BPC-OOP"))
            context.Predmety.Add(new Predmet { PredmetId = "BPC-OOP", Nazev = "Objektově orientované programování" });
            
        if (!context.Predmety.Any(p => p.PredmetId == "BPC-MAT"))
            context.Predmety.Add(new Predmet { PredmetId = "BPC-MAT", Nazev = "Matematika" });

        context.SaveChanges();

        var oop = context.Predmety.Find("BPC-OOP");
        var mat = context.Predmety.Find("BPC-MAT");

        if (!context.Studenti.Any(s => s.StudentId == 256655 && s.Jmeno == "Denis" && s.Prijmeni == "Kucera"))
        {
            var s1 = new Student {StudentId = 256655, Jmeno = "Denis", Prijmeni = "Kucera", DatumNarozeni = new DateTime(2004, 7, 31) };
            if (oop != null) s1.Predmety.Add(oop);
            if (mat != null) s1.Predmety.Add(mat);
            context.Studenti.Add(s1);
        }

        if (!context.Studenti.Any(s => s.StudentId == 256778 && s.Jmeno == "Martin" && s.Prijmeni == "Novak"))
        {
            var s2 = new Student {StudentId = 256778, Jmeno = "Martin", Prijmeni = "Novak", DatumNarozeni = new DateTime(2003, 4, 15) };
            if (oop != null) s2.Predmety.Add(oop);
            context.Studenti.Add(s2);
        }

        context.SaveChanges();

        // Hodnoceni
        if (!context.Hodnoceni.Any(h => h.StudentId == 256655 && h.PredmetId == "BPC-OOP"))
            context.Hodnoceni.Add(new Hodnoceni { StudentId = 256655, PredmetId = "BPC-OOP", Znamka = 1, DatumHodnoceni = DateTime.Now });

        if (!context.Hodnoceni.Any(h => h.StudentId == 256778 && h.PredmetId == "BPC-OOP"))
            context.Hodnoceni.Add(new Hodnoceni { StudentId = 256778, PredmetId = "BPC-OOP", Znamka = 3, DatumHodnoceni = DateTime.Now });

        context.SaveChanges();
    }

    //Metoda StudentiPredmetu
    static IEnumerable<Student> StudentiPredmetu(VyukaContext context, string predmetId)
    {
        return context.Studenti
            .Where(s => s.Predmety.Any(p => p.PredmetId == predmetId))
            .ToList();
    }

    //Metoda PredmetyStudenta
    static IEnumerable<Predmet> PredmetyStudenta(VyukaContext context, int studentId)
    {
        return context.Predmety
            .Where(p => p.Studenti.Any(s => s.StudentId == studentId))
            .ToList();
    }
}