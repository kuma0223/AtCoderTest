using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestCaseMaker
{
    private static StreamWriter writer;
    private static Random rand;

    public static void MakeTestCase(string inputfile) {
        rand = new Random();

        using (writer = new StreamWriter(inputfile)) {
            WriteNumbers(1, 3, 100000, " ");
        }
    }

    private static void WriteNumbers(long min, long max, int count, string separater) {
        int len = count==0 ? count : (int)(max - min + 1);
        long x = min;
        
        for(int i=0; i<len; i++) {
            if(i != 0) writer.Write(separater);
            writer.Write($"{x}");
            x++;
            if(x > max) x = min;
        }
    }
}
