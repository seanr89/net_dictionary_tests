using System.Diagnostics;
using System.Text;
using Spectre.Console;

AnsiConsole.Write(
    new FigletText("Rabbit Sender Auto")
        .LeftJustified()
        .Color(Color.Red));

var count = AnsiConsole.Ask<int>("Enter a [blue]count[/]?");
using (Process proc = Process.GetCurrentProcess())
{
    var testDictionary = new Dictionary<Guid, ValueModel>();

    for(int i = 0; i < count; i++)
    {
        //AnsiConsole.MarkupLine($"current : [green]{i}[/] increment");
        var rec = BogusCreator.CreateModel();
        testDictionary.Add(Guid.NewGuid(), rec);
        //Thread.Sleep(5);
    }

    var memory = 0.0;
    // The proc.PrivateMemorySize64 will returns the private memory usage in byte.
    // Would like to Convert it to Megabyte? divide it by 2^20
    // memory = proc.PrivateMemorySize64 / (1024*1024);
    memory = proc.PrivateMemorySize64;
    Console.WriteLine($"Memory: {memory}");

    Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
    long totalBytesOfMemoryUsed = currentProcess.WorkingSet64 / 1024;
    Console.WriteLine($"Or This: {totalBytesOfMemoryUsed} kB");


    AnsiConsole.MarkupLine($"Dictionary Count: [green]{testDictionary.Count}[/]");
}