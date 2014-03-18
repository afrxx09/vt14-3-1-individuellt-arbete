using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BreweryPages
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Brewery fwUpdateBrewery_GetItem([RouteData]int id)
        {
            try
            {
                var s = new Service();
                return s.GetBreweryById(id);
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void fwUpdateBrewery_UpdateItem(int breweryId)
        {
            var s = new Service();
            Brewery brewery = s.GetBreweryById(breweryId);
            if (brewery == null)
            {
                ModelState.AddModelError(String.Empty, String.Format("Bryggeri med id: {0} kunde inte hittas", breweryId));
                return;
            }
            TryUpdateModel(brewery);
            if (ModelState.IsValid)
            {
                s.SaveBrewery(brewery);
                Page.SetTempData("SuccessMessage", "Bryggeriet har sparats.");
                Response.RedirectToRoute("BreweryDetails", new { id = brewery.BreweryId });
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}