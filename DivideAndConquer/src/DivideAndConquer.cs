using System;
using System.Collections.Generic;

namespace DivideAndConquer
{
    public abstract class DivideAndConquer<TProblem, TResult>
    {
        protected abstract bool Small(TProblem problem);
        protected abstract KeyValuePair<int, TProblem>[] Divide(TProblem problem, int size);
        protected abstract TResult SolveSmall(TProblem problem);
        
        protected abstract TResult Combine(KeyValuePair<int, TResult>[] solutions);
        
        protected abstract string GetRecurrenceRelation();

        public TResult Solve(TProblem problem, int size)
        {
            try
            {
                if (Small(problem))
                {
                    return SolveSmall(problem);
                }

                var subProblems = Divide(problem, size);
                var solutions = new KeyValuePair<int, TResult>[subProblems.Length];
                for (var i = 0; i < subProblems.Length; i++)
                {
                    solutions[i] = new KeyValuePair<int, TResult>(subProblems[0].Key, Solve(subProblems[i].Value, size / subProblems.Length - 1));
                }
                return Combine(solutions);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return default;
            }
        }
    }
}