using AbstractionPolymorphismProject;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Introdu un text pe a afla daca este un JSON valid");
        string line;
        string textJson = "";
        while ((line = Console.ReadLine()) != string.Empty)
        {
            textJson += line;
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