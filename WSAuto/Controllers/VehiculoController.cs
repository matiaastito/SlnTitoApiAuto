using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WSAuto.Data;
using WSAuto.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WSAuto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly DBAutoContext context;

        public VehiculoController(DBAutoContext context)
        {
            this.context = context;
        }

        //GET /api/Vehiculo
        [HttpGet]
        public IEnumerable<Auto> Get() 
        {
            IEnumerable<Auto> autos = (from a in context.Autos select a).ToList();
            return autos; 
        }

        //GET /api/Vehiculo/id=id
        [HttpGet("id={id}")]
        public ActionResult<Auto> Get(int id)
        {
            Auto auto = (from a in context.Autos where id == a.Id select a).SingleOrDefault();
            if (auto == null)
            {
                BadRequest();
            }
            return auto;
        }

        //GET /api/Vehiculo/modelo
        [HttpGet("modelo={modelo}")]
        public IEnumerable<Auto> MatchModel(string modelo)
        {
            IEnumerable<Auto> autos = (from a in context.Autos where a.Modelo.ToLower() == modelo.ToLower() select a).ToList();
            return autos;
        }

        //GET /api/Vehiculo/marca/modelo
        [HttpGet("{marca}/{modelo}")]
        public IEnumerable<Auto> Get(string marca, string modelo)
        {
            IEnumerable<Auto> autos = (from a in context.Autos where a.Marca.ToLower() == marca.ToLower() && a.Modelo.ToLower() == modelo.ToLower() select a).ToList();
            return autos;
        }

        [HttpGet("color={color}")]
        public IEnumerable<Auto> MatchColor(string color)
        {
            IEnumerable<Auto> autos = (from a in context.Autos where a.Color.ToLower() == color.ToLower() select a).ToList();
            return autos;
        }

        [HttpPut("{id}")]
        public ActionResult Put (int id, [FromBody]Auto auto)
        {
            if (id != auto.Id)
            {
                return BadRequest();
            }
            context.Entry(auto).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete (int id)
        {
            var auto = context.Autos.Find(id);
            if (auto == null)
            {
                return BadRequest();
            }
            context.Autos.Remove(auto);
            context.SaveChanges();
            return auto;
        }

        [HttpPost]
        public ActionResult Post (Auto auto)
        {
            context.Autos.Add(auto);
            context.SaveChanges();
            return Ok();
        }
    }
}
