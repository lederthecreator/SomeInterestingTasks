﻿// 2. Признаки: async в обьявлении, возвращаемые типы: void, Task, Task<T>, ValueTask<T>, внутри содержится await

// 3. Нельзя
using Task15;
using Task15.FifthTask;

#region Task4

//FourthTask.Run();

#endregion

#region Task5

// var writer = new FileAsyncWriter(Directory.GetCurrentDirectory() + "/data.txt");
// await writer.WriteAsync("12345678909876543212345678987654");
//
// var reader = new FileAsyncReader(Directory.GetCurrentDirectory() + "/data.txt");
// var result = reader.ReadAsync().Result;
// Console.WriteLine($"Result is: \n {result}");

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

// var task1 = SeventhTask.FactorialTaskLongAsync(3);
// var task2 = SeventhTask.FactorialTaskLongAsync(4);
// var task3 = SeventhTask.FactorialTaskLongAsync(5);
//
// var results = await Task.WhenAll(task1, task2, task3);
// Console.WriteLine($"{results[0]} {results[1]} {results[2]}");

#endregion

#region Task10

// try
// {
//     var res = await SeventhTask.FactorialTaskLongAsync(-10);
// }
// catch (Exception ex)
// {
//     Console.WriteLine(ex.Message);
// }

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
            
await Task.Delay(100);
cts.Cancel();
Console.WriteLine("CancellationToken " + await taskCTS);

#endregion

/*await PrintAsync();   // вызов асинхронного метода
Console.WriteLine("Некоторые действия в методе Main");

static void Print()
{
    Thread.Sleep(3000); // имитация продолжительной работы
    Console.WriteLine("Hello METANIT.COM");
}
static async Task PrintAsync()
{
    Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
    await Task.Run(() => Print());                // выполняется асинхронно
    Console.WriteLine("Конец метода PrintAsync");
}   */

/*PrintAsync();

Console.WriteLine($"Продолжаем работу в методе Main [{Thread.CurrentThread.ManagedThreadId}]"); //

Thread.Sleep(5000);

Console.WriteLine($"Завершаем работу Main [{Thread.CurrentThread.ManagedThreadId}]");

void Print()
{
    Thread.Sleep(3000);
    Console.WriteLine($"Hello! [{Thread.CurrentThread.ManagedThreadId}]");
}

async void PrintAsync()
{
    Console.WriteLine($"Начало работы PrintAsync [{Thread.CurrentThread.ManagedThreadId}]");
    await Task.Run(() => Print());
    Console.WriteLine($"Конец метода PrintAsync [{Thread.CurrentThread.ManagedThreadId}]");
}*/