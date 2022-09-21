namespace lesson_17_2;

// Local Functions { static }
// Ildasm
// Dotfuscator

class HN
{
    static void DoSomething()
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        Console.WriteLine("DoSomething");

        int nh = 259;

        void Helper()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        
            Console.WriteLine("DoSomething.Helper");
            Console.WriteLine(nh);
        }

        static void HelperWithStatic()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("DoSomething.Helper With Static");
            //Console.WriteLine(nh); // error
        }

        Helper();
        HelperWithStatic();
    }

    static void Main()
    {
        DoSomething();
        
        Console.ResetColor();
    }
}