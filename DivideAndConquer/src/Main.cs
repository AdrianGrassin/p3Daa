using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using DivideAndConquer;


public class Program
{
    public static void Main()
    {
        var random = new Random();
        var sizes = new[] { 100, 1000, 10000, 100000 }; // Tamaños de las instancias
        var mergeSort = new MergeSort();
        var quickSort = new QuickSort();

        var sb = new StringBuilder();
        sb.AppendLine("Tamaño\tMergeSort\t\tQuickSort");

        foreach (var size in sizes)
        {
            var instance = new int[size];
            for (var i = 0; i < size; i++)
            {
                instance[i] = random.Next();
            }

            var mergeSortInstance = (int[])instance.Clone();
            var quickSortInstance = (int[])instance.Clone();

            var mergeSortTime = MeasureExecutionTime(() => mergeSort.Solve(mergeSortInstance, size));
            var quickSortTime = MeasureExecutionTime(() => quickSort.Solve(quickSortInstance, size));

            sb.AppendLine($"{size}\t{mergeSortTime}\t{quickSortTime}");
        }

        Console.WriteLine(sb.ToString());
        File.WriteAllText("output.txt", sb.ToString());
    }

    static TimeSpan MeasureExecutionTime(Action action)
    {
        var stopwatch = Stopwatch.StartNew();
        action();
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
}


