using ExternalMvcAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExternalMvcAssignment.Controllers
{
    [RoutePrefix("api/WebAPICategory")]
    public class WebAPICategoryController : ApiController
    {
        ProductStoreDBEntities ps = new ProductStoreDBEntities();

        // Get api/category/getAll
        [HttpGet]
        [Route("getAll")]
        public IHttpActionResult GetAll()
        {
            var res = ps.Categories.ToList();
            if (res.Count == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        // Get api/category/getforid/{101}
        [HttpGet]
        [Route("getforid")]
        public IHttpActionResult Getbyid(int id)
        {
            var res = ps.Categories.Find(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        // Post api/category/insert/{category}
        [HttpPost]
        public IHttpActionResult insert([FromBody] Category cat)
        {
            ps.Categories.Add(cat);
            int count = ps.SaveChanges();
            if (count > 0)
            {
                return Ok(cat);
            }
            return BadRequest("Data not found");
        }

        // Put api/category/update/id/{id}/category/{category}
        [HttpPut]
        public IHttpActionResult update(int id, [FromBody] Category cat)
        {
            if (cat.Cid == id)
            {
                ps.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                ps.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok(cat);
        }

        // Delete api/category/delete/{id}
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Category cat = ps.Categories.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            ps.Categories.Remove(cat);
            ps.SaveChanges();

            return Ok(cat);
        }

    }
}
