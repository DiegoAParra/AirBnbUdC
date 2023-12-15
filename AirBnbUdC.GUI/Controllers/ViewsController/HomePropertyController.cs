using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirBnbUdC.GUI.Mappers.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AirBnbUdC.GUI.Controllers.ViewsController
{
    public class HomePropertyController : Controller
    {
        private IPropertyApplication appProperty;
        private IPropertyMultimediaApplication appPropertyMultimedia;

        public HomePropertyController(IPropertyApplication PropertyImplementationApp, IPropertyMultimediaApplication PropertyMultimediaImplementationApp)
        {
            this.appProperty = PropertyImplementationApp;
            this.appPropertyMultimedia = PropertyMultimediaImplementationApp;
        }

        PropertyMapperGUI mapperProperty = new PropertyMapperGUI();
        PropertyMultimediaMapperGUI mapperPropertyMultimedia = new PropertyMultimediaMapperGUI();

        // GET: HomePropertyModels
        public ActionResult Index(string filter = "")
        {
            List<HomePropertyModel> listHomeProperty = new List<HomePropertyModel>();

            var listProperty = mapperProperty.MapperT1toT2(appProperty.GetAllRecords(filter));
            var listPropertyMultimedia = mapperPropertyMultimedia.MapperT1toT2(appPropertyMultimedia.GetAllRecords(filter));

            foreach (var itemProperty in listProperty)
            {
                HomePropertyModel itemHomeProperty = new HomePropertyModel();
                itemHomeProperty.Id = itemProperty.Id;
                itemHomeProperty.PropertyAddress = itemProperty.PropertyAddress;
                itemHomeProperty.CityName = itemProperty.City.Name;
                itemHomeProperty.CustomerAmount = itemProperty.CustomerAmount;
                itemHomeProperty.Price = itemProperty.Price;
                itemHomeProperty.MultimediaLinks = new List<string>();
                foreach (var itemPropertyMultimedia in listPropertyMultimedia)
                {
                    if (itemProperty.Id == itemPropertyMultimedia.Property.Id)
                    {
                        itemHomeProperty.MultimediaLinks.Add(itemPropertyMultimedia.MultimediaLink);
                    }
                }
                listHomeProperty.Add(itemHomeProperty);
            }

            return View(listHomeProperty);
        }
    }
}
