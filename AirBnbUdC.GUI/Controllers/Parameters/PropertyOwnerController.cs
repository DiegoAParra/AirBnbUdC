using AirbnbUdc.Application.Implementation.Implementation.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Mappers.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System.Net;
using System.Web.Mvc;

namespace AirBnbUdC.GUI.Controllers.Parameters
{
    public class PropertyOwnerController : Controller
    {
        private IPropertyOwnerApplication app;

        PropertyOwnerMapperGUI mapper = new PropertyOwnerMapperGUI();

        public PropertyOwnerController(IPropertyOwnerApplication PropertyOwnerImplementationApp)
        {
            this.app = PropertyOwnerImplementationApp;
        }

        // GET: PropertyOwnerModels
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: PropertyOwnerModels/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // GET: PropertyOwnerModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyOwnerModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] PropertyOwnerModel propertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                PropertyOwnerDTO propertyOwnerDTO = mapper.MapperT2toT1(propertyOwnerModel);
                app.CreateRecord(propertyOwnerDTO);
                return RedirectToAction("Index");
            }

            return View(propertyOwnerModel);
        }

        // GET: PropertyOwnerModels/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // POST: PropertyOwnerModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] PropertyOwnerModel propertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                PropertyOwnerDTO propertyOwnerDTO = mapper.MapperT2toT1(propertyOwnerModel);
                app.UpdateRecord(propertyOwnerDTO);
                return RedirectToAction("Index");
            }
            return View(propertyOwnerModel);
        }

        // GET: PropertyOwnerModels/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // POST: PropertyOwnerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
