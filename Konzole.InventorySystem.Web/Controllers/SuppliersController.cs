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
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using Konzole.InventorySystem.Infrastructure;

namespace Konzole.InventorySystem.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private ISupllierProvider _supplierProvider = null;


        public SuppliersController(ISupllierProvider supplierProvider)
        {
            this._supplierProvider = supplierProvider;
        }

        // GET: Suppliers
        public ActionResult Index()
        {
            return View(this._supplierProvider.GetList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = this._supplierProvider.GetBySupplierId(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SupplierName,Address,Contact,Status")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                this._supplierProvider.Save(supplier);
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _supplierProvider.GetBySupplierId(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SupplierName,Address,Contact,Status")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierProvider.Save(supplier);
                return RedirectToAction("Index");
            }
            return View(supplier);
        }


        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _supplierProvider.GetBySupplierId(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _supplierProvider.RemoveById(id);
            return RedirectToAction("Index");
        }

        [ActionName("SupplierNavigator")]
        public ActionResult fncGetResumeNavigation()
        {
            return PartialView();
        }


        [ActionName("SupplierScripts")]
        public PartialViewResult fncGetJavaScriptForResumeBuilder()
        {
            return PartialView();
        }



        //[Authorize]
        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Search")]
        public ActionResult GenerateGrid()
        {
            
            IEnumerable<Supplier> data = this._supplierProvider.GetList();
            return View(data);
        }

        //[Authorize]

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Export")]
        public ActionResult ExportToExcel()
        {
            

            GridView gv = new GridView();

            var data = this._supplierProvider.GetList();
            gv.DataSource = data.Select(a => new Supplier
            {
                SupplierName = a.SupplierName,
                Address = a.Address,
                Contact = a.Contact,
                Email = a.Email
            });

            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Supplier.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            gv = null;

            return View(data);
        }
    }
}
