using System;
using System.Collections.Generic;

namespace DivideAndConquer;

public class QuickSort : DivideAndConquer<int[], int[]>
{
    protected override bool Small(int[] size)
    {
        return size.Length <= 2;
    }
    
    protected override string GetRecurrenceRelation()
    {
        return "T(n) = 2T(n/2) + O(n)";
    }

    protected override KeyValuePair<int,int[]>[] Divide(int[] problem, int size)
    {
        var pivot = problem[0];
        var left = new List<int>();
        var right = new List<int>();
        for (var i = 1; i < problem.Length; i++)
        {
            if (problem[i] < pivot)
            {
                left.Add(problem[i]);
            }
            else
            {
                right.Add(problem[i]);
            }
        }
        var result = new KeyValuePair<int, int[]>[2];
        result[0] = new KeyValuePair<int, int[]>(pivot, left.ToArray()); // Usa el valor del pivote como la clave
        result[1] = new KeyValuePair<int, int[]>(pivot, right.ToArray());
        return result;
    }

    protected override int[] SolveSmall(int[] problem)
    {
        return problem;
    }

    protected override int[] Combine(KeyValuePair<int, int[]>[] solutions)
    {
        var left = solutions[0].Value;
        var right = solutions[1].Value;
        var pivot = solutions[0].Key;
        var result = new int[left.Length + right.Length + 1];
        left.CopyTo(result, 0);
        result[left.Length] = pivot; // Coloca el valor del pivote en la posición correcta
        right.CopyTo(result, left.Length + 1);

        return result;
    }
}