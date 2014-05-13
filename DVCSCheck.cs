using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualcryptosystem
{
    class DVCSCheck
    {
        private int[][] I;
        private int[][] B0;
        private int[][] B1;
        private int k;
        private int n;
        private int m;
        private MatrixUtilities mxu;
        public DVCSCheck(int[][] I, int[][] B0, int[][] B1, int k, int n, int m)
        {
            this.I = I;
            this.B0 = B0;
            this.B1 = B1;
            this.k = k;
            this.n = n;
            this.m = m;
            mxu = new MatrixUtilities(n, m);
        }

        public bool check(int h, int l)
        {
            return this.checkB0MaxR(h) && this.checkB1MaxR(l) && this.checkLessThanR();
        }

        public List<int[]> cOR(List<int[][]> c, int r)
        {
            List<int[]> listor = new List<int[]>();
            foreach (int[][] matrix in c)
            {
                int[] or = matrixOR(matrix, r);
                listor.Add(or);
            }
            return listor;
        }

        public int H(List<int[]> cOr)
        {
            int h = 0;
            foreach(int[] or in cOr)
            {
                int sum = 0;
                foreach(int elem in or)
                {
                    sum+=elem;
                }
                if (sum > h)
                {
                    h = sum;
                }
            }
            return h;
        }

        public bool checkB0MaxR(int h)
        {
            int hfunction = this.H(this.cOR(mxu.makeC(B0), k));
            return (m-h) >= hfunction;
        }

        public bool checkB1MaxR(int l)
        {
            int hfunction = this.H(this.cOR(mxu.makeC(B1), k));
            return (m - l) <= hfunction;
        }

        public bool checkLessThanR()
        {
            bool check = true;
            for (int i = 1; i < k; i++)
            {
                int hfunctionB1 = this.H(this.cOR(mxu.makeC(B1), i));
                int hfunctionB0 = this.H(this.cOR(mxu.makeC(B0), i));
                check = check && (hfunctionB1 == hfunctionB0);
            }
            return check;
        }
        public int[] matrixOR(int[][] b, int r)
        {
            int[] or= new int[m];
            for (int i = 0; i < r; i++)
            {
                or = this.or(or, b[i]);
            }
            return or;
        }

        public int[] or(int[] row1, int[] row2)
        {
            int[] ored = new int[row1.Length];
            for (int i = 0; i < row1.Length; i++)
            {
                ored[i] = row1[i] + row2[i];
                if (ored[i] == 2) ored[i] = 1;
            }
            return ored;
        }
    }
}
