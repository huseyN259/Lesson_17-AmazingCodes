namespace lesson_17_3;

using Serilog;

// Log
// Serilog
// NLog
// log4net

class HN
{
    static void Main()
    {
        string format = @"[{Timestamp: HH:mm:ss} {Level}] {Message} {Exception} {EnvironmentName} {ThreadId} {NewLine} ";

        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("myLog.txt", outputTemplate: format)
            .WriteTo.Console(outputTemplate: format)
            .Enrich.WithEnvironmentName()
            .Enrich.WithThreadId()
            .CreateLogger();

        Log.Information("InfoMessage");
        Log.Warning("WarningMessage");
        Log.Error(new NullReferenceException("NRE"), "ErrorMessage");
        Log.Fatal("FatalMessage");

        new Thread(() =>
        {
            Console.WriteLine("\nNH");
        }).Start();
    }
}