namespace MatrixLogic
{
    public class MatrixExtension
    {
        public static int[,] CreateMatrix(int row, int column)
        {
            int[,] P = new int[row, column];
            int lastRow = P.GetLength(0);
            int lastColumn = P.GetLength(1);

            for (int i = 0; i < lastRow; i++)
            {
                for (int j = 0; j < lastColumn; j++)
                {
                    Console.WriteLine($"Введите число для {i} строки, {j} столбца: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int num))
                    {
                        P[i, j] = num;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Установлено значение 0.");
                        P[i, j] = 0;
                    }
                }
            }
            return P;
        }

        public static void PrintMatrix(int[,] P)
        {
            int lastRow = P.GetLength(0);
            int lastColumn = P.GetLength(1);

            for (int i = 0; i < lastRow; i++)
            {
                for (int j = 0; j < lastColumn; j++)
                {
                    Console.Write($"{P[i, j],10} ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i],10} ");
            }
        }

        // ЗАДАЧА 1
        public static int[,] ReplaceMatrixZeroes(int[,] P)
        {
            int lastRow = P.GetLength(0);
            int lastColumn = P.GetLength(1);

            for (int i = 0; i < lastRow; i++)
            {
                for (int j = 0; j < lastColumn; j++)
                {
                    if (P[i, j] == 0)
                    {
                        P[i, j] = 500;
                    }
                }
            }
            return P;
        }

        // ЗАДАЧА 2
        public static int CountLastColumnNegatives(int[,] P)
        {
            int count = 0;
            int lastRow = P.GetLength(0);
            int lastColumnIndex = P.GetLength(1) - 1;

            for (int i = 0; i < lastRow; i++)
            {
                if (P[i, lastColumnIndex] < 0)
                {
                    count++;
                }
            }
            return count;
        }

        // ЗАДАЧА 3
        public static int[] GetRowPositiveCounts(int[,] P)
        {
            int lastRow = P.GetLength(0);
            int lastColumn = P.GetLength(1);
            int[] T = new int[lastRow];

            for (int i = 0; i < lastRow; i++)
            {
                int rowCount = 0;
                for (int j = 0; j < lastColumn; j++)
                {
                    if (P[i, j] > 0)
                    {
                        rowCount++;
                    }
                }
                T[i] = rowCount;
            }
            return T;
        }

        // ЗАДАЧА 4
        public static int[] GetNegativeElementsArray(int[,] P)
        {
            int lastRow = P.GetLength(0);
            int lastColumn = P.GetLength(1);
            List<int> negativeList = new List<int>();

            for (int i = 0; i < lastRow; i++)
            {
                for (int j = 0; j < lastColumn; j++)
                {
                    if (P[i, j] < 0)
                    {
                        negativeList.Add(P[i, j]);
                    }
                }
            }
            return negativeList.ToArray();
        }
    }
}