using System.IO;

class Program
{
    
    static void Main(string[] args)
    {
        if (args.Length == 3)
        {
            //string filePath = @"C:\Temp\test2.csv";
            string filePath = args[0];

            string errorString = "";

            if (!File.Exists(filePath))
            {
                errorString += "\nPlease check your first parameter. File doesn't exist.";
            }
            if (args[1].ToLower() != "alpha" && args[1].ToLower() != "numeric" && args[1].ToLower() != "both")
            {
                errorString += "\nPlease check your second parameter. The value second parameter must either be \"alpha\", \"numeric\" or \"both\".";
            }
            if (args[2].ToLower() != "ascending" && args[2].ToLower() != "descending")
            {
                errorString += "\nPlease check your third parameter. The value third parameter must either be \"ascending\" or \"descending\".";
            }
            if (String.IsNullOrEmpty(errorString))
            {
                using (StreamReader reader = new StreamReader(File.OpenRead(filePath)))
                {
                    List<object> list = new List<object> { };
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        foreach (var item in values)
                        {
                            list.Add(item);
                        }

                        Console.WriteLine(string.Join(", ", list));
                    }
                }
            }
            else
            {
                Console.WriteLine(errorString);
            }
        }
        else
        {
            Console.WriteLine("This application must be given exactly three parameters: \n - the full file path of the CSV file (ex. C:\\temp\\test.csv) \n - the type of sorted values to be returned (alpha, numeric, both) \n - the sort order (ascending or descending)");
        }
        
    }

    public static bool IsNumeric(object Expression)
    {
        double retNum;

        bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }


    private static List<string> getNumericListValues(List<object> list)
    {
        List<object> numericObjectList = new List<object> { };
             
        foreach (object obj in list)
        {
            if (IsNumeric(obj))
            {
                numericObjectList.Add(obj);
            }            
        }

        //Convert (and return) list of objects to list of strings so that they can sorted later 
        return numericObjectList.Select(s => (string)s).ToList();
    }

    private static List<string> getAlphaListValues(List<object> list)
    {
        List<object> alphaObjectList = new List<object> { };

        foreach (object obj in list)
        {
            if (@IsNumeric(obj))
            {
                alphaObjectList.Add(obj);
            }
        }
        return alphaObjectList.Select(s => (string)s).ToList(); ;
    }
  

    private static void getAscendingOrder(List<string> list)
    {
        list.Sort((a, b) => a.CompareTo(b));
        Console.WriteLine(string.Join(", ", list));
    }

    private static void getDescendingOrder(List<string> list)
    {
        list.Sort((a, b) => b.CompareTo(a));
        Console.WriteLine(string.Join(", ", list));
    }

}
