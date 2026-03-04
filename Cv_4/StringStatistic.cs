using System.Diagnostics.Contracts;

class StringStatistic
{
  private string text;
  char[] separators = {' ','.','!','?','\n',',',';'};

  public StringStatistic(string text)
  {
    this.text=text;
  }

  public void print_string()
  {
    Console.WriteLine(text);
  }

public void print_words(){
  string [] poleSlov = text.Split ( separators ,
    StringSplitOptions.RemoveEmptyEntries );
    Console.WriteLine (text);
    Console.WriteLine ( " --------------------------- " );
    foreach ( string slovo in poleSlov )
      {
        Console.WriteLine (slovo);
      }
  }
}