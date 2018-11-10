/**
* Entry replaces KeyValuePair
* 
* @copyright       Just use it License
* @author          Markus Bröker
*/

namespace SCCMLight.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Entry
    {
        public string name;
        public string version;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nname"></param>
        /// <param name="vversion"></param>
        public Entry(string nname, string vversion)
        {
            this.name = nname;
            this.version = vversion;
        }
    }
}
