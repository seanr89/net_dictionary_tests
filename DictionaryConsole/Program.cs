using System.Diagnostics;
using System.Text;
using Spectre.Console;

Console.Clear();
AnsiConsole.Write(
    new FigletText("Dictionary Tester")
        .LeftJustified()
        .Color(Color.Red));

var count = AnsiConsole.Ask<int>("Enter a [blue]count[/]?");
int increment = 0;
var startingMemory = 0.0;
var finalMemory = 0.0;
using (Process proc = Process.GetCurrentProcess())
{
    var testDictionary = new Dictionary<Guid, ValueModel>();
    do{

        var listSet = BogusCreator.CreateModelList(count); 
        for(int i = 0; i < count; i++)
        {
            //AnsiConsole.MarkupLine($"current : [green]{i}[/] increment");
            //var rec = BogusCreator.CreateModel();
            testDictionary.Add(Guid.NewGuid(), listSet[i]);
        }

        //var memory = 0.0;
        // The proc.PrivateMemorySize64 will returns the private memory usage in byte.
        // Would like to Convert it to Megabyte? divide it by 2^20
        // memory = proc.PrivateMemorySize64 / (1024*1024);
        // memory = proc.PrivateMemorySize64;
        // Console.WriteLine($"Memory: {memory}");

        Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
        long totalBytesOfMemoryUsed = currentProcess.WorkingSet64 / (1024*1024);
        //Console.WriteLine($"ProcessMemory: {totalBytesOfMemoryUsed} kB");


        //AnsiConsole.MarkupLine($"Dictionary Count: [green]{testDictionary.Count}[/] at increment {increment}");
        if(increment == 0)
            startingMemory = totalBytesOfMemoryUsed;

        increment++; 
        if(increment > count)
            finalMemory = totalBytesOfMemoryUsed;
    }while(increment <= count);

    //TODO add memory settings here
    var value = String.Format("{0:N}", testDictionary.Count);
    AnsiConsole.MarkupLine($"Starting Memory: [green]{startingMemory}[/] mB and final Memory: [green]{finalMemory}[/] mB");
    AnsiConsole.MarkupLine($"Dictionary Count: [green]{value}[/] at increment {increment}");
}