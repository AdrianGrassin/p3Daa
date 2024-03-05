using System;

namespace DivideAndConquer;

public static class ArrayGenerator
{
    public static int[] Generate(int size)
    {
        var array = new int[size];
        var random = new Random();
        for (var i = 0; i < size; i++)
        {
            array[i] = random.Next(0, 1000);
        }
        return array;
    }
}