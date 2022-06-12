using Leopard.Api.Models;
using Leopard.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Leopard.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ShiftLocationController : ControllerBase {


		
		private readonly IShiftLocationStore _shiftLocationStore;
		public ShiftLocationController( IShiftLocationStore shiftLocationStore) {
			
			_shiftLocationStore = shiftLocationStore;
		}




		// GET: api/<ShiftLocationController>
		[HttpGet]
		public IActionResult Get() {

			var res = _shiftLocationStore.GetAll().Select(pp=> new { Title= pp.Title , PortalId=pp.Portal}).ToList();
			return Ok(res);
		}

		// GET api/<ShiftLocationController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id) {

			var res =_shiftLocationStore.FindById(id);

			

			return Ok(res);
		}

		// POST api/<ShiftLocationController>
		[HttpPost]
		public void Post([FromBody] ShiftLocationModel model ) {

			ShiftLocation shiftLocation = new ShiftLocation { Title = model.Title, PortalId = model.PortalId };
			_shiftLocationStore.InsertAsync(shiftLocation).Wait();

			//_shiftLocationStore.InsertAsync()
		}

		// PUT api/<ShiftLocationController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value) {
		}

		// DELETE api/<ShiftLocationController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
