namespace HT7;

class Program
{
    static void Main(string[] args)
    {
        MainManu();
    }
    private static bool MainManu()
    {
        Console.Clear();
        Console.WriteLine("1) Two-Dimensional Array");
        Console.WriteLine("2) Array Search;");
        Console.WriteLine("3) Arithmetic mean of the column;");
        Console.WriteLine("4) Exit.");
        Console.Write("\nSelect: ");
        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Enter number of lines: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Enter number of columns: ");
                int col = int.Parse(Console.ReadLine());
                FillArray(row, col);
                return true;
            case "2":
                int row = 3;
                int col = 4;
                double[,] arr = GenArray(row, col);
                Console.Write("Enter the index of the position separated by a space, where the first digit is the line, the second column: ");
                int[] coordinatys = GetCoordinates();
                if (coordinatys[0] > arr.GetLength(0) || coordinatys[1] > arr.GetLength(1))
                {
                    PrintArray(arr);
                    Console.WriteLine($"\n{coordinatys[0]} {coordinatys[1]} -> This index does not exist.");
                }
                else
                {
                    PrintArray(arr);
                    Console.WriteLine($"\n {arr[coordinatys[0], coordinatys[1]]}");
                }

                return true;
            case "3":
                int row = 3;
                int col = 4;
                double[,] arr = FillArray(row, col);
                double[] result = AithmeticAean(arr);
                Console.Write("Arithmetic mean of each column: ");
                PrintArray(result);
                return true;
            case "4":
                return false;
            default:
                return false;
        }
    }
    private static double[,] FillArray(int row, int col)
    {
        double[,] arr = new double[row, col];
        Random rnd = new Random();
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = Convert.ToDouble(rnd.Next(-100, 101) / 10.0);
                Console.Write($"{arr[i, j]:F1}\t");
            }
            Console.WriteLine();
        }
        return arr;
    }
    private static double[,] GenArray(int row, int col)
    {
        double[,] arr = new double[row, col];
        Random rnd = new Random();
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = Convert.ToDouble(rnd.Next(-100, 101) / 10.0);
            }
        }
        return arr;
    }
    private static void PrintArray(double[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j]:F1}\t");
            }
            Console.WriteLine();
        }
    }
    private static int[] GetCoordinates()
    {
        int coordinCount = 0;
        Console.Write("b, k separated by spaces: ");
        string[] input = Console.ReadLine().Split();
        int[] coordinatуs = new int[input.Length];
        for (int i = 0; i < coordinatуs.Length; i++)
        {
            coordinatуs[i] = int.Parse(input[i]);
        }
        return coordinatуs;
    }
    private static double[] AithmeticAean(double[,] array)
    {
        double[] arr = new double[array.GetLength(1)];
        double tmp = 0;
        int count = 0;
        for (int i = 0; i < array.GetLength(1); i++)
        {
            for (int j = 0; j < array.GetLength(0); j++)
            {
                tmp += array[j, i];
                count++;
            }
            arr[i] = tmp / count;
            count = 0;
            tmp = 0;
        }
        return arr;
    }
}
