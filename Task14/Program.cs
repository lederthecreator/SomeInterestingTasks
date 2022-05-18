// 1.Какими преимуществами обладает класс TPL?

// Thread по своей сути просто перераспределяет время между процессами, он переключается между ними. И если 
// Он не умеет задействовать все ядра процессора в равной степени - он работает на одном, пока остальные не 
// задействованы. Time Slicing
// TPL же позволяет задействовать все ядра процессора и реально распараллелить задачу

// 3. Task хранит в себе асинхронную задачу которая не возвращает результат (для результата требуется Task<T>
// Task позволяет создать задачу, запустить задачу, вызвать ожидание выполнения задачи и т.п.

#region Task4

//FourthTask.Run();

#endregion

#region Task7

//SeventhTask.Run();

#endregion

#region Task10

//TenthTask.Run();

#endregion

#region Task12

//TwelfthTask.Run();

#endregion

#region Task13

//ThirteenthTask.Run();

#endregion

#region Task14

using Task14;

//FourteenthTask.Run();

#endregion

#region Task16

//SixteenthTask.Run();

#endregion

#region Task17

//new SeventeenthTask().Run();

#endregion

#region Task18

new EighteenTask().Run();

#endregion

// Обедающие философы задачка на многопоточность (с одними вилками)