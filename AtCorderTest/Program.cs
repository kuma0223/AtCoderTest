using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Program
{
    const string Yes = "Yes";
    const string No = "No";
    const char White = '.';
    const char Black = '#';
    const long Mod = 998244353;

    static void Main(string[] args) {
#if DEBUG
        MyDebugger.Test("../TextFile1.txt");
        //MyDebugger.Test("../TextFile2.txt");
        //TestCaseMaker.MakeTestCase1("../TextFile2.txt");
#else
        object ret = new Program().process(new StreamReader(Console.OpenStandardInput()));
        if(ret != null) Console.WriteLine(ret);
#endif
    }

    public object process(TextReader input) {
        var spl = input.ReadLine().Split(' ');
        var n = long.Parse(spl[0]);
        var m = long.Parse(spl[1]);
        var k = long.Parse(spl[2]);

        if(n == 1 && m == 1) {
            return k;
        }

        long co = 0;

        long acopre = 0;

        for(long i=1; i<=k; i++) {
            long aco = ModPow(i, n);
            long bco = ModPow(k - i + 1, m);

            long x = aco-acopre;
            if(x < 0){
                x += Mod;
            }

            long c = (x%Mod) * bco;
            co += c % Mod;
            co %= Mod;

            //Debug.WriteLine($"{i} : {x}({aco}) {bco}");
            acopre = aco;
        }

        return co;
    }

    static long ModPow(long x1, long x2) {
        long ans = 1;
        while (x2 > 0) {
            if (x2 % 2 == 1) {
                ans = (ans * x1) % Mod;
            }
            x2 /= 2;
            if (x2 == 0) break;
            x1 = (x1 * x1) % Mod;
        }
        return ans % Mod;
    }

    static long[] ToIntArray(string strs, int n) {
        var ret = new long[n];
        var spl = strs.Split(' ');
        for (int i = 0; i < n; i++)
            ret[i] = long.Parse(spl[i]);
        return ret;
    }
}
