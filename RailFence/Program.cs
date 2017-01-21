using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RailFence
{
    class Program
    {
        static void Main(string[] args)
        {
            string linia;

            StreamReader sr = new StreamReader("plik.txt");
           
            linia = sr.ReadLine();

            int key = 4;
            string plainText = linia;

            string encipherText = Encipher(key, plainText);
            string decipherText = Decipher(key, encipherText);

            Console.WriteLine(plainText);
            Console.WriteLine(encipherText);
            Console.WriteLine(decipherText);
            Console.ReadKey();

        }

        public static string Encipher(int rail, string plainText)
        {
            List<string> railFence = new List<string>();
            for (int i = 0; i < rail; i++)
            {
                railFence.Add("");
            }

            int number = 0;
            int x = 1;
            foreach (char c in plainText)
            {
                if (number + x == rail)
                {
                    x = -1;
                }
                else if (number + x == -1)
                {
                    x = 1;
                }
                railFence[number] += c;
                number += x;
            }

            string buffer = "";
            foreach (string s in railFence)
            {
                buffer += s;
            }
            return buffer;
        }

        public static string Decipher(int rail, string encipherText)
        {
            int cipherLength = encipherText.Length;
            List<List<int>> railFence = new List<List<int>>();
            for (int i = 0; i < rail; i++)
            {
                railFence.Add(new List<int>());
            }

            int number = 0;
            int y = 1;
            for (int i = 0; i < cipherLength; i++)
            {
                if (number + y == rail)
                {
                    y = -1;
                }
                else if (number + y == -1)
                {
                    y = 1;
                }
                railFence[number].Add(i);
                number += y;
            }

            int z = 0;
            char[] buffer = new char[cipherLength];
            for (int i = 0; i < rail; i++)
            {
                for (int j = 0; j < railFence[i].Count; j++)
                {
                    buffer[railFence[i][j]] = encipherText[z];
                    z++;
                }
            }

            return new string(buffer);
        }
    }
}
