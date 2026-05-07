class Program
{
    static void Main()
    {
        int[] cisla = { 10, 5, 20, 3, 15 };
        string[] slova = { "Zebra", "Auto", "Letadlo", "Pes" };
        Kruh[] kruhy = { 
            new Kruh(2), 
            new Kruh(5), 
            new Kruh(1) 
        };
        Obdelnik[] obdelniky = { 
            new Obdelnik(1,2), 
            new Obdelnik (3,4), 
            new Obdelnik(5,6)
            };
        Objekt2D[] ruzneObjekty = {
            new Elipsa(2, 3),   
            new Ctverec(4),       
            new Trojuhelnik(5, 2) 
        };

        Console.WriteLine("=== Testovani Generickych Metod ===");
         Console.WriteLine($"Nejvetsi cislo: {Extremy.Nejvetsi(cisla)}"); 
         Console.WriteLine($"Nejmensi cislo: {Extremy.Nejmensi(cisla)}"); 
        
         Console.WriteLine($"Posledni slovo (abecedne): {Extremy.Nejvetsi(slova)}"); 
         Console.WriteLine($"Prvnni slovo (abecedne): {Extremy.Nejmensi(slova)}"); 
        
         Console.WriteLine($"Nejvetsi kruh: {Extremy.Nejvetsi(kruhy)}");
         Console.WriteLine($"Nejmensi kruh: {Extremy.Nejmensi(kruhy)}");  

         Console.WriteLine($"Nejvetsi obdelnik: {Extremy.Nejvetsi(obdelniky)}"); 
         Console.WriteLine($"Nejmensi obdelnik: {Extremy.Nejmensi(obdelniky)}"); 
        
         Console.WriteLine($"Nejvetsi 2D objekt: {Extremy.Nejvetsi(ruzneObjekty)}"); 
         Console.WriteLine($"Nejmensi 2D objekt: {Extremy.Nejmensi(ruzneObjekty)}"); 

        Console.WriteLine("\n=== Testovani LINQ ===");

        int[] linqCisla = { 1, 3, 5, 7, 9 };
        
        var vyfiltrovano = linqCisla.Where(x => x >= 4 && x <= 8); 
        
        Console.WriteLine($"Puvodni pole: {string.Join(", ", linqCisla)}");
        Console.WriteLine($"Vyfiltrovano (4 az 8): {string.Join(", ", vyfiltrovano)}");
    }
}