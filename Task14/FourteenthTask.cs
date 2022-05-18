namespace Task14;

public class FourteenthTask
{
    public static void Run()
    {
        var taskCreateList = new Task<List<int>>(CreateList);
        taskCreateList.Start();

        var taskFillList = taskCreateList.ContinueWith(task => FillList(task.Result));

        var taskPrintList = taskFillList.ContinueWith(task => PrintList(task.Result));

        var taskSumList = taskFillList.ContinueWith(task => SumOfList(task.Result));

        Console.WriteLine(taskSumList.Result);
    }

    private static List<int> CreateList() => new List<int>();

    private static List<int> FillList(List<int> list)
    {
        for (int i = 0; i < 10; i += 1)
        {
            list.Add(i);
        }

        return list;
    }

    private static void PrintList(List<int> list)
    {
        var str = string.Join(" ", list);
        Console.WriteLine(str);
    }

    private static int SumOfList(List<int> list)
    {
        var sum = 0;
        list.ForEach(item => sum += item);
        return sum;
    }
}