using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseLogFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstTimeValue = new string[200];
            string[] lastTimeValue = new string[200];
            string[] countsValue = new string[200];
            string[] textValue = new string[200];


            IEnumerable<string> allLines;
            string filePath = @"C:\data\data.txt";
            if (File.Exists(filePath))
            {
                //Read all content of the files and store it to the list split with new line 
                allLines = File.ReadLines(filePath);
            }
            allLines = File.ReadLines(filePath);
           
            //all Point 1 lines
            IEnumerable<string> firstTimes = allLines.Where(d => d.StartsWith("docsDevEvFirstTime", StringComparison.CurrentCultureIgnoreCase));
            IEnumerable<string> lastTimes = allLines.Where(d => d.StartsWith("docsDevEvLastTime", StringComparison.CurrentCultureIgnoreCase));
            IEnumerable<string> counts = allLines.Where(d => d.StartsWith("docsDevEvCounts", StringComparison.CurrentCultureIgnoreCase));
            IEnumerable<string> texts = allLines.Where(d => d.StartsWith("docsDevEvText", StringComparison.CurrentCultureIgnoreCase));
            int index = 0;
            foreach (string line in firstTimes)
            {
                string[] values = line.Split('\t');//either space or tab or others as your file contain seperator  
                firstTimeValue[index] = values[1];
                index++;
               
            }
            int totalEvents = index; //
             index = 0;
            foreach (string line in lastTimes)
            {
                string[] values = line.Split('\t');//either space or tab or others as your file contain seperator  
                lastTimeValue[index] = values[1];
                index++;

            }
             index = 0;
            foreach (string line in counts)
            {
                string[] values = line.Split('\t');//either space or tab or others as your file contain seperator  
                countsValue[index] = values[1];
                index++;

            }
            index = 0;
            foreach (string line in texts)
            {
                string[] values = line.Split('\t');//either space or tab or others as your file contain seperator  
                textValue[index] = values[1];
                index++;

            }
            using (System.IO.StreamWriter file =
         new System.IO.StreamWriter(@"C:\data\cmlog.txt", true))
            {
                for (index = 0; index < totalEvents; index++)
                {
                    Console.WriteLine(firstTimeValue[index] + " " + textValue[index] + " ");
                    file.WriteLine(firstTimeValue[index] + "\t" +lastTimeValue[index] + "\t" +countsValue[index]+ "\t"+textValue[index] + " ");
                }

            }
           
        }
    }
    }

