using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentify.Models;
using Rentify.Services;
using System.IO;

namespace Rentify.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService pservice;
        private readonly ICategoryService cservice;
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;

        public ProductController(IProductService pservice, ICategoryService cservice, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.pservice = pservice;
            this.cservice = cservice;
            this.env = env;

        }

        // GET: ProductController
        public ActionResult Index()
        {
            var res = pservice.GetAllProducts();
            return View(res);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(pservice.GetProductById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = cservice.GetCategories();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products prod, IFormFile file)
        {
            try
            {
                using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                prod.Imageurl = "~/images/" + file.FileName;
                var res = pservice.AddProduct(prod);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    ViewBag.Error = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = cservice.GetCategories();
            var res = pservice.GetProductById(id);
            TempData["oldurl"] = res.Imageurl;
            TempData.Keep("oldurl");
            return View(res);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products prod, IFormFile file)
        {
            try
            {
                string oldimgurl = TempData["oldurl"].ToString();

                if (file != null)
                {
                    using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }

                    prod.Imageurl = "~/iamges/" + file.FileName;

                    string[] str = oldimgurl.Split("/");
                    string str1 = (str[str.Length - 1]);
                    string path = env.WebRootPath + "\\images\\" + str1;
                    System.IO.File.Delete(path);
                }
                else
                {
                    prod.Imageurl = oldimgurl;
                }

                var res = pservice.UpdateProduct(prod);
                if (res == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = pservice.DeleteProduct(id);
            return View(res);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var res = pservice.DeleteProduct(id);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View();
                }

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }
    }
}



