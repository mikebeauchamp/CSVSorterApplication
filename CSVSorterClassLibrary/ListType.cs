namespace CSVSorterClassLibrary
{
    /*
     * The ListType class handles the retrievals of both the alpha and numeric lists
     */
    public class ListType
    {
        public static List<string> getNumericListValues(List<object> list)
        {
            List<object> numericObjectList = new List<object> { };

            foreach (object obj in list)
            {
                if (Util.IsNumeric(obj))
                {
                    numericObjectList.Add(obj);
                }
            }

            //Convert (and return) list of objects to list of strings so that they can sorted later 
            return numericObjectList.Select(s => (string)s).ToList();
        }

        public static List<string> getAlphaListValues(List<object> list)
        {
            List<object> alphaObjectList = new List<object> { };

            foreach (object obj in list)
            {
                if (!Util.IsNumeric(obj))
                {
                    alphaObjectList.Add(obj);
                }
            }
            //Convert (and return) list of objects to list of strings so that they can sorted later 
            return alphaObjectList.Select(s => (string)s).ToList(); ;
        }
    }
}
