using ExternalMvcAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExternalMvcAssignment.Controllers
{
    [RoutePrefix("api/WebAPIProduct")]
    public class WebAPIProductController : ApiController
    {
        ProductStoreDBEntities ps = new ProductStoreDBEntities();

        // Get api/product/getAll
        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            var res = ps.Products.ToList();
            if (res.Count == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        // Get api/product/getforid/{1}
        [HttpGet]
        [Route("getforid")]
        public IHttpActionResult Getbyid(int id)
        {
            var res = ps.Products.Find(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        // Post api/product/insert/{product}
        [HttpPost]
        public IHttpActionResult insert([FromBody] Product prod)
        {
            ps.Products.Add(prod);
            int count = ps.SaveChanges();
            if (count > 0)
            {
                return Ok(prod);
            }
            return BadRequest("Data not found");
        }

        // Put api/product/update/id/{id}/product/{product}
        [HttpPut]
        public IHttpActionResult update(int id, [FromBody] Product prod)
        {
            if (prod.Pid == id)
            {
                ps.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                ps.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok(prod);
        }

        // Delete api/product/delete/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Product prod = ps.Products.Find(id);
            if (prod == null)
            {
                return NotFound();
            }

            ps.Products.Remove(prod);
            ps.SaveChanges();

            return Ok(prod);
        }

    }
}
