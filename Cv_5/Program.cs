/*
 * Filename: c:\Users\denok\Desktop\OOP\Cv_5\Program.cs
 * Path: c:\Users\denok\Desktop\OOP\Cv_5
 * Created Date: Wednesday, March 11th 2026, 3:39:25 pm
 * Author: DenisKucera
 * 
 * Copyright (c) 2026 
 */

class Program
{
    static void Main()
    {
        try 
        {
            Osobni mojeAuto = new Osobni(60.0, Auto.TypPaliva.Benzin, 5);

            mojeAuto.PrepravovaneOsoby = 3; 
            mojeAuto.Natankuj(Auto.TypPaliva.Benzin, 20.0);

            mojeAuto.Radio.RadioZapnuto = true;
            mojeAuto.Radio.NastavPredvolbu(1, 102.5);
            mojeAuto.Radio.PreladNaPredvolbu(1);

            Console.WriteLine(mojeAuto.ToString());
            Console.WriteLine(mojeAuto.Radio.ToString());

            //moc lidi -> chyba
            mojeAuto.PrepravovaneOsoby = 10;  
        }
        catch (Exception ex) 
        { 
            Console.WriteLine($"{ex.Message}");
        }
    }
}