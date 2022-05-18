namespace Task14;

public class SeventeenthTask
{
    private int _count = 0;
    private AutoResetEvent counterHandler = new AutoResetEvent(true);
    public static void Run()
    {
        var path = @"C:\Users\eb3.stazher\AppData\Local\JetBrains\Toolbox\apps\Rider\ch-0\221.5591.20\plugins";
        var directories = Directory.GetDirectories(path).ToList();
        var dirCount = directories.Count;
        Parallel.ForEach(directories, CountOfFiles);
    }

    private static void CountOfFiles(string path, ParallelLoopState state)
    {
        var directories = Directory.GetDirectories(path).ToList();
        
    }

    
    private void AddToCount(int val)
    {
        counterHandler.WaitOne();
        _count += val;
        counterHandler.Set();
    }
}