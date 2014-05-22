using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualcryptosystem
{
    class DVCSBasedAlgorithm
    {
        public int[][] A;
        public int W;
        public int H;
        public int[][] B0;
        public int[][] B1;
        public int k;
        public int m;
        public int n;
        public char[][][] T0;
        public char[][][] T1;
        public MatrixUtilities mxu;
        Random randomGenerator = new Random();

        public DVCSBasedAlgorithm(int[][] A, int W, int H, int[][] B0, int[][] B1, int k, int n, int m)
        {
            mxu = new MatrixUtilities(n, m);
            this.A = A;
            this.W = W;
            this.H = H;
            this.B0 = B0;
            this.B1 = B1;
            this.k = k;
            this.m = m;
            this.n = n;
            char[][] L0 = mxu.T(B0);
            char[][] L1 = mxu.T(B1);
            T0 = mxu.permuteToT(L0);
            T1 = mxu.permuteToT(L1);

        }

        public char[][][] generateShades()
        {
            char[][][] shades = new char[n][][]; //n shades of size WX(mxH)
            for (int index = 0; index < n; index++)
            {
                shades[index] = new char[W][];
                for (int w = 0; w < W; w++)
                {
                    shades[index][w] = new char[m * H];
                }
            }
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    char[][] rows = new char[n][];
                    int element = A[i][j];
                    if (element == 0)
                    {
                        rows = get_rows_of0(i);
                    }
                    else
                    {
                        rows = get_rows_of1(i);
                    }
                  //POPULATE SHADES
                    for (int shade = 0; shade < n; shade++)
                    {
                        char[] row = rows[shade];
                        for (int position = 0; position < m; position++)
                        {
                            shades[shade][i][j*m + position] = row[position];
                        }
                    }
                }
            }
            return shades;

        }


        public char[][] get_rows_of0(int i)
        {
            int random_index = randomGenerator.Next(0, n);
            char[][] t_random = T0[random_index];
            return t_random;
        }
        public char[][] get_rows_of1(int i)
        {
            int random_index = randomGenerator.Next(0, n);
            char[][] t_random = T1[random_index];
            return t_random;
        }
    }
}
