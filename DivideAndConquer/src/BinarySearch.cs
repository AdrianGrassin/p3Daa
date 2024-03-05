// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// namespace DivideAndConquer
// {
//     public class BinarySearch(int target) : DivideAndConquer<int[], int>
//     {
//         private int target = target;
//
//         protected override bool Small(int[] array)
//         {
//             return array.Length <= 2;
//         }
//
//         protected override KeyValuePair<int, int[]>[] Divide(int[] array, int size)
//         {
//             if (array[array.Length / 2] == target)
//             {
//                 return new KeyValuePair<int, int[]>[] { new KeyValuePair<int, int[]>(0, new int[] { target, target }) };
//             }
//
//             if (array[array.Length / 2] > target)
//             {
//                 return new KeyValuePair<int, int[]>[]
//                     { new KeyValuePair<int, int[]>(0, array.Take(array.Length / 2).ToArray()) };
//             }
//             return new KeyValuePair<int, int[]>[]
//                     { new KeyValuePair<int, int[]>(0, array.Skip(array.Length / 2).ToArray()) };
//         }
//     
//
//         protected override int SolveSmall(int[] problem)
//         {
//             return problem.Length switch
//             {
//                 1 when problem[0] == target => problem[0],
//                 2 when problem[1] == target => problem[1],
//                 _ => -1
//             };
//         }
//
//         protected override int Combine(KeyValuePair<int, int>[] solutions)
//         {
//             foreach (var t in solutions)
//             {
//                 if (t.Value != -1)
//                 {
//                     return t.Key;
//                 }
//             }
//
//             return -1;
//         }
// }
//
// }