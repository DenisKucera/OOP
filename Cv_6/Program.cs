class Program
{
    static void Main()
    {
        GrObjekt[] objekty = new GrObjekt[]
        {
            new Kruh(1.54),
            new Obdelnik(2.0, 4.0),
            new Trojuhelnik(3.0, 5.0),
            new Kvadr(2.0, 3.0, 4.0),
            new Jehlan(3.0, 4.5),
            new Elipsa(2.5, 1.2),
            new Valec(1.54, 5.41),
            new Koule(1.5)
        };

        double celkovaPlocha = 0;
        double celkovyPovrch = 0;
        double celkovyObjem = 0;

        Console.WriteLine("");

        foreach (var obj in objekty)
        {
            obj.Kresli();

            if (obj is Objekt2D obj2D)
            {
                celkovaPlocha += obj2D.SpoctiPlochu();
            }
            else if (obj is Objekt3D obj3D)
            {
                celkovyPovrch += obj3D.SpoctiPovrch();
                celkovyObjem += obj3D.SpoctiObjem();
            }
        }

        Console.WriteLine("");
        Console.WriteLine($"Celkova plocha 2D objektu: {celkovaPlocha:F2}");
        Console.WriteLine($"Celkovy povrch 3D objektu: {celkovyPovrch:F2}");
        Console.WriteLine($"Celkovy objem 3D objektu:  {celkovyObjem:F2}");
    }
}