using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestCaseMaker
{
    public static void MakeTestCase1(string inputfile) {
        Random r = new Random();

        using (var writer = new StreamWriter(inputfile)) {
            writer.WriteLine(2*100000);
            for(int i=0; i<2*100000; i++) {
                writer.WriteLine("1 1000000000");
            }
        }
    }
}
