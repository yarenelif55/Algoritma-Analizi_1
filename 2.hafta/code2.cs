using System;

class Program
{
    static int MatrixSum(int[,] matrix)
    {
        int total = 0;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                total += matrix[i, j];
            }
        }
        return total;
    }

    static void Main()
    {
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        
        Console.WriteLine(MatrixSum(matrix)); // Çıktı: 45
    }
}