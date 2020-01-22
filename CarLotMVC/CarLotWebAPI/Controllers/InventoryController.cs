using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using AutoMapper;

namespace CarLotWebAPI.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        //[HttpGet, Route("")]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //// GET api/values/5
        //[HttpGet, Route("{id}")]
        //public string Get(int id)
        //{
        //    return id.ToString();
        //}
 
       private readonly InventoryRepo _repo = new InventoryRepo();

       public InventoryController()
        {
            Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<Inventory, Inventory>()
                        .ForMember(x => x.Orders, opt => opt.Ignore());
                });
        }
        
        // GET: api/Inventory
        [HttpGet, Route("")]
        public IEnumerable<Inventory> GetInventory()
        {
            var inventories = _repo.GetAll();
            return Mapper.Map<List<Inventory>, List<Inventory>>(inventories);
        }

        // GET: api/Inventory/5
        [HttpGet, Route("{id}", Name = "DisplayRoute")]
        [ResponseType(typeof(Inventory))]
        public async Task<IHttpActionResult> GetInventory(int id)
        {
            Inventory inventory = _repo.GetOne(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Inventory, Inventory>(inventory));
        }
    }
}