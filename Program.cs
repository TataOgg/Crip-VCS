using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualcryptosystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] I=new int[][]{new int[]{1,1},new int[]{1,1}};
            int[][] B1 = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            int[][] B0 = new int[][] { new int[] { 1, 0 }, new int[] { 1, 0 } };
            int k = 2;
            int m = 2;
            int n = 2;
            DVCSCheck alg = new DVCSCheck(I, B0, B1, k, n, m);           
            /*COMPROBACIÓN DE VALIDEZ DE Bs ELEGIDAS*/
            bool checkB0MaxR = alg.checkB0MaxR(1);
            bool checkB1MaxR = alg.checkB1MaxR(0);
            bool checkLessThanR = alg.checkLessThanR();
            bool check = alg.check(1, 0);
            
            /*Algoritmo: Transformadas */
            MatrixUtilities mu = new MatrixUtilities(n,m);
            char[][] L0 = mu.T(B0);
        }
    }
}
