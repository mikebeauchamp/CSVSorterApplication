using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVSorterClassLibrary
{
    public class CSVSorterFileReader
    {
        public static List<object> convertCSVFileContentsToList(string filepath)
        {
            List<object> list = new List<object> { };
            using (StreamReader reader = new StreamReader(File.OpenRead(filepath)))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    foreach (var item in values)
                    {
                        list.Add(item);
                    }
                }
            }

            return list;
        }
    }
}
