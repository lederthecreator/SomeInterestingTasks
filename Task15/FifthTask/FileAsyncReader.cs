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
        await Task.Run(async() =>
        {
            using var fs = new FileStream(_path, FileMode.Open);
            return await fs.ReadAsync(buffer);
        });
        var result = Encoding.Default.GetString(buffer);
        return result;
    }
}