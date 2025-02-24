using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Farklı dizi boyutları
        int[] diziler = { 100, 500, 1000, 2000, 5000 };
        int k = 10; // k. en küçük elemanı bul

        foreach (var boyut in diziler)
        {
            int[] dizi = new int[boyut];

            // Diziyi rastgele sayılarla doldur
            var r = new Random();
            for (int i = 0; i < boyut; i++)
            {
                dizi[i] = r.Next(1, 10000);
            }

            Console.WriteLine($"Dizi Boyutu: {boyut}");

            // Yöntem 1: Diziyi sırala ve k. elemanı return et
            var diziKopya1 = (int[])dizi.Clone(); // Dizi kopyala
            var stopwatch1 = Stopwatch.StartNew();
            int enKucuk1 = FindKthSmallestSorted(diziKopya1, k);
            stopwatch1.Stop();

            Console.WriteLine($"Yöntem 1 (Sıralama): k. en küçük eleman = {enKucuk1}, Geçen zaman: {stopwatch1.ElapsedMilliseconds} ms");

            // Yöntem 2: İlk k elemanı sırala, kalanları insertion sort ile karşılaştır
            var diziKopya2 = (int[])dizi.Clone(); // Dizi kopyala
            var stopwatch2 = Stopwatch.StartNew();
            int enKucuk2 = FindKthSmallestInsertion(diziKopya2, k);
            stopwatch2.Stop();

            Console.WriteLine($"Yöntem 2 (İlk k sırala + Insertion): k. en küçük eleman = {enKucuk2}, Geçen zaman: {stopwatch2.ElapsedMilliseconds} ms");
            Console.WriteLine();
        }
    }

    static int FindKthSmallestSorted(int[] dizi, int k)
    {
        Array.Sort(dizi);
        return dizi[k - 1];
    }

    static int FindKthSmallestInsertion(int[] dizi, int k)
    {
        // İlk k elemanı sırala
        for (int i = 1; i < k; i++)
        {
            int key = dizi[i];
            int j = i - 1;
            while (j >= 0 && dizi[j] > key)
            {
                dizi[j + 1] = dizi[j];
                j--;
            }
            dizi[j + 1] = key;
        }

        // Kalan elemanları karşılaştır
        for (int i = k; i < dizi.Length; i++)
        {
            if (dizi[i] < dizi[k - 1])
            {
                // k. elemandan küçükse, yer değiştir
                int key = dizi[i];
                int j = k - 1;
                while (j >= 0 && dizi[j] > key)
                {
                    dizi[j + 1] = dizi[j];
                    j--;
                }
                dizi[j + 1] = key;
            }
        }

        return dizi[k - 1];
    }
}
