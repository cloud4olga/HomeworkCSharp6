// Задача 59: Задайте двумерный массив из целых чисел. Напишите программу, которая 
// удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Наименьший элемент - 1, на выходе получим
// следующий массив:
// 9 4 2
// 2 2 6
// 3 4 7

int[,] GetMatrixLength() //метод определения размера массива
{
    Console.WriteLine("Введите колчество строк: ");
    int arrayLine = Convert.ToInt32(Console.ReadLine()); 
    Console.WriteLine("Введите колчество столбцов: "); 
    int arrayColumn = Convert.ToInt32(Console.ReadLine());
    int[,] matrix = new int[arrayLine, arrayColumn];
    return matrix; 
}

void FillArray(int[,] array) //метод заполнения массива 
{
    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            array[i, j] = new Random().Next(1, 10);
            // Console.Write(array[i, j] + " "); 
        }
    }
}

void PrintArray(int[,] array) //метод печати массива 
{
    for (int i = 0; i < array.GetLength(0); i++) 
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            Console.Write(array[i, j] + " "); 
        }
        Console.WriteLine(); }
}

int[,] array = GetMatrixLength();
FillArray(array);
PrintArray(array);

int[,] positionMinElement = new int[1, 2];
positionMinElement = FindMinElement(array, positionMinElement);
// Console.Write($"Позиция минимального элемента: \t");
// PrintArray(positionMinElement);

int[,] FindMinElement(int[,] array, int[,] positionMinElement)
{
    int minElement = array[0, 0];
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (minElement > array[i, j])
            {
                positionMinElement[0, 0] = i;
                positionMinElement[0, 1] = j;
                minElement = array[i, j];
            }
        }
    }
    Console.WriteLine($"Минимальный элемент массива = {minElement} с адресом [{positionMinElement[0, 0]},{positionMinElement[0, 1]}]");
    return positionMinElement;
}



int[,] DeleteLines(int[,] array, int[,] positionMinElement)
{
    int[,] newArray = new int[array.GetLength(0)-1,array.GetLength(1)-1];
    int rowIndex = 0;
    int colIndex = 0;
    for (int i = 0; i < array.GetLength(0); i++)
        {
            if (i != positionMinElement[0,0]){
            for (int j = 0; j < array.GetLength(0); j++)
            {
                if (j != positionMinElement[0,1])
                {
                    newArray[rowIndex,colIndex] = array[i,j];
                    colIndex++;
                }
                
            }
            rowIndex++;
            colIndex = 0;
            }
        }
        return newArray;
}


Console.WriteLine($"Новый массив: ");
PrintArray(DeleteLines(array, positionMinElement));