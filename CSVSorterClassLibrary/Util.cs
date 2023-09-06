namespace CSVSorterClassLibrary
{
    public class Util
    {
        /*
       * The method below takes in an object from a list of objects, and then determines if that object is numeric by parsing it to a double.
       */
        public static bool IsNumeric(object obj)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(obj), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
    }
}
