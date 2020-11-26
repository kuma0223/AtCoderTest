using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    const string Yes = "Yes";
    const string No = "No";
    const char White = '.';
    const char Black = '#';
    const long Mod = 1000000007;

    static void Main(string[] args) {
        checked {
#if DEBUG
            MyDebugger.Test(process, "../TextFile1.txt");
            //MyDebugger.Test(process, "../TextFile2.txt");
            //TestCaseMaker.MakeTestCase1("../TextFile2.txt");
#else
            object ret = process(new StreamReader(Console.OpenStandardInput()));
            if(ret != null) Console.WriteLine(ret);
#endif
        }
    }

    static object process(TextReader input) {
        var spl = input.ReadLine().Split(' ');
        var a = int.Parse(spl[0]);
        var b = int.Parse(spl[1]);
        var c = int.Parse(spl[2]);

        var kk = key(a, b, c);

        tbl = new Dictionary<string, double>();
        tbl["99-99-99"] = 1.0;

        for (int i = 99; i >= 0; i--) {
            for (int j = 99; j >= 0; j--) {
                for (int k = 99; k >= 0; k--) {
                    var ke = key(i, j, k);
                    var ki = func2(i, j, k);
                    tbl[ke] = ki;
                    if(ke == kk) return ki;
                }
            }
        }

        return tbl[kk];
    }

    static Dictionary<string, double> tbl;

    static double func2(int a, int b, int c) {

        if(a >= 100 | b >= 100 | c >= 100) {
            return 0;
        }

        var k = key(a, b, c);

        if (tbl.ContainsKey(k)) {
            return tbl[k];
        }

        double sousu = a + b + c;

        double ret = 0;

        if (a > 0) {
            ret += (a / sousu) * (1 + func2(a + 1, b, c));
        }
        if (b > 0) {
            ret += (b / sousu) * (1 + func2(a, b + 1, c));
        }
        if (c > 0) {
            ret += (c / sousu) * (1 + func2(a, b, c + 1));
        }

        return ret;
    }

    static string key(int a, int b, int c) {
        var ary = new int[] { a, b, c };
        Array.Sort(ary);
        return $"{ary[0]}-{ary[1]}-{ary[2]}";
    }

    static long[] ToIntArray(string strs, int n) {
        var ret = new long[n];
        var spl = strs.Split(' ');
        for (int i = 0; i < n; i++)
            ret[i] = long.Parse(spl[i]);
        return ret;
    }
}
