class Program
{
    static void Main(string[] args)
    {
        string vstupniSoubor = "teploty.txt";
        string vystupniSoubor = "teploty_kalibrovane.txt";

        ArchivTeplot archiv = new ArchivTeplot();

        try
        {
            // Nacteni ze souboru
            archiv.Load(vstupniSoubor);
            Console.WriteLine("Data úspěšně načtena.");

            // Vypis teplot
            Console.WriteLine("\nVšechny teploty");
            archiv.TiskTeplot();

            // Vypis prumernych hodnot
            Console.WriteLine("\nPrůměrné roční teploty");
            archiv.TiskPrumernychRocnichTeplot();

            Console.WriteLine("\nPrůměrné měsíční teploty");
            archiv.TiskPrumernychMesicnichTeplot();

            // Kalibrace o teplotu -0.1 
            Console.WriteLine("\nKalibrace (-0.1)...");
            archiv.Kalibrace(-0.1);

            // Ulozeni do noveho souboru 
            archiv.Save(vystupniSoubor);
            Console.WriteLine($"Data úspěšně uložena do {vystupniSoubor}.");
            
            Console.WriteLine("\nTeploty po kalibraci");
            archiv.TiskTeplot();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Chyba: {ex.Message}");
        }
    }
}