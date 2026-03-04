// See https://aka.ms/new-console-template for more information

string testovaciText = "Toto je retezec predstavovany nekolika radky,\n"
+ "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
+ "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
+ "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
+ "posledni veta!";


StringStatistic st_1 = new(testovaciText);
//st_1.print_string();
st_1.print_words();