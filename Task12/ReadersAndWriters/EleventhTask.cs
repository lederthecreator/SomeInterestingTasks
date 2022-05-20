namespace Task12.ReadersAndWriters;

public class EleventhTask
{
    public static void Run()
    {
        var db = new Database();
        // var writer = new Writer(db);
        // var writerThread = new Thread(writer.Write);
        // writerThread.Start();
        // for (int i = 0; i < 5; i += 1)
        // {
        //     var reader = new Reader(db);
        //     var readerThread = new Thread(reader.Read);
        //     readerThread.Name = $"{i + 1}";
        //     readerThread.Start();
        //     //сделать генератор потоков в котором отправляется некий Person в библиотеку
        // }
        var generator = new Generator(db);
        generator.Start();
    }
}