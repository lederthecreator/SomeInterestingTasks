// 2. Признаки: async в обьявлении, возвращаемые типы: void, Task, Task<T>, ValueTask<T>, внутри содержится await

// 3. Нельзя
using Task15;
using Task15.FifthTask;

#region Task4

FourthTask.Run();

#endregion

#region Task5

// var writer = new FileAsyncWriter(Directory.GetCurrentDirectory() + "/data.txt");
// await writer.WriteAsync("12345678909876543212345678987654");
//
// var reader = new FileAsyncReader(Directory.GetCurrentDirectory() + "/data.txt");
// var result = reader.ReadAsync().Result;
// Console.WriteLine($"Result is: \n {result}");

//Сделать копирование файлов 

#endregion

#region Task6

// void, Task, Task<T>, ValueTask<T>

#endregion

#region Task7

// Console.WriteLine("Before Task7");
// await SeventhTask.Run();
// Console.WriteLine("After Task7");

#endregion

#region Task8

// Смысл...

#endregion

#region Task9

// var task1 = SeventhTask.FactorialTaskIntAsync(3);
// var task2 = SeventhTask.FactorialTaskIntAsync(4);
// var task3 = SeventhTask.FactorialTaskIntAsync(5);
//
// //var results = await Task.WhenAll(task1, task2, task3);
// Console.WriteLine($"{await task1} {await task2} {await task3}");

// Опасность WaitAll прочитать

#endregion

#region Task10

try
{
    var res = await SeventhTask.FactorialTaskLongAsync(-10, new CancellationTokenSource());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

#endregion

#region Task11

/*var task1 = SeventhTask.FactorialTaskLongAsync(-10);
var task2 = SeventhTask.FactorialTaskLongAsync(-10);
var task3 = SeventhTask.FactorialTaskLongAsync(-10);

var allTasks = Task.WhenAll(task1, task2, task3);

try
{
    await allTasks;
}
catch (Exception ex)
{
    await allTasks;
    Console.WriteLine(ex.Message);
    Console.WriteLine(allTasks.IsFaulted);
    if (allTasks.Exception?.InnerExceptions is not null)
    {
        foreach (var innerEx in allTasks.Exception.InnerExceptions)
        {
            Console.WriteLine(innerEx.Message);
        }
    }
}*/

#endregion

#region Task12

var cts = new CancellationTokenSource();

Task<int> taskCTS = Task.Run(() =>
{
    int a = 0;
    while(true)
    {
        if (cts.IsCancellationRequested)
            return a;
        a++;
    }
});
            
//await Task.Delay(100);
cts.CancelAfter(100);
Console.WriteLine("CancellationToken " + await taskCTS);

#endregion