

namespace CSVSorterClassLibrary
{
    public class Sorter
    {
        public static List<string> getNumericAscendingOrder(List<string> list)
        {
            list.Sort((a, b) => Double.Parse(a).CompareTo(Double.Parse(b)));
            return list;
        }

        public static List<string> getNumericDescendingOrder(List<string> list)
        {
            list.Sort((a, b) => Double.Parse(b).CompareTo(Double.Parse(a)));
            return list;
        }

        public static List<string> getAlphaAscendingOrder(List<string> list)
        {
            //Compare non-nueric strings by removing all quotation marks, both single and double, first.
            list.Sort((a, b) => a.Replace("'", "").Replace("\"", "").CompareTo(b.Replace("'", "").Replace("\"", "")));
            return list;
        }

        public static List<string> getAlphaDescendingOrder(List<string> list)
        {
            //Compare non-nueric strings by removing all quotation marks, both single and double, first.
            list.Sort((a, b) => b.Replace("'", "").Replace("\"", "").CompareTo(a.Replace("'", "").Replace("\"", "")));
            return list;
        }
    }
}
