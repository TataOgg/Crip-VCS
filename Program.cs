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
            int[][] I=new int[][]{new int[]{0,0},new int[]{1,1}};
            int[][] B1 = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            int[][] B0 = new int[][] { new int[] { 1, 0 }, new int[] { 1, 0 } };
            int k = 2;
            int m = 2;
            int n = 2;
            DVCSCheck alg = new DVCSCheck(I, B0, B1, k, n, m);
            DVCSBasedAlgorithm dvcs = new DVCSBasedAlgorithm(I, 2, 2, B0, B1, k, n, m);
            PVCSBasedAlgorithm pvcs = new PVCSBasedAlgorithm(I, 2, 2, B0, B1, k, n, m);
            /*COMPROBACIÓN DE VALIDEZ DE Bs ELEGIDAS*/
            bool checkB0MaxR = alg.checkB0MaxR(1);
            bool checkB1MaxR = alg.checkB1MaxR(0);
            bool checkLessThanR = alg.checkLessThanR();
            bool check = alg.check(1, 0);
            
            /*Algoritmo: Transformadas */
            MatrixUtilities mu22 = new MatrixUtilities(n,m);
            char[][] L0 = mu22.T(B0);
            char[][] L1 = mu22.T(B1);
            MatrixUtilities mu32 = new MatrixUtilities(3, 2);
            int[][] b32 = new int[][]{ new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 } };
            char[][] l32 = mu32.T(b32);
            char[][][] T0 = mu22.permuteToT(L0);
            char[][][] T1 = mu22.permuteToT(L1);
            char[][][] T32 = mu32.permuteToT(l32);
            char[][][] shades_dvcs = dvcs.generateShades();
            char[][][] shades_pvcs = pvcs.generateShades();
        }
    }
}
