using System;
using System.Collections.Generic;

namespace DivideAndConquer;

public class MergeSort : DivideAndConquer<int[], int[]>
{   
    protected override bool Small(int[] problem)
    {
        return problem.Length <= 1;
    }

    protected override KeyValuePair<int, int[]>[] Divide(int[] problem, int size)
    {
        var mid = problem.Length / 2;
        var left = new int[mid];
        var right = new int[problem.Length - mid];
        Array.Copy(problem, 0, left, 0, mid);
        Array.Copy(problem, mid, right, 0, problem.Length - mid);
        return new KeyValuePair<int, int[]>[]
        {
            new KeyValuePair<int, int[]>(0, left),
            new KeyValuePair<int, int[]>(1, right)
        };
    }

    protected override int[] SolveSmall(int[] problem)
    {
        return problem;
    }
    
    protected override string GetRecurrenceRelation()
    {
        return "2T(n/2) + O(n)";
    }

    protected override int[] Combine(KeyValuePair<int, int[]>[] solutions)
    {
        var left = solutions[0].Value;
        var right = solutions[1].Value;
        var result = new int[left.Length + right.Length];
        var i = 0;
        var j = 0;
        var k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] < right[j])
            {
                result[k] = left[i];
                i++;
            }
            else
            {
                result[k] = right[j];
                j++;
            }
            k++;
        }
        while (i < left.Length)
        {
            result[k] = left[i];
            i++;
            k++;
        }
        while (j < right.Length)
        {
            result[k] = right[j];
            j++;
            k++;
        }
        return result;
    }
}