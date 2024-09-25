using static System.Convert;

namespace lb3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----Task 1-----");
        Console.WriteLine("Put elements of array with space-button: ");
        string[] putElementsTask1 = Console.ReadLine().Split(" ");
        OneDimensionalArray<int> array1 = new OneDimensionalArray<int>(Array.ConvertAll(putElementsTask1, s => int.Parse(s)));
        //array1.Push(5);
        // int[] RandomArray = new int[10];
        // for (int i = 0; i < RandomArray.Length; i++)
        // {
        //     Random rand = new Random();
        //     RandomArray[i] = rand.Next(1, 101);
        // }
        // OneDimensionalArray<int> array1 = new OneDimensionalArray<int>(RandomArray);
        Console.WriteLine(array1);
        array1.SumBetween();
        
        Console.WriteLine("-----Task 2-----");
        OneDimensionalArray<int> array2 = new OneDimensionalArray<int>();
        array2.CopyToEvenOdd(array1);
        Console.WriteLine("Array: " + array2);
        
        Console.WriteLine("-----Task 3-----");
        Console.WriteLine("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] array3 = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine($"Enter elements of row {i} (space-separated): ");
            string[] rowElements = Console.ReadLine().Split(" ");
            for (int j = 0; j < cols; j++)
            {
                array3[i, j] = int.Parse(rowElements[j]);
            }
        }

        TwoDimensionalArray<int> twoDimArray = new TwoDimensionalArray<int>(array3);
        Console.WriteLine("\n" + twoDimArray);
        Console.WriteLine("\nArifm of odd rows = " + twoDimArray.ArifmOdd());
        Console.WriteLine("-----Task 4-----");
        twoDimArray.Swap();
        Console.WriteLine("\nMatrix after the swap\n" + twoDimArray);
    }
}