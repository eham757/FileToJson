using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_to_json.Models
{
    public class InputModel
    {
        public string id { get; set; }
        public string v { get; set; }
        public bool q { get; set; }
        public string t { get; set; }

        public string ToString => String.Format("{0}|{1}", id, v);
    }
}
