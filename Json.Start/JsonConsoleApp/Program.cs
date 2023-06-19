using AbstractionPolymorphismProject;

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
            }
        }
        else
        {
            Console.WriteLine("Nu a fost furnizată o cale către fișierul text.");
        }

        Value value = new Value();

         if (value.Match(textJson).Success() && value.Match(textJson).RemainingText() == "")
         {
             Console.WriteLine("Textul introdus este un Json valid");
         }
         else
         {
             Console.WriteLine("Textul introdus nu este un Json valid");
         }
        
        Console.ReadKey();
    }
}