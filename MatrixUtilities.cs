using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualcryptosystem
{
    class MatrixUtilities
    {
        char[] Latin26 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        int[][] index2 = new int[][]{ new int[]{ 0, 1 }, new int[]{ 1, 0 } };
        int[][] index3 = new int[][] { new int[] { 0, 1, 2 }, new int[] { 1, 2, 0 }, new int[] { 2, 0, 1 }, new int[] { 0, 2, 1 }, new int[] { 1, 0, 2 }, new int[] { 2, 1, 0 } };
        int n;
        int m;
        String dictionary = "default";
        char[] letters;
        Random randomGenerator = new Random();

        public int getFactorial()
        {
            if (m == 2)
            {
                return 2;
            }
            else
            {
                return 6;
            }
        }
        public MatrixUtilities(int n, int m)
        {
            this.n = n;
            this.m = m;
            letters = Latin26;
        }


        public char[][][] permuteToT(char[][] L)
        {
            int[][] indexes;
            char[][][] t;
            int size=getFactorial();
            if (m == 2)
            {
                t = new char[size][][];
                indexes = index2;
            }
            else
            {
                t = new char[size][][];
                indexes = index3;
            }

            for (int i = 0; i < size; i++)
            {
                char[][] arrayT = new char[n][];
                int[] index = indexes[i];
                for (int row = 0; row < n; row++)
                {
                    arrayT[row] = new char[m];
                    for (int column = 0; column<m; column++) 
                        arrayT[row][column] = L[row][index[column]];
                }
                t[i] = arrayT;
            }
            
            return t;
        }

        public void setDictionary(String dictionary)
        {
            this.dictionary = dictionary;
            //TODO SI SE QUIEREN AÑADIR MÁS DICCIONARIOS
        }

        public List<int[][]> makeC(int[][] b)
        {
            List<int[][]> c = new List<int[][]>();
            c.Add(b);
            c.Add(this.permutar(b));
            return c;
        }

        public int[][] permutar(int[][] b)
        {
            int[][] bpermutted = new int[n][];
            for (int i = 0; i < n; i++)
            {
                bpermutted[i] = new int[m];
            }
            for (int i = 0; i < n; i++)
            {
                int[] row = b[i];
                int jinversa = 0;
                for (int j = m - 1; j >= 0; j--)
                {
                    bpermutted[i][jinversa] = row[j];
                    jinversa++;
                }
            }
            return bpermutted;
        }
        public char getRandomChar()
        {
            int randomIndex = randomGenerator.Next(0, 26);
            return letters[randomIndex];
        }

        public char[][] T(int[][] b)
        {
            //Init
            char[][] l = new char[n][];
            char[] zeros = new char[m];
            for (int i = 0; i < n; i++) l[i] = new char[m];
            for (int j = 0; j < m; j++) l[0][j] = getRandomChar();//Primera línea fullrandom
            //Asignar los ceros
            for (int i = 0; i < m; i++)
            {
                if (b[0][i] == 0)
                {
                    zeros[i] = l[0][i];
                }else
                {
                    char random = getRandomChar();
                    while (random == l[0][i]) random = getRandomChar();
                    zeros[i] = random;
                }
            }
            HashSet<char>[] letters_in_columns = new HashSet<char>[m];
            for (int i = 0; i < m; i++)
            {
                letters_in_columns[i] = new HashSet<char>();
                letters_in_columns[i].Add(l[0][i]);
                letters_in_columns[i].Add(zeros[i]);
            }
            return bucleprincipalT(b,l,zeros,letters_in_columns);
        }

        private char[][] bucleprincipalT(int[][] b, char[][] lin, char[] zeros, HashSet<char>[] letters_in_columns)
        {
            char[][] l = (char[][])lin.Clone();
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (b[i][j] == 0)
                    {
                        l[i][j] = zeros[j];
                    }
                    else
                    {
                        char random = getRandomChar();
                        while (letters_in_columns[j].Contains(random)) random = getRandomChar();
                        l[i][j] = random;
                    }
                }
            }
            return l;
        }
    }
}
