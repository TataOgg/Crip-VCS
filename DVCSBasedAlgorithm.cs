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
        public List<int[][]> C0;
        public List<int[][]> C1;
        public MatrixUtilities mxu;

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
        }


    }
}
