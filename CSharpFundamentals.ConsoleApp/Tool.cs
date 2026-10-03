namespace CSharpFundamentals.ConsoleApp;

public class Tool
{
    public static string MyWriteLine(string question)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(question);

        Console.ForegroundColor = ConsoleColor.Gray;
        return Console.ReadLine();
    }

    public static void CreateLine()
    {
        Console.WriteLine("----------------------------");
    }
}
