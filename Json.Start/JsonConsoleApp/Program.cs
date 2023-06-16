using AbstractionPolymorphismProject;

class Program
{
    static void Main()
    {
        string textJson = "";
        try
        {
            using (var sr = new StreamReader("Sample.txt"))
            {
                textJson = sr.ReadToEnd();
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
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