using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiResidentialController : ControllerBase
    {
        readonly IResidentialService residentialService;
        readonly IImagesService imagesService;


        public ApiResidentialController(IResidentialService residential, IImagesService images)
        {
            residentialService = residential;
            imagesService = images;
        }
        // GET: api/<ApiResidentialController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApiResidentialController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ApiResidentialController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ApiResidentialController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiResidentialController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            if (residentialService.Delete(id) && imagesService.DeleteResidentialImages(id))
                return Ok();


            return NotFound();
        }
    }
}
