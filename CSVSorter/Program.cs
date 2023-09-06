using System.Diagnostics;
using System.Runtime.CompilerServices;
using CSVSorterClassLibrary;

[assembly:InternalsVisibleTo("CSVSorter.Test")]
namespace CSVSorter
{ 
    internal class Program
    {
        public static void Main(string[] args)
        {
            //If no argument errors exist, proceed with executing application
            if (!ArgumentError.doArgumentErrorsExist(args))
            {
                //arg[0] is the full file path to the CSV file that is to be read
                List<object> list = CSVSorterFileReader.convertCSVFileContentsToList(args[0]);

                //Print out sorted values (depending on type of list and sort order) to console window
                ListTypeSort.sortListType(args, list);                
            }                

        }        
    }
}
