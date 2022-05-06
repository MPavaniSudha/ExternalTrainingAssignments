using ExternalMvcAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExternalMvcAssignment.Controllers
{
    public class MVCCategoryController : Controller
    {
        // GET: MVCCategory
        ProductStoreDBEntities ps = new ProductStoreDBEntities();
        public ActionResult Index()
        {
            List<Category> cat = ps.Categories.ToList();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/WebAPICategory");
            var conapi = hc.GetAsync("WebAPICategory");
            conapi.Wait();
            var data = conapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<List<Category>>();
                display.Wait();
                cat = display.Result;
            }
            return View(cat);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cat)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/WebAPICategory");
            var data = hc.PostAsJsonAsync<Category>("WebAPICategory", cat);
            data.Wait();
            var display = data.Result;
            if (display.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            Category cat = ps.Categories.Find(id);
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/");
            var conapi = hc.GetAsync("WebAPICategory?id=" + id.ToString());
            conapi.Wait();
            var data = conapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<Category>();
                display.Wait();
                cat = display.Result;
            }
            return View(cat);
        }

        public ActionResult Edit(int id)
        {
            Category cat = ps.Categories.Find(id);
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/");
            var conapi = hc.GetAsync("WebAPICategory?id=" + id.ToString());
            conapi.Wait();
            var data = conapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<Category>();
                display.Wait();
                cat = display.Result;
            }
            return View(cat);
        }
        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            Category category = ps.Categories.Find(cat.Cid);
            category.CName = cat.CName;
            ps.SaveChanges();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/WebAPICategory");
            var data = hc.PutAsJsonAsync<Category>("WebAPICategory", cat);
            data.Wait();
            var display = data.Result;
            if (display.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/");
            var conapi = hc.DeleteAsync("WebAPICategory?id=" + id.ToString());
            conapi.Wait();
            var data = conapi.Result;
            if (data.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}