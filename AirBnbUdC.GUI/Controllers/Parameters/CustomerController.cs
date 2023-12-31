﻿using AirbnbUdc.Application.Implementation.Implementation.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Mappers.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System.Net;
using System.Web.Mvc;

namespace AirBnbUdC.GUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerApplication app;

        public CustomerController(ICustomerApplication CustomerImplementationApp) 
        {
            this.app = CustomerImplementationApp;
        }

        CustomerMapperGUI mapper = new CustomerMapperGUI();

        // GET: CustomerModels
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: CustomerModels/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel CustomerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (CustomerModel == null)
            {
                return HttpNotFound();
            }
            return View(CustomerModel);
        }

        // GET: CustomerModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                CustomerDTO customerDTO = mapper.MapperT2toT1(customerModel);
                app.CreateRecord(customerDTO);
                return RedirectToAction("Index");
            }

            return View(customerModel);
        }

        // GET: CustomerModels/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // POST: CustomerModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                CustomerDTO customerDTO = mapper.MapperT2toT1(customerModel);
                app.UpdateRecord(customerDTO);
                return RedirectToAction("Index");
            }
            return View(customerModel);
        }

        // GET: CustomerModels/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModel customerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (customerModel == null)
            {
                return HttpNotFound();
            }
            return View(customerModel);
        }

        // POST: CustomerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
