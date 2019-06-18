using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_to_json.Models
{
    public class InputEncapsulationModel
    {
        public List<InputModel> InputModels { get; set; }
        public string SortID { get; set; }

    }
}
