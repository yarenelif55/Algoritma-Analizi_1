using System;

class Program
{
    static int FindMax(int[] arr)
    {
        int maxValue = arr[0];
        foreach (int num in arr)
        {
            if (num > maxValue)
            {
                maxValue = num;
            }
        }
        return maxValue;
    }

    static void Main()
    {
        int[] arr = {3, 1, 4, 1, 5, 9, 2, 6, 5, 3};
        Console.WriteLine(FindMax(arr)); // Çıktı: 9
    }
}