using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpeakQueryAPI.Utils;

namespace TeamSpeakQueryAPI.Command
{
    public class Parameter
    {
        private string key;
        private object value;

        public Parameter(string key, object value)
        {
            this.key = CommandEncoding.encode(key);
            this.value = CommandEncoding.encode(value.ToString());
        }

        public string GetKey()
        {
            return key;
        }

        public object GetValue()
        {
            return value;
        }
    }
}
