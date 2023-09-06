using System.Diagnostics;

namespace CSVSorterClassLibrary
{
    public class ListTypeSort
    {
        public static void sortListType(string[] args, List<object> list)
        {
            if (args[1].ToLower() == "alpha")
            {
                if (args[2].ToLower() == "ascending")
                {
                    Console.WriteLine(string.Join(", ", Sorter.getAlphaAscendingOrder(ListType.getAlphaListValues(list))));
#if DEBUG
                    Debug.WriteLine(string.Join(", ", Sorter.getAlphaAscendingOrder(ListType.getAlphaListValues(list))));
#endif
                }
                else
                {
                    Console.WriteLine(string.Join(", ", Sorter.getAlphaDescendingOrder(ListType.getAlphaListValues(list))));
#if DEBUG
                    Debug.WriteLine(string.Join(", ", Sorter.getAlphaDescendingOrder(ListType.getAlphaListValues(list))));
#endif
                }
            }
            else if (args[1].ToLower() == "numeric")
            {
                if (args[2].ToLower() == "ascending")
                {
                    Console.WriteLine(string.Join(", ", Sorter.getNumericAscendingOrder(ListType.getNumericListValues(list))));
#if DEBUG
                    Debug.WriteLine(string.Join(", ", Sorter.getNumericAscendingOrder(ListType.getNumericListValues(list))));
#endif
                }
                else
                {
                    Console.WriteLine(string.Join(", ", Sorter.getNumericDescendingOrder(ListType.getNumericListValues(list))));
#if DEBUG
                    Debug.WriteLine(string.Join(", ", Sorter.getNumericDescendingOrder(ListType.getNumericListValues(list))));
#endif
                }
            }
            else //"both"
            {
                if (args[2].ToLower() == "ascending")
                {
                    //If sort type is "both" and ascending order is selected, the order should be 0-9, a-z
                    Console.WriteLine(string.Join(", ", Sorter.getNumericAscendingOrder(ListType.getNumericListValues(list))) + ", " + string.Join(", ", Sorter.getAlphaAscendingOrder(ListType.getAlphaListValues(list))));
#if DEBUG
                    Debug.WriteLine(string.Join(", ", Sorter.getNumericAscendingOrder(ListType.getNumericListValues(list))) + ", " + string.Join(", ", Sorter.getAlphaAscendingOrder(ListType.getAlphaListValues(list))));
#endif
                }
                else
                {
                    //If sort type is "both" and descending order is selected, the order should be z-a, 9-0                    
                    Console.WriteLine(string.Join(", ", Sorter.getAlphaDescendingOrder(ListType.getAlphaListValues(list))) + ", " + string.Join(", ", Sorter.getNumericDescendingOrder(ListType.getNumericListValues(list))));
#if DEBUG
                    Debug.WriteLine(string.Join(", ", Sorter.getAlphaDescendingOrder(ListType.getAlphaListValues(list))) + ", " + string.Join(", ", Sorter.getNumericDescendingOrder(ListType.getNumericListValues(list))));
#endif
                }
            }
        }
    }
}
