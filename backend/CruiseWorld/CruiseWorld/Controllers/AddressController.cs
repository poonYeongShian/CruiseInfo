using CruiseWorld.Dtos;
using CruiseWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CruiseWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly CruiseContext _cruiseContext;

        public AddressController(CruiseContext cruiseContext)
        {
            _cruiseContext = cruiseContext;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public IEnumerable<AddressDto> Get()
        {
            var result = _cruiseContext.Addresses.Include(a=>a.CountryCodeNavigation)
                .Select(a=>new AddressDto
                {
                    AddressId = a.AddressId,
                    AddressStreet = a.AddressStreet,
                    AddressTown = a.AddressTown,
                    AddressPcode = a.AddressPcode,
                    CountryName = a.CountryCodeNavigation.CountryName
                });

            return result;
        }

        // GET api/<AddressController>/5
        [HttpGet("{AddressId}")]
        public ActionResult<AddressDto> Get(Guid AddressId)
        {
            var result = (from a in _cruiseContext.Addresses
                          where a.AddressId == AddressId
                          select a).Include(a => a.CountryCodeNavigation)
                .Select(a => new AddressDto
                {
                    AddressId = a.AddressId,
                    AddressStreet = a.AddressStreet,
                    AddressTown = a.AddressTown,
                    AddressPcode = a.AddressPcode,
                    CountryName = a.CountryCodeNavigation.CountryName
                })
                .SingleOrDefault();

            if (result == null)
            {
                return NotFound("Cannot find id: " + AddressId + " data");
            }

            return Ok(result);
        }

        // POST api/<AddressController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
