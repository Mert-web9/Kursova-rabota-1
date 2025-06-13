namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int[]> rowsList = new List<int[]>();
            Console.WriteLine("Въведете матрица, след това натиснете Enter:");

            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    break;

                string[] parts = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] row = Array.ConvertAll(parts, int.Parse);
                rowsList.Add(row);
            }

            int rows = rowsList.Count;
            if (rows == 0)
            {
                Console.WriteLine("Не е въведена матрица.");
                return;
            }
            int cols = rowsList[0].Length;

           
            for (int i = 1; i < rows; i++)
            {
                if (rowsList[i].Length != cols)
                {
                    Console.WriteLine("Грешка: Редовете имат различен брой елементи.");
                    return;
                }
            }

            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = rowsList[i][j];

            int max = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;

            
            for (int j = 0; j < cols; j++)
            {
                if (matrix[0, j] > max)
                {
                    max = matrix[0, j];
                    maxRow = 0;
                    maxCol = j;
                }
                if (matrix[rows - 1, j] > max)
                {
                    max = matrix[rows - 1, j];
                    maxRow = rows - 1;
                    maxCol = j;
                }
            }

            for (int i = 1; i < rows - 1; i++)
            {
                if (matrix[i, 0] > max)
                {
                    max = matrix[i, 0];
                    maxRow = i;
                    maxCol = 0;
                }
                if (matrix[i, cols - 1] > max)
                {
                    max = matrix[i, cols - 1];
                    maxRow = i;
                    maxCol = cols - 1;
                }
            }

            Console.WriteLine("\nМатрицата с маркирано най-голямо ръбово число:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == maxRow && j == maxCol)
                        Console.Write(matrix[i, j] + "*\t");
                    else
                        Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nНай-голямото ръбово число е: {max}");
        }
    }
}
