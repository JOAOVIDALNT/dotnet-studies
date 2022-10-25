
/* LISTAS */

List<string> stringList = new List<string>();

stringList.Add("SP");
stringList.Add("BA");
stringList.Add("PE");

Console.WriteLine($"Items on the list: {stringList.Count} - Capacity: {stringList.Capacity}");

stringList.Add("RJ");

Console.WriteLine($"Items on the list: {stringList.Count} - Capacity: {stringList.Capacity}");

stringList.Add("RS");
stringList.Remove("PE");

Console.WriteLine($"Items on the list: {stringList.Count} - Capacity: {stringList.Capacity}");



// Console.WriteLine("------- FOR -------");
// for (int i = 0; i < stringList.Count; i++)
// {
//     Console.WriteLine($"Position nº{i} - {stringList[i]}");
// }

// Console.WriteLine("----- FOREACH -----");
// int foreachCounter2 = 0;
// foreach (string item in stringList)
// {
//     Console.WriteLine($"Position nº{foreachCounter2} - {item}");
//     foreachCounter2++;
// }







/* ARRAYS */

// int[] arrayInt = new int[3];

// arrayInt[0] = 66;
// arrayInt[1] = 67;
// arrayInt[2] = 68;

// int[] arrayIntTwice = new int[arrayInt.Length * 2];
// Array.Copy(arrayInt, arrayIntTwice, arrayInt.Length); // copiando de, para, com a capacidade x


// // Array.Resize(ref arrayInt, arrayInt.Length * 2); // ref e tamanho depois da virgula


// // // PERCORRENDO ARRAY

// // Console.WriteLine("------- FOR -------");
// // for (int i = 0; i < arrayInt.Length; i++)
// // {
// //     Console.WriteLine($"Position nº{i} - {arrayInt[i]}");
// // }


// // Console.WriteLine("----- FOREACH -----");
// // int foreachCounter = 0;
// // foreach (int value in arrayInt)
// // {
// //     Console.WriteLine($"Position nº{foreachCounter} - {value}");
// //     foreachCounter++;
// // }

