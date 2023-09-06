namespace CSVSorterClassLibrary
{
    public class ArgumentError
    {
        public static bool doArgumentErrorsExist(string[] args)
        {
            bool isError = false;

            if (args.Length != 3)
            {
                Console.WriteLine("This application must be given exactly three parameters: \n - the full file path of the CSV file (ex. C:\\temp\\test.csv) \n - the type of sorted values to be returned (alpha, numeric, both) \n - the sort order (ascending or descending)");
                isError = true;
            }
            else
            {
                string errorString = "";

                if (!File.Exists(args[0]))
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

                if (!String.IsNullOrEmpty(errorString))
                {
                    Console.WriteLine(errorString);
                    isError = true;
                }

            }   
            return isError;
        }
    }
}
