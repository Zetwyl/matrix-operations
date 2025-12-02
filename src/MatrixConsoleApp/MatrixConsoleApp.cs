using static MatrixLogic.MatrixExtension;

class MatrixConsoleApp
{
    static void Main(string[] args)
    {
        // 1. Создание и ввод матрицы P(4, 5)
        int[,] P = CreateMatrix(4, 5);
        Console.WriteLine("\n---> ИСХОДНАЯ МАТРИЦА P");
        PrintMatrix(P);

        // 2. ЗАДАЧА 1: Замена 0 на 500
        P = ReplaceMatrixZeroes(P);
        Console.WriteLine("\n---> ЗАДАЧА 1: После замены 0 НА 500");
        PrintMatrix(P);

        // 3. ЗАДАЧА 2: Подсчет отрицательных в последнем столбце
        int negativeCount = CountLastColumnNegatives(P);
        Console.WriteLine($"\n---> ЗАДАЧА 2: Отрицательных элементов в последних столбцац: {negativeCount}");

        // 4. ЗАДАЧА 3: Формирование массива T
        int[] T = GetRowPositiveCounts(P);
        Console.WriteLine("\n\n---> ЗАДАЧА 3: Количество положительных в каждой строке");
        PrintArray(T);

        // 5. ЗАДАЧА 4: Формирование массива D
        int[] D = GetNegativeElementsArray(P);
        Console.WriteLine("\n\n---> ЗАДАЧА 4: Все отрицательные элементы");
        PrintArray(D);

        Console.ReadLine();
    }
}