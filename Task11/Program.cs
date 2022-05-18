//
//
// #region Task2
//
// using Task11;
// using Task7 = Task12.Task7;
//
// var thread = Thread.CurrentThread;
//
// //получаем имя потока
// Console.WriteLine($"Имя потока: {thread.Name}");
// thread.Name = "MainThread";
// Console.WriteLine($"Имя потока: {thread.Name}");
//  
// Console.WriteLine($"Запущен ли поток: {thread.IsAlive}");
// Console.WriteLine($"Id потока: {thread.ManagedThreadId}");
// Console.WriteLine($"Приоритет потока: {thread.Priority}");
// Console.WriteLine($"Статус потока: {thread.ThreadState}");
//
// #endregion
//
// #region Task3
//
// var newThread = new Thread(() =>
// {
//     for (int i = 0; i < 5; i += 1)
//     {
//         Console.WriteLine($"Thread Running : {Thread.CurrentThread.Name} " +
//                           $"State: {Thread.CurrentThread.ThreadState}");
//         Thread.Sleep(500);
//     }
// });
//
// Console.WriteLine($"NewThread State: {newThread.ThreadState}");
// newThread.Name = "NewThread";
// newThread.Start();
// newThread.Join();
// Console.WriteLine($"NewThread Ended: {newThread.ThreadState}");
//
// #endregion
//
// #region Task5
//
// var highestThread = new Thread(() =>
// {
//     for(int i = 0; i < 5; i+=1)
//     {
//         Console.WriteLine($"CurrentThreadName : {Thread.CurrentThread.Name}, Priority : {Thread.CurrentThread.Priority}");
//         Thread.Sleep(500);
//     }
// });
//
// Console.WriteLine("High Priority Thread Started");
// highestThread.Name = "HighPriorityThread";
// highestThread.Priority = ThreadPriority.Highest;
// highestThread.Start();
// highestThread.Join();
// Console.WriteLine("High Prioriry Thread Stopped");
//
// #endregion
//
// #region Task7
//
// var countThread = new Thread(() =>
// {
//     for (int i = 0; i < 9; i += 1)
//     {
//         Console.WriteLine($"Второй поток: {Math.Pow(i, 2)}");
//         Thread.Sleep(400);
//     }
// });
// countThread.Start();
//
// for (int i = 0; i < 9; i += 1)
// {
//     Console.WriteLine($"Главный поток {Math.Pow(i, 2)}");
//     Thread.Sleep(300);
// }
//
// #endregion
//
// #region Task10
// // Ограничение - можем передать только один параметр типа object?
// // То есть, скорее всего понадобится распаковка или создание специального типа для вызова делегата
//
// var parameterizedCountThread = new Thread(new ParameterizedThreadStart(Task7.EventCount));
// parameterizedCountThread.Start(9);
//
// for (int i = 0; i < 9; i += 1)
// {
//     Console.WriteLine($"Главный поток {Math.Pow(i, 2)}");
//     Thread.Sleep(300);
// }
//
// #endregion
//  
//
// // #region Task11
// //

using Task11;

//EleventhTask.Run();
// //
// // #endregion
//
// #region Task13
//
ThirteenTask.Run(10);
//
// #endregion
