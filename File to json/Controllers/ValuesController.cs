using System;
using System.Collections.Generic;
using System.Linq;
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
                if(input.SortID == "")
                {
                    return Ok(inputList);
                }
                else
                {
                    List<InputModel> returnList = inputList.Where(i => i.id == input.SortID).ToList();
                    return Ok(returnList);
                }
                
            }
            
        }
        [HttpPost("file")]
        public IActionResult File(string input)
        {
            return Ok(input);
        }
    }
}
