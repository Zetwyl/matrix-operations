using static MatrixLogic.MatrixExtension;

namespace MatrixLogic.Tests
{

    [TestClass]
    public class MatrixTests
    {
        // --- Тесты для CreateMatrix (Покрытие ввода) ---
    
        [TestMethod]
        public void CreateMatrix_ValidAndInvalidInput_ReturnsCorrectMatrix()
        {
            // Имитация ввода: 1, 2 (корректные) и abc (некорректный), 4 (корректный)
            string simulatedInput = "1\n2\nabc\n4\n"; 

            using (StringReader sr = new StringReader(simulatedInput))
            {
                // Сохраняем оригинальный Console.In и перенаправляем на наш имитированный ввод
                TextReader originalConsoleIn = Console.In;
                Console.SetIn(sr); 
            
                int[,] result = CreateMatrix(2, 2); 

                // Восстанавливаем Console.In
                Console.SetIn(originalConsoleIn);

                // Ожидаемый результат: 
                // P[0,0]=1, P[0,1]=2, P[1,0]=0 (из-за "abc"), P[1,1]=4
                int[,] expected = new int[,] { { 1, 2 }, { 0, 4 } };

                CollectionAssert.AreEqual(expected, result, "Матрица создана некорректно или ветки ввода не покрыты.");
            }
        }


        // --- Тесты для ReplaceMatrixZeroes (Покрытие ветки '== 0' True/False) ---
    
        [TestMethod]
        public void ReplaceMatrixZeroes_ContainsZeroes_ReplacesThemWith500()
        {
            // Покрывает ветку IF (P[i, j] == 0) -> TRUE
            int[,] input = new int[,] { { 1, 0 }, { 0, -5 } };
            int[,] expected = new int[,] { { 1, 500 }, { 500, -5 } };
            int[,] result = ReplaceMatrixZeroes(input);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReplaceMatrixZeroes_NoZeroes_ReturnsUnchangedMatrix()
        {
            // Покрывает ветку IF (P[i, j] == 0) -> FALSE
            int[,] input = new int[,] { { 1, 10 }, { -2, -5 } };
            int[,] expected = new int[,] { { 1, 10 }, { -2, -5 } };
            int[,] result = ReplaceMatrixZeroes(input);
            CollectionAssert.AreEqual(expected, result);
        }


        // --- Тесты для CountLastColumnNegatives (Покрытие ветки '< 0' True/False) ---
    
        [TestMethod]
        public void CountLastColumnNegatives_HasNegatives_ReturnsCorrectCount()
        {
            // Покрывает ветку IF (P[i, lastColumnIndex] < 0) -> TRUE
            // Последний столбец: -5, 0, -10
            int[,] input = new int[,] { { 1, -5 }, { 0, 0 }, { 2, -10 } }; 
            int result = CountLastColumnNegatives(input);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CountLastColumnNegatives_NoNegatives_ReturnsZero()
        {
            // Покрывает ветку IF (P[i, lastColumnIndex] < 0) -> FALSE
            // Последний столбец: 5, 0, 10
            int[,] input = new int[,] { { 1, 5 }, { 0, 0 }, { 2, 10 } }; 
            int result = CountLastColumnNegatives(input);
            Assert.AreEqual(0, result);
        }


        // --- Тесты для GetRowPositiveCounts (Покрытие ветки '> 0' True/False) ---
    
        [TestMethod]
        public void GetRowPositiveCounts_MixedElements_ReturnsCorrectCounts()
        {
            // Покрывает ветку IF (P[i, j] > 0) -> TRUE
            // Строка 1: 1 (1 положительный)
            // Строка 2: 5, 6 (2 положительных)
            int[,] input = new int[,] { { 1, 0, -2 }, { 5, 6, -3 } };
            int[] expected = new int[] { 1, 2 };
            int[] result = GetRowPositiveCounts(input);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetRowPositiveCounts_OnlyNegativeOrZero_ReturnsZeroCounts()
        {
            // Покрывает ветку IF (P[i, j] > 0) -> FALSE
            int[,] input = new int[,] { { -1, 0, -2 }, { -5, 0, -3 } };
            int[] expected = new int[] { 0, 0 };
            int[] result = GetRowPositiveCounts(input);
            CollectionAssert.AreEqual(expected, result);
        }


        // --- Тесты для GetNegativeElementsArray (Покрытие ветки '< 0' True/False) ---
    
        [TestMethod]
        public void GetNegativeElementsArray_HasNegatives_ReturnsCorrectArray()
        {
            // Покрывает ветку IF (P[i, j] < 0) -> TRUE
            int[,] input = new int[,] { { 1, -2 }, { 3, -4 } };
            int[] expected = new int[] { -2, -4 };
            int[] result = GetNegativeElementsArray(input);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetNegativeElementsArray_NoNegatives_ReturnsEmptyArray()
        {
            // Покрывает ветку IF (P[i, j] < 0) -> FALSE
            int[,] input = new int[,] { { 1, 2 }, { 3, 4 }, { 0, 0 } };
            int[] expected = new int[] { };
            int[] result = GetNegativeElementsArray(input);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}