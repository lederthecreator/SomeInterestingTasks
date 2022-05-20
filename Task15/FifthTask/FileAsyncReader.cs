using System.Text;

namespace Task15.FifthTask;

public class FileAsyncReader
{
    private string _path;

    public FileAsyncReader(string path)
    {
        _path = path;
    }

    public async Task<string> ReadAsync()
    {
        byte[] buffer = new byte[1024];
        await Task.Run(() =>
        {
            using var fs = new FileStream(_path, FileMode.Open);
            fs.Read(buffer);
        });
        var result = Encoding.Default.GetString(buffer);
        return result;
    }
}