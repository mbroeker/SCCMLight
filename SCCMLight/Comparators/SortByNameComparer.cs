/**
* SortByNameComparer
* 
* @copyright       Just use it License
* @author          Markus Bröker
*/

using SCCMLight.Model;
using System.Collections;

namespace SCCMLight.Comparators
{
    /// <summary>
    /// 
    /// </summary>
    public class SortByNameComparer : IComparer
    {
        Comparer comparer = new Comparer(System.Globalization.CultureInfo.CurrentCulture);

        public int Compare(object a, object b)
        {
            Entry entry1 = (Entry)a;
            Entry entry2 = (Entry)b;

            return comparer.Compare(entry1.name, entry2.name);
        }
    }
}
