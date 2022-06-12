using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamtApi.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase {

		private readonly IShiftLocationStore _shiftLocationStore;
		public DefaultController(IShiftLocationStore shiftLocationStore) {
			_shiftLocationStore = shiftLocationStore;
		}

		// GET: api/<DefaultController>
		[HttpGet]
		public IActionResult Get() {

			var res =  _shiftLocationStore.GetAll().ToList();
			//return new string[] { "value1", "value2" };
			return Ok(res);
		}

		// GET api/<DefaultController>/5
		[HttpGet("{id}")]
		public string Get(int id) {
			return "value";
		}

		// POST api/<DefaultController>
		[HttpPost]
		public void Post([FromBody] string value) {
		}

		// PUT api/<DefaultController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value) {
		}

		// DELETE api/<DefaultController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
