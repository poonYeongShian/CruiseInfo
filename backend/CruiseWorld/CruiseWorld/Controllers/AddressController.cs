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


        /// <summary>
        /// Attempt 1: Simple Linq to get all data
        /// GET: api/Address
        /// Get all address data
        /// </summary>
        //[HttpGet]
        //public IEnumerable<AddressDto> Get()
        //{
        //    var result = _cruiseContext.Addresses.Include(a=>a.CountryCodeNavigation)
        //        .Select(a=>new AddressDto
        //        {
        //            AddressId = a.AddressId,
        //            AddressStreet = a.AddressStreet,
        //            AddressTown = a.AddressTown,
        //            AddressPcode = a.AddressPcode,
        //            CountryName = a.CountryCodeNavigation.CountryName
        //        });

        //    return result;
        //}

        /// <summary>
        /// Attempt 2: Simple Linq to get all data
        ///            add pagination
        /// GET: api/Address
        /// Get all address data
        /// </summary>
        [HttpGet]
        public IEnumerable<AddressDto> Get(int page_num = 1, int pageSize = 5)
        {
            var result = _cruiseContext.Addresses.Include(a => a.CountryCodeNavigation)
                .OrderBy(a=>a.CountryCode)
                .Skip((page_num - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new AddressDto
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
        public ActionResult<AddressDto> GetOne(Guid AddressId)
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
    }
}
