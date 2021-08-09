using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;

class Program
{
    const string Yes = "Yes";
    const string No = "No";
    const char White = '.';
    const char Black = '#';
    const long Mod = 1000000007;

    static void Main(string[] args) {
#if DEBUG
        MyDebugger.Test("../../TextFile1.txt");
        //MyDebugger.Test("../../TextFile2.txt");
        //TestCaseMaker.MakeTestCase1("../TextFile2.txt");
#else
        object ret = new Program().process(new StreamReader(Console.OpenStandardInput()));
        if(ret != null) Console.WriteLine(ret);
#endif
    }

    public object process(TextReader input) {
        var spl = input.ReadLine().Split(' ');
        var n = int.Parse(spl[0]);
        var s = long.Parse(spl[1]);

        var aa = new long[n];
        var bb = new long[n];

        for (int i = 0; i < n; i++) {
            spl = input.ReadLine().Split(' ');
            var a = long.Parse(spl[0]);
            var b = long.Parse(spl[1]);
            aa[i] = a;
            bb[i] = b;
        }

        var m = 100001;

        var tbl = new int[101][];

        tbl[0] = new int[m];

        tbl[0][aa[0]]++;
        tbl[0][bb[0]]++;

        for (int i = 1; i < n; i++) {
            tbl[i] = new int[m];
            var a = aa[i];
            var b = bb[i];

            for (int j = 0; j < m; j++) {
                if (tbl[i-1][j] != 0) {
                    if (j + a <= s) {
                        tbl[i][j + a] = 1;
                    }
                    if (j + b <= s) {
                        tbl[i][j + b] = 1;
                    }
                }
            }
        }

        if (tbl[n-1][s] == 0) {
            return "Impossible";
        }

        var sb = new StringBuilder();
        
        for(int i=n-1; i>=1; i--) {
            var a = aa[i];
            var b = bb[i];

            if (s-a >= 0 && tbl[i-1][s-a] != 0) {
                s -= a;
                sb.Append("A");
            } else {
                s -= b;
                sb.Append("B");
            }
        }

        if(s == aa[0]) sb.Append("A");
        else sb.Append("B");

        var sbb = new StringBuilder();
        for(int i=sb.Length-1; i>=0; i--) {
            sbb.Append(sb[i]);
        }
        return sbb;
    }


}
