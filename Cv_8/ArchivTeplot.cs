public class ArchivTeplot
{
    private SortedDictionary<int, RocniTeplota> _archiv;

    public ArchivTeplot()
    {
        _archiv = new SortedDictionary<int, RocniTeplota>();
    }

public void Load(string cesta)
{
    _archiv.Clear();
    
    string[] radky = File.ReadAllLines(cesta);
    
    foreach (string radek in radky)
    {
        if (string.IsNullOrWhiteSpace(radek)) continue;

        string[] casti = radek.Split(':');
        int rok = int.Parse(casti[0].Trim());

        string[] strTeploty = casti[1].Split(';', StringSplitOptions.RemoveEmptyEntries);
        
        List<double> teploty = new List<double>();
        
        foreach (string t in strTeploty)
        {
            string opravenyText = t.Trim().Replace(',', '.');
            
            double teplota = double.Parse(opravenyText, System.Globalization.CultureInfo.InvariantCulture);
            
            teploty.Add(teplota);
        }

        _archiv[rok] = new RocniTeplota(rok, teploty);
    }
}

    public void Save(string cesta)
{
    using (StreamWriter sw = new StreamWriter(cesta))
    {
        foreach (var polozka in _archiv)
        {
            List<string> textoveTeploty = new List<string>();
            
            foreach (double t in polozka.Value.MesicniTeploty)
            {
                string textSDoteckou = t.ToString("F1", System.Globalization.CultureInfo.InvariantCulture);
                
                string textSCarkou = textSDoteckou.Replace('.', ',');
                
                textoveTeploty.Add(textSCarkou);
            }

            string teplotyStr = string.Join("; ", textoveTeploty);
            sw.WriteLine($"{polozka.Key}: {teplotyStr}");
        }
    }
}
    public void Kalibrace(double konstanta)
    {
        foreach (var polozka in _archiv)
        {
            for (int i = 0; i < polozka.Value.MesicniTeploty.Count; i++)
            {
                polozka.Value.MesicniTeploty[i] += konstanta;
            }
        }
    }

    public RocniTeplota Vyhledej(int rok)
    {
        if (_archiv.ContainsKey(rok))
            return _archiv[rok];
        return null;
    }

    public void TiskTeplot()
    {
        foreach (var polozka in _archiv)
        {
            Console.Write($"{polozka.Key}: ");
            foreach (var t in polozka.Value.MesicniTeploty)
            {
                Console.Write($"{t,5:F1} ");
            }
            Console.WriteLine();
        }
    }

    public void TiskPrumernychRocnichTeplot()
    {
        foreach (var polozka in _archiv)
        {
            Console.WriteLine($"{polozka.Key}: {polozka.Value.PrumRocniTeplota:F1}");
        }
    }

    public void TiskPrumernychMesicnichTeplot()
    {
        if (_archiv.Count == 0) return;

        Console.Write("Prum.: ");
        for (int mesic = 0; mesic < 12; mesic++) 
        {
            double suma = 0;
            foreach (var polozka in _archiv)
            {
                suma += polozka.Value.MesicniTeploty[mesic];
            }
            double prumer = suma / _archiv.Count;
            Console.Write($"{prumer,5:F1} ");
        }
        Console.WriteLine();
    }
}