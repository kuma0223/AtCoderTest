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
            writer.WriteLine(10000);

            for(int i=0; i < 10000; i++) {
                writer.Write(1);
                writer.Write(" ");
            }
        }
    }
}
