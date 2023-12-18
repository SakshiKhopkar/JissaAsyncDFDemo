using JissaAsyncDFDemo.Models;
using JissaAsyncDFDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace JissaAsyncDFDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeService service;
        public EmployeeController(IEmployeService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await service.GetEmployes();
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var model = await service.GetEmployeById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employe emp)
        {
            try
            {
                int result = await service.AddEmploye(emp);
                if (result >= 1)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await service.GetEmployeById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employe emp)
        {
            try
            {
                int result = await service.UpdateEmploye(emp);
                if (result >= 1)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await service.GetEmployeById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                int result = await service.DeleteEmploye(id);
                if (result >= 1)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
