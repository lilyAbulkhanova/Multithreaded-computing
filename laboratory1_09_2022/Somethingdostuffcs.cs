using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory1_09_2022
{
    public static class LilMultithreading
    {
        public static void SumAndOperationParallel(ref float[,] matrix1, float[,] matrix2,
            Func<float, float> function, int m)
        {
            int rows1 = matrix1.GetLength(0);
            int columns1 = matrix1.GetLength(1);

            int rows2 = matrix2.GetLength(0);
            int columns2 = matrix2.GetLength(1);

            if (rows1 != rows2 && columns1 != columns2)
            {
                throw new ArithmeticException("Нельзя сложить матрицы разной размерности");
            }

            var matrixResult = matrix1;
            var opt = new ParallelOptions();
            opt.MaxDegreeOfParallelism = m;

            Parallel.For(
                0, m, opt, l =>
                {

                    int RowElementPerThread = matrixResult.GetLength(0) / m;
                    int ColumnElementPerThread = matrixResult.GetLength(1) / m;
                    int begRow = RowElementPerThread * l;
                    int begCol = ColumnElementPerThread * l;
                    int endRow = RowElementPerThread * (l + 1) - 1 + (l == m - 1 ? matrixResult.GetLength(0) % m : 0);
                    int endCol = ColumnElementPerThread * (l + 1) - 1 + (l == m - 1 ? matrixResult.GetLength(1) % m : 0);
                    for (int i = begRow; i <= endRow; i++)
                    {
                        for (int j = begCol; j <= endCol; j++)
                        {
                            matrixResult[i, j] = function(matrix2[i, j] + matrixResult[i, j]);
                        }
                    }
                }
                );
            matrix1 = matrixResult;
        } 
        
        public static float Operation(float value)
        {
            return (float)(Math.Sin(value) * Math.PI - Math.Pow(value, 3));
        }

        static Random random = new Random();

        public static void FillMatrixRandom(this float[,] matrix)
        {
            

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (float)(random.NextDouble() * random.Next(50));
                }
            }
        }

       
        public static string DrawMatrix(this float[,] matrix1)
        {
            string str1 = "";

            for (int i =0; i < matrix1.GetLength(0);i++)
            {
                for (int j = 0; j<matrix1.GetLength(1); j++)
                {
                    str1+= matrix1[i,j].ToString();
                    if(j!=matrix1.GetLength(1)-1)
                    {
                        str1 += "           ";
                    }
                }
                str1 += ("\n \n");
            }
            return str1;
        }
        public static void SumAndOperation(ref float[,] matrix1, float[,] matrix2, Func<float, float> function)
        {
            int rows1 = matrix1.GetLength(0);
            int columns1 = matrix1.GetLength(1);

            int rows2 = matrix2.GetLength(0);
            int columns2 = matrix2.GetLength(1);

            if (rows1 != rows2 && columns1 != columns2)
            {
                throw new ArithmeticException("Нельзя сложить матрицы разной размерности");
            }

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < columns1; j++)
                {
                    matrix1[i, j] = function(matrix1[i, j] + matrix2[i, j]);
                }
            }

            
        }

        
    }
}
