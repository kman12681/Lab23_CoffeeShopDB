using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lab_23.Models
{
    public class ItemsController : Controller
    {
        
        private ItemDAO dao = new ItemDAO();

        // GET: Items
        public ActionResult Index()
        {
            return View(dao.GetItemList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = dao.GetItem((int)id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Quantity,Price,Image")] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dao.AddItem(item);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Something went wrong: {e.Message}";
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = dao.GetItem((int)id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Quantity,Price,Image")] Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dao.EditItem(item);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Something went wrong: {e.Message}";
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = dao.GetItem((int)id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item = item;
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dao.DeleteItem(id);            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dao.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}


