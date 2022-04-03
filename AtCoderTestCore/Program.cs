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
    //const long Mod = 1000000007;
    const long Mod = 998244353;

    StringBuilder answer = new StringBuilder();

    static void Main(string[] args) {
#if DEBUG
        MyDebugger.Test("../../TextFile1.txt");
        MyDebugger.Test("../../TextFile2.txt");
        //TestCaseMaker.MakeTestCase("../../TextFile2.txt");
#else
        object ret = new Program().process(new StreamReader(Console.OpenStandardInput()));
        if(ret != null) Console.WriteLine(ret);
#endif
    }

    public object process(TextReader input) {
        var n = int.Parse(input.ReadLine());
        var s = input.ReadLine();

        var m = 1024;

        var tbl = new long[m][];

        for(int i=0; i<m; i++) {
            tbl[i] = new long[10];
        }

        int On(int b, int tar) {
            return b | (1 << tar);
        }
        int Off(int b, int tar) {
            return b & ~(1 << tar);
        }
        bool IsOn(int b, int tar) {
            return ((b >> tar) & 0x01) == 1;
        }

        tbl[On(0, s[0] - 'A')][s[0] - 'A'] = 1;

        //Debug.WriteLine($"{sum(tbl)}");

        for (int i=1; i<n; i++) {
            var bit = s[i] - 'A';

            var next = new long[m][];

            for(int j=0; j<m; j++) {
                next[j] = new long[10];
                Array.Copy(tbl[j], next[j], 10);
            }

            for (int j=0; j<m; j++) {
                if(!IsOn(j, bit)) continue;

                if (j == On(0, bit)) {
                    //bitのみ選ぶパターン
                    next[j][bit] += 1 + tbl[j][bit];
                    next[j][bit] %= Mod;
                } else {
                    //加えてbitを選ぶパターン
                    next[j][bit] += sum(tbl[Off(j, bit)]) + tbl[j][bit];
                    next[j][bit] %= Mod;
                }
            }

            tbl = next;

            //Debug.WriteLine($"{sum(tbl)}");
        }

        return sum(tbl);
    }

    long sum(long[] ary) {
        long ans = 0;

        foreach (var y in ary) {
            ans += y;
            ans %= Mod;
        }
        return ans;
    }

    long sum(long[][] ary) {
        long ans = 0;

        foreach (var x in ary) {
            foreach (var y in x) {
                ans += y;
                ans %= Mod;
            }
        }
        return ans;
    }
    //------------------------------------------------
}
