public static class SummaryWriter{
    
    public static void WriteOrUpdateSummaryToFile(Summary sum)
    {
        string path = @"RunFile.txt";
        // This text is added only once to the file.
        // if (!File.Exists(path))
        // {
        //     // Create a file to write to.
        //     using (StreamWriter sw = File.CreateText(path))
        //     {
        //         sw.WriteLine("Hello");
        //         sw.WriteLine("And");
        //         sw.WriteLine("Welcome");
        //     }	
        // }

        // This text is always added, making the file longer over time
        // if it is not deleted.
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine($"Summary: {DateTime.UtcNow.ToShortDateString()} with stats: {sum.ToString()}");
        }	
    }
}