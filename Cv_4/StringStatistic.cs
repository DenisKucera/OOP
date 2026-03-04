using System.Diagnostics.Contracts;

class StringStatistic
{
  private string text;
  string [] wordArr = {};
  public char[] words = {' ','.','!','?','\n',',',';',')','('};
  public char[] sentences = {'.','!','?'};
  char[] lines = {'\n'};


  public StringStatistic(string text)
  {
    this.text=text;
  }

  public void print_string()
  {
    Console.WriteLine(text);
  }

public int parser(char [] pars_char){
    wordArr = text.Split ( pars_char , StringSplitOptions.RemoveEmptyEntries );
    int cnt = 0;
    foreach (string slovo in wordArr)
      {
        cnt++;
      }
      return cnt;
  }


  public void text_info()
  {
    Console.WriteLine("Pocet vet:");
    Console.WriteLine(parser(sentences));
    Console.WriteLine("Pocet radku:");
    Console.WriteLine(parser(lines));
    Console.WriteLine("Pocet slov:");
    Console.WriteLine(parser(words));
  }


    public List<string> alphabet()
        {
            var list = new List<string>();
            foreach (var word in wordArr)
            {
                list.Add(word);
            }
            list.Sort();
            return list;
        }

  public List<string> long_words()
  {
    var ord=wordArr.OrderBy(x => x.Length).ToList<string>();
            ord.Reverse();
            var list = new List<string>();
            var len = 0;
            foreach (var word in ord) {
                if (word.Length >= len) {
                    len = word.Length;
                    list.Add(word);
                }
            }
      return list;
  }

  public List<string> short_words()
  {
      var ord = wordArr.OrderBy(aux => aux.Length).ToList();
      var list = new List<string>();
            var len = 100;
            foreach (var word in ord)
            {
                if (word.Length <= len)
                {
                    len = word.Length;
                    list.Add(word);
                }
            }

            return list;
        }
  }

