using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualcryptosystem
{
    class PVCSBasedAlgorithm
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
        char[][] L0;
        char[][] L1;
        Random randomGenerator = new Random();

        public PVCSBasedAlgorithm(int[][] A, int W, int H, int[][] B0, int[][] B1, int k, int n, int m)
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
            L0 = mxu.T(B0);
            L1 = mxu.T(B1);
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
                    shades[index][w] = new char[H];
                }
            }
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    char[] column = new char[n];
                    int element = A[i][j];
                    if (element == 0)
                    {
                        column = get_column_of0();
                    }
                    else
                    {
                        column = get_column_of1();
                    }
                    //POPULATE SHADES
                    for (int shade = 0; shade < n; shade++)
                    {
                        shades[shade][i][j] = column[shade];
                    }
                }
            }
            return shades;

        }

        public char[] get_column_of0()
        {
            int random_array = randomGenerator.Next(0, mxu.getFactorial());
            int random_column = randomGenerator.Next(0,m);
            char[] column = new char[n];
            for (int i = 0; i < n; i++)
            {
                column[i]= T0[random_array][i][random_column];
            }
            return column;
        }
        public char[] get_column_of1()
        {
            int random_array = randomGenerator.Next(0, mxu.getFactorial());
            int random_column = randomGenerator.Next(0, m);
            char[] column = new char[n];
            for (int i = 0; i < n; i++)
            {
                column[i] = T1[random_array][i][random_column];
            }
            return column;
        }
    }
}
