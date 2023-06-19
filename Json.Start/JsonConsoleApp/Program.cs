using AbstractionPolymorphismProject;

class Program
{
    static void Main(string[] args)
    {
        string textJson = "";
        if (args.Length > 0)
        {
            string filePath = args[0];
            using (StreamReader sr = new StreamReader(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                textJson = fileContent;
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