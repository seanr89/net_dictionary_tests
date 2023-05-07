using System.Diagnostics;
using Spectre.Console;

Console.Clear();
AnsiConsole.Write(
    new FigletText("Dictionary Tester")
        .LeftJustified()
        .Color(Color.Red));

var count = AnsiConsole.Ask<int>("Enter a [blue]Count[/]?");

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
            testDictionary.Add(Guid.NewGuid(), listSet[i]);
        }

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

    //TODO Creator Summary
    var summary = new Summary(){
        StartCount = count,
        DictionaryCount = testDictionary.Count,
        MemoryAllocation = finalMemory
    };
    SummaryWriter.WriteOrUpdateSummaryToFile(summary);
}