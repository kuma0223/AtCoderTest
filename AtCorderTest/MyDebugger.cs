using System;
using System.Diagnostics;
using System.IO;

public static class MyDebugger
{
    public static void Test(Func<TextReader, object> process, string inputfile) {
        Debug.WriteLine("TEST CASE OF " + inputfile);
        using (var reader = new StreamReader(inputfile)) {
            var count = 1; string str;
            var sw = new Stopwatch();
            while((str=ReadBlock(reader))!= null) {
                Debug.WriteLine("----------" + count++ + "----------");
                sw.Reset();
                sw.Start();
                object ret = process(new StringReader(str));
                sw.Stop();
                if (ret != null) Debug.WriteLine(ret);
                Debug.WriteLine(sw.ElapsedMilliseconds + "ms");
            }
        }
        Debug.WriteLine("END DEBUG");
    }

    public static string ReadBlock(StreamReader reader) {
        var text = new System.Text.StringBuilder();
        while (true) {
            var str = reader.ReadLine();
            if (str == null) break;
            if (str.Trim() == "" && text.Length > 0) break;
            if (str.StartsWith(";")) continue;
            if (str.Trim() != ""){
                text.Append(str);
                text.AppendLine();
            }
        }
        if (text.Length == 0) return null;
        return text.ToString();
    }
    
    public static string ArrayToString(System.Collections.IEnumerable list) {
        var buil = new System.Text.StringBuilder();
        buil.Append("[");
        foreach(var x in list) {
            if (buil.Length > 1) buil.Append(",");
            buil.Append(x.ToString());
        }
        buil.Append("]");
        return buil.ToString();
    }
}
