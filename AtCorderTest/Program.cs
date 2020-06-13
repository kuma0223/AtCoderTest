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
#else
            object ret = process(new StreamReader(Console.OpenStandardInput()));
            Console.WriteLine(ret);
#endif
        }
    }

    static object process(TextReader input) {
        var n = int.Parse(input.ReadLine());
        var ary = ToIntArray(input.ReadLine(), n);

        return null;
    }

    static int[] ToIntArray(string strs, int n) {
        var ret = new int[n];
        var spl = strs.Split(' ');
        for (int i = 0; i < n; i++)
            ret[i] = int.Parse(spl[i]);
        return ret;
    }
}
