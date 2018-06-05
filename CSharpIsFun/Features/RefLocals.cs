using System;

namespace CSharpIsFun.Features
{
    public static class RefLocals
    {
        public static ref int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];

            throw new InvalidOperationException("Not found");
        }
    }
}