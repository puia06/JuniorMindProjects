using AbstractionPolymorphismProject;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string textJson = "";
        if (args.Length > 0)
        {
            string filePath = args[0];
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    textJson = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"A apărut o eroare la citirea fișierului: {e.Message}");
                return;
            }
        }

        else
        {
            Console.WriteLine("Nu a fost furnizată o cale către fișierul text.");
            return;
        }

        Value value = new Value();
        StringView text = new StringView(textJson);
        StringView expectedResult = new StringView(textJson, textJson.Length);
        var matchResult = value.Match(text);

        if (expectedResult.CompareTo(matchResult.RemainingText()))
        {
            Console.WriteLine("Textul introdus este un Json valid");
        }
        else
        {
            Console.WriteLine("Textul introdus nu este un Json valid");
        }
    }
} 