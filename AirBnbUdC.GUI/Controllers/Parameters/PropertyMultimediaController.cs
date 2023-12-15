using AirbnbUdc.Application.Implementation.Implementation.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Mappers.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System.Net;
using System.Web.Mvc;

namespace AirBnbUdC.GUI.Controllers.Parameters
{
    public class PropertyMultimediaController : Controller
    {
        private IPropertyMultimediaApplication app;
        private IPropertyApplication propertyApp;
        private IMultimediaTypeApplication multimediaTypeApp;

        PropertyMultimediaMapperGUI mapper = new PropertyMultimediaMapperGUI();

        public PropertyMultimediaController(IPropertyMultimediaApplication PropertyMultimediaImplementationApp, IPropertyApplication PropertyImplementationApp, IMultimediaTypeApplication MultimediaTypeImplementationApp)
        {
            this.app = PropertyMultimediaImplementationApp;
            this.propertyApp = PropertyImplementationApp;
            this.multimediaTypeApp = MultimediaTypeImplementationApp;
        }

        // GET: PropertyMultimediaModels
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: PropertyMultimediaModels/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyMultimediaModel propertyMultimediaModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyMultimediaModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyMultimediaModel);
        }

        // GET: PropertyMultimediaModels/Create
        public ActionResult Create()
        {
            PropertyMultimediaModel model = new PropertyMultimediaModel();
            FillListForView(model);
            return View(model);
        }

        private void FillListForView(PropertyMultimediaModel model)
        {
            PropertyMapperGUI propertyMapper = new PropertyMapperGUI();
            model.PropertyList = propertyMapper.MapperT1toT2(propertyApp.GetAllRecords(string.Empty));

            MultimediaTypeMapperGUI multimediaTypeMapper = new MultimediaTypeMapperGUI();
            model.MultimediaTypeList = multimediaTypeMapper.MapperT1toT2(multimediaTypeApp.GetAllRecords(string.Empty));
        }

        // POST: PropertyMultimediaModels/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyMultimediaModel propertyMultimediaModel)
        {
            ModelState.Remove("Property.PropertyAddress");
            ModelState.Remove("Property.City");
            ModelState.Remove("Property.CustomerAmount");
            ModelState.Remove("Property.Price");
            ModelState.Remove("Property.Latitude");
            ModelState.Remove("Property.Longitude");
            ModelState.Remove("Property.PropertyOwner");
            ModelState.Remove("Property.CheckinData");
            ModelState.Remove("Property.CheckoutData");
            ModelState.Remove("Property.Details");
            ModelState.Remove("Property.Pets");
            ModelState.Remove("Property.Freezer");
            ModelState.Remove("Property.LaundryService");
            ModelState.Remove("MultimediaType.MultimediaTypeName");
            if (ModelState.IsValid)
            {
                PropertyMultimediaDTO propertyMultimediaDTO = mapper.MapperT2toT1(propertyMultimediaModel);
                app.CreateRecord(propertyMultimediaDTO);
                return RedirectToAction("Index");
            }
            return View(propertyMultimediaModel);
        }

        // GET: PropertyMultimediaModels/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyMultimediaModel propertyMultimediaModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyMultimediaModel == null)
            {
                return HttpNotFound();
            }
            FillListForView(propertyMultimediaModel);
            return View(propertyMultimediaModel);
        }

        // POST: PropertyMultimediaModels/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PropertyMultimediaModel propertyMultimediaModel)
        {
            ModelState.Remove("Property.PropertyAddress");
            ModelState.Remove("Property.City");
            ModelState.Remove("Property.CustomerAmount");
            ModelState.Remove("Property.Price");
            ModelState.Remove("Property.Latitude");
            ModelState.Remove("Property.Longitude");
            ModelState.Remove("Property.PropertyOwner");
            ModelState.Remove("Property.CheckinData");
            ModelState.Remove("Property.CheckoutData");
            ModelState.Remove("Property.Details");
            ModelState.Remove("Property.Pets");
            ModelState.Remove("Property.Freezer");
            ModelState.Remove("Property.LaundryService");
            ModelState.Remove("MultimediaType.MultimediaTypeName");
            if (ModelState.IsValid)
            {
                PropertyMultimediaDTO propertyMultimediaDTO = mapper.MapperT2toT1(propertyMultimediaModel);
                app.UpdateRecord(propertyMultimediaDTO);
                return RedirectToAction("Index");
            }
            return View(propertyMultimediaModel);
        }

        // GET: PropertyMultimediaModels/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyMultimediaModel propertyMultimediaModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (propertyMultimediaModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyMultimediaModel);
        }

        // POST: PropertyMultimediaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
