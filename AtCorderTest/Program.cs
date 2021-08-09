﻿using System;
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
        var n = int.Parse(spl[0]);
        var s = long.Parse(spl[1]);

        var aa = new long[n];
        var bb = new long[n];

        var pn = GetPrimeNumbers(600);

        for(int i=0; i<n; i++) {
            spl = input.ReadLine().Split(' ');
            var a = long.Parse(spl[0]);
            var b = long.Parse(spl[1]);
            aa[i] = a;
            bb[i] = b;
        }

        var tbl = new long[100001];

        tbl[aa[0]] = pn[0];
        tbl[bb[0]] = 1;

        for(int i=1; i<n; i++) {
            var ntbl = new long[tbl.Length];
            var a = aa[i];
            var b = bb[i];

            for (int j = 0; j < tbl.Length; j++) {
                if (tbl[j] != 0) {
                    if (j + a <= s) {
                        ntbl[j + a] = tbl[j] * pn[i];
                    }
                    if (j + b <= s) {
                        ntbl[j + b] = tbl[j] * 1;
                    }
                }
            }
            tbl = ntbl;
        }

        if(tbl[s] == 0) {
            return "Impossible";
        }

        var sb = new StringBuilder();
        for(int i=0; i<n; i++) {
            var x = pn[i];
            if (tbl[s] % x == 0) sb.Append("A");
            else sb.Append("B");
        }

        return sb;
    }

    static List<int> GetPrimeNumbers(int n) {
        var tbl = new int[n + 1];

        for (int i = 2; i <= Math.Sqrt(n);) {
            if (tbl[i] == 0) {
                var x = i * 2;
                while (x <= n) {
                    tbl[x] = 1;
                    x += i;
                }
            }
            i += (i < 3 ? 1 : 2);
        }

        var ret = new List<int>();
        ret.Add(2);
        for (int i = 3; i <= n; i += 2) {
            if (tbl[i] == 0) ret.Add(i);
        }

        return ret;
    }
}
 