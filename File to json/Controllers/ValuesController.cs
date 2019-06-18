using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File_to_json.Models;
using Microsoft.AspNetCore.Mvc;

namespace File_to_json.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("test")]
        public IActionResult Test(InputEncapsulationModel input)
        {
            List<InputModel> inputList = input.InputModels;
            if(inputList.Count == 0)
            {
                return NoContent();
            }
            else
            {
                if(input.SortID == "" | input.SortID == null)
                {
                    input.SortID = "Falcon lijn.Pers-groep.WP6.DataBlocksGlobal.DB_PressRxD.in.ps3AVForcePress";
                }
                List<InputModel> valList = inputList.Where(i => i.id == input.SortID).ToList();
                List<ExportModel> returnList = new List<ExportModel>();
                foreach (InputModel val in valList)
                {
                    ExportModel exportModel = new ExportModel();
                    exportModel.ID = 1;
                    exportModel.y = double.Parse(val.v);
                    exportModel.x = double.Parse(val.t);
                    returnList.Add(exportModel);
                }
                return Ok(returnList);
                // return format of type [ ID,y,x ] in which ID is ID y = v x = t
                
            }
            
        }
        [HttpPost("file")]
        public IActionResult File(InputEncapsulationModel input)
        {
            string data = "ID,Value,Timestamp" + "\r\n";
            string fileLocation = @"C:\Users\akash\Desktop\test_dump\";

            foreach( InputModel model in input.InputModels)
            {
                data += model.ToString();
                data += "\r\n";
            }


            string now = DateTime.Now.Ticks.ToString();

                FileStream fileStream = System.IO.File.Create(fileLocation + now + "ftc.csv");
                byte[] textStream = Encoding.Unicode.GetBytes(data);
                fileStream.Write(textStream);
                fileStream.Close();

            return Ok(input);
        }
    }
}
