using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Konzole.InventorySystem;
using Konzole.InventorySystem.Providers.Interface;
using Konzole.InventorySystem.Web.Models;

namespace Konzole.InventorySystem.Web.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerProvider _customerProvider = null;

        public CustomersController(ICustomerProvider customerProvider)
        {
            this._customerProvider = customerProvider;
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(this._customerProvider.GetList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = this._customerProvider.GetByCustomerId(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //// GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Contact,TIN")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                this._customerProvider.Save(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customerProvider.GetByCustomerId(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Contact,TIN")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerProvider.Save(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _customerProvider.GetByCustomerId(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _customerProvider.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
