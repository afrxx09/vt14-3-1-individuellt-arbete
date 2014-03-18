using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BeerPages
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Hämtar beer-objekt frånd databasen till form-view:n
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Beer FormView1_GetItem([RouteData]int id)
        {
            try
            {
                var s = new Service();
                return s.GetBeerById(id);
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }

        /// <summary>
        /// Sparar förändringar på en öl, kontrollerar först att den finns i databasen sen uppdatera beer-objektet enligt formview:n innan den sparas.
        /// </summary>
        /// <param name="BeerId"></param>
        public void FormView1_UpdateItem(int BeerId)
        {
            var s = new Service();
            Beer beer = s.GetBeerById(BeerId);
            if (beer == null)
            {
                ModelState.AddModelError(String.Empty, String.Format("Öl med id{0} kunde inte hittas", BeerId));
                return;
            }
            TryUpdateModel(beer);
            if (ModelState.IsValid)
            {
                s.SaveBeer(beer);
                Page.SetTempData("SuccessMessage", "Ölen har sparats.");
                Response.RedirectToRoute("BeerDetails", new { id = beer.BeerId });
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        /// <summary>
        /// Hämtar alla beertypes till drop-down-listan
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BeerType> selBeerType_GetData()
        {
            try
            {
                var s = new Service();
                return s.GetBeerTypes();
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }

        /// <summary>
        /// Hämtar alla bryggerier till drop-down-listan
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Brewery> selBrewery_GetData()
        {
            try
            {
                var s = new Service();
                return s.GetBreweries();
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }
    }
}