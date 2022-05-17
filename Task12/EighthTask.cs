namespace Task12;

public class EighthTask
{
    public static void Run()
    {
        var lib = new Library();

        for (int i = 0; i < 5; i += 1)
        {
            var reader = new Reader(i, lib);
            reader.Read();
        }
    }
}