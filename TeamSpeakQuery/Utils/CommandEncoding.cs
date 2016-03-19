using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Utils
{
    public class CommandEncoding
    {
        public static string encode(String str)
        {
            str = str.Replace("\\", "\\\\");

            str = str.Replace(" ", "\\s");
            str = str.Replace("/", "\\/");
            str = str.Replace("|", "\\p");
            str = str.Replace("\b", "\\b");
            str = str.Replace("\f", "\\f");
            str = str.Replace("\n", "\\n");
            str = str.Replace("\r", "\\r");
            str = str.Replace("\t", "\\t");
            str = str.Replace(((char)7).ToString(), "\\a");
            str = str.Replace(((char)11).ToString(), "\\v");

            return str;
        }

        public static string decode(String str)
        {
            str = str.Replace("\\s", " ");
            str = str.Replace("\\/", "/");
            str = str.Replace("\\p", "|");
            str = str.Replace("\\b", "\b");
            str = str.Replace("\\f", "\f");
            str = str.Replace("\\n", "\n");
            str = str.Replace("\\r", "\r");
            str = str.Replace("\\t", "\t");
            str = str.Replace("\\a", ((char)7).ToString());
            str = str.Replace("\\v", ((char)11).ToString()); 

            str = str.Replace("\\\\", "\\");

            return str;
        }
    }
}
