using System.Text;

namespace Task15.FifthTask;

public class FileAsyncWriter
{
    private string _path;

    public FileAsyncWriter(string path)
    {
        _path = path;
    }

    public async Task WriteAsync(string data)
    {
        await Task.Run(() =>
        {
            using var fs = new FileStream(_path, FileMode.OpenOrCreate);
            Encoding enc = new UTF8Encoding();
            var bytes = enc.GetBytes(data);
            fs.Write(bytes);
        });
    }
}