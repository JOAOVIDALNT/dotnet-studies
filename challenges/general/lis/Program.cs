using System;

class Program
{
    static int LongestIncreasingSequence(int[] arr)
    {
        int n = arr.Length;
        int[] lis = new int[n];

        // Inicializa todos os valores de LIS como 1
        for (int i = 0; i < n; i++)
        {
            lis[i] = 1;
        }

        // Calcula o comprimento do LIS para cada elemento da lista
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                {
                    lis[i] = lis[j] + 1;
                }
            }
        }

        // Encontra o valor máximo no array LIS
        int maxLength = 0;
        for (int i = 0; i < n; i++)
        {
            if (lis[i] > maxLength)
            {
                maxLength = lis[i];
            }
        }

        return maxLength;
    }

    static void Main()
    {
        int[] arr = { 4, 3, 5, 1, 6 };
        int result = LongestIncreasingSequence(arr);
        Console.WriteLine(result); // Output: 3
    }
}
