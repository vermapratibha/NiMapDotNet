using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rentify.Models;
using Rentify.Services;

namespace Rentify.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            var model = service.GetCategories();
            return View(model);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = service.GetCategoryById(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories cat)
        {
            try
            {
                var res = service.AddCategory(cat);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something Went Wrong";
                    return View();
                }


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var cat = service.GetCategoryById(id);
            return View(cat);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories cat)
        {
            try
            {
                var res = service.UpdateCategory(cat);
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

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = service.GetCategoryById(id);
            return View(cat);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var res = service.DeleteCategory(id);
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
    }
}

