// See https://aka.ms/new-console-template for more information

string testovaciText = "Toto je retezec predstavovany nekolika radky,\n"
+ "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
+ "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
+ "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
+ "posledni veta!";


StringStatistic st_1 = new(testovaciText);

st_1.text_info();
Console.WriteLine("Vypis nejkratsich slov:");
Console.WriteLine(string.Join("\n",st_1.short_words()));
Console.WriteLine("Vypis nejdelsich slov:");
Console.WriteLine(string.Join("\n",st_1.long_words()));
Console.WriteLine("Vypis podle abecedy:");
Console.WriteLine(string.Join("\n",st_1.alphabet()));