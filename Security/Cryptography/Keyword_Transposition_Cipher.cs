using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int n = Int32.Parse(Console.ReadLine());
        string[] keylist = new string[n];
        string[] passlist = new string[n];
        for (int i = 0; i < n; i++)
        {
            keylist[i] = Console.ReadLine();
            passlist[i] = Console.ReadLine();
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(Decrypt(keylist[i], passlist[i]));
        }
        Console.ReadLine();
    }
    static string Decrypt(string k, string p)
    {
        string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        k = new string(k.Distinct().ToArray());
        int ind = k.Length;
        k = k + alpha;
        k = new string(k.Distinct().ToArray());
        int i = ind;
        while (ind < k.Length)
        {
            k = k.Insert(ind, " ");
            ind += i + 1;
        }
        string[] flist = k.Split(' ');
        List<int> order = new List<int>();
        foreach(char a in alpha)
        {
            for (int i2 = 0; i2 < flist[0].Length; i2++)
            {
                if (flist[0][i2] == a) order.Add(i2);
            }
        }
        List<char> codeline = new List<char>();
        foreach (int t in order)
        {
            int i3 = 0;
            try
            {
                while (true)
                {
                    codeline.Add(flist[i3][t]);
                    i3++;
                }
            }
            catch
            {
                continue;
            }
        }
        string fsq = new string(codeline.ToArray());
        string[] table = new string[2];
        table[0] = fsq;
        table[1] = alpha;
        string final="";

        foreach (char a in p)
        {
            if(a==' ')
            {
                final += ' ';
                continue;
            }
            for(int i3 = 0; i3 < table[0].Length; i3++)
            {
                if (a == table[0][i3])
                {
                    final += table[1][i3];
                    break;
                }
            }
        }
        return final;
    }
}