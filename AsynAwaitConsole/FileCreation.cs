using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynAwaitConsole
{
    public class FileCreation
    {
        public void ReadWrite(string name)
        {
            try
            {
                string txt = System.IO.File.ReadAllText("C:\\test\\Test.txt");

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\test\\Test.txt");

                txt =txt+ sw.NewLine;
                // sw.WriteLine("Hello World!! " + name);
                sw.WriteLine(txt + name);

                //Write a second line of text
                //sw.WriteLine("From the StreamWriter class");

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
              // Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
              //  Console.WriteLine("Executing finally block.");
            }
        }
    }
}
