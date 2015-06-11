using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PartTimeUnionApp
{


    public class ErrorLog
    {
        StreamWriter writetext = new StreamWriter("../../logfiles/system-out.txt", true);
        

        public ErrorLog()
        {
            writetext.WriteLine("\n\n =======================" + DateTime.Now.ToString() + "======================== \n\n", true);
        }

        public void WriteLog(string data)
        {
            writetext.WriteLine(data + "\n", true);
            writetext.Close();
        }

    }
}
