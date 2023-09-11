// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение 
// двух матриц. Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

void FillArray(int[,] array) //метод заполнения массива 
{
    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            array[i, j] = new Random().Next(1, 11);
            // Console.Write(array[i, j] + " "); 
        }
        // Console.WriteLine(); 
    }   
}

void PrintArray(int[,] array) // метод печати массива 
{
    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            Console.Write(array[i, j] + "\t"); 
        }
        Console.WriteLine(); 
    }
}

Console.WriteLine("Введите число строк 1-й матрицы: ");
int array1Line = int.Parse(Console.ReadLine());
Console.WriteLine("Введите число столбцов 1-й матрицы и строк 2-й: ");
int array2LineArray1Column = int.Parse(Console.ReadLine());
Console.WriteLine("Введите число столбцов 2-й матрицы: ");
int Array2Column = int.Parse(Console.ReadLine());

int[,] array1 = new int[array1Line,array2LineArray1Column];
FillArray(array1);
Console.WriteLine($"Первая матрица: ");
PrintArray(array1);

int[,] array2 = new int[array2LineArray1Column, Array2Column];
FillArray(array2);
Console.WriteLine($"Вторая матрица: ");
PrintArray(array2);

int[,] resultMatrix = new int[array1Line, Array2Column];

void GetArraysProduct(int[,] array1, int[,] array2, int[,] resultMatrix)
{
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
            int sum = 0;
            for (int k = 0; k < array1.GetLength(1); k++)
      {
        sum = sum + array1[i,k] * array2[k,j];
      }
      resultMatrix[i,j] = sum;
    }
  }
}
GetArraysProduct(array1, array2, resultMatrix);
Console.WriteLine($"Произведение первой и второй матриц равно: ");
PrintArray(resultMatrix);