using ExternalMvcAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ExternalMvcAssignment.Controllers
{
    public class MVCProductController : Controller
    {
        // GET: MVCProduct
        ProductStoreDBEntities ps = new ProductStoreDBEntities();
        public ActionResult Index()
        {
            List<Product> prod = ps.Products.ToList();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/WebAPIProduct");
            var conapi = hc.GetAsync("WebAPIProduct");
            conapi.Wait();
            var data = conapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<List<Product>>();
                display.Wait();
                prod = display.Result;
            }
            return View(prod);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product prod)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/WebAPIProduct");
            var data = hc.PostAsJsonAsync<Product>("WebAPIProduct", prod);
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
            Product prod = ps.Products.Find(id);
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/");
            var conapi = hc.GetAsync("WebAPIProduct?id=" + id.ToString());
            conapi.Wait();
            var data = conapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<Product>();
                display.Wait();
                prod = display.Result;
            }
            return View(prod);
        }

        public ActionResult Edit(int id)
        {
            Product prod = ps.Products.Find(id);
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/");
            var conapi = hc.GetAsync("WebAPIProduct?id=" + id.ToString());
            conapi.Wait();
            var data = conapi.Result;
            if (data.IsSuccessStatusCode)
            {
                var display = data.Content.ReadAsAsync<Product>();
                display.Wait();
                prod = display.Result;
            }
            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            Product product = ps.Products.Find(prod.Pid);
            product.PName = prod.PName;
            product.CatId = prod.CatId;
            product.Quantity = prod.Quantity;
            product.UnitId = prod.UnitId;
            product.Price = prod.Price;
            ps.SaveChanges();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/WebAPICategory");
            var data = hc.PutAsJsonAsync<Product>("WebAPIProduct", prod);
            data.Wait();
            var display = data.Result;
            if (display.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44396/api/");
            var conapi = hc.DeleteAsync("WebAPIProduct?id=" + id.ToString());
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