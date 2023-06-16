using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public static class Extension
    {
        public static string Filter(this string text, char[] symbols)
        {
            foreach(char symbol in symbols)
            {
                text = text.Replace(symbol.ToString(), string.Empty);
            }

            if(text.Length == 11)
            {
                text = text.Remove(0, 1);
            }

            return text;
        }
    }
}
