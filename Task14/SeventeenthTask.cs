namespace Task14;
//using CSharpLib;

public class SeventeenthTask
{
    private long _size = 0;
    private List<FileInfo> _files = new();
    private AutoResetEvent counterHandler = new AutoResetEvent(true);
    
    public SeventeenthTask(){}
    public void Run()
    {
        var path = @"C:\Program Files\JetBrains\JetBrains Rider 2021.2.1";
        Parallel.Invoke(() => CountOfFiles(path));
        Task.WaitAll();
        ShowFiles();
        Console.WriteLine($"Result sum is: {_size}, count of files: {_files.Count}");
    }

    private void ShowFiles()
    {
        _files.ForEach(file =>
        {
            Console.WriteLine($"Name: {Path.GetFileName(file.Name)}, Size: {file.Length} bytes");
            _size += file.Length;
        });
    }

    private void CountOfFiles(string path)
    {
        var files = Directory.GetFiles(path).ToList();
        foreach (var file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            AddToCount(fileInfo);
        }
        var directories = Directory.GetDirectories(path).ToList();
        if (directories.Count != 0)
            Parallel.ForEach(directories, CountOfFiles);
    }
    
    private void AddToCount(FileInfo fileInfo)
    {
        counterHandler.WaitOne();
        _files.Add(fileInfo);
        counterHandler.Set();
    }
}

internal record File(string Path, long Size);