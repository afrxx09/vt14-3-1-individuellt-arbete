using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BeerPages
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void fwInsertBeer_InsertItem(Beer beer)
        {
            
            if (Page.ModelState.IsValid)
            {
                try
                {
                    var s = new Service();
                    s.SaveBeer(beer);

                    Page.SetTempData("SuccessMessage", "Öl har skapats.");
                    Response.RedirectToRoute("BeerDetails", new { id = beer.BeerId });
                    Context.ApplicationInstance.CompleteRequest();
                }
                catch (Exception)
                {
                    Page.ModelState.AddModelError(String.Empty, "Gick inte skriva till databasen.");
                }
            }
        }

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